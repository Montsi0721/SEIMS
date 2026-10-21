using Microsoft.EntityFrameworkCore;
using SEIMS.Models;
using SEIMS.Services;

namespace SEIMS.Data
{
    /// <summary>
    /// Entity Framework Core context (Question 8). Code-first. Table-per-hierarchy:
    /// InventoryItem and PerishableItem share one table with an "ItemType" discriminator.
    /// </summary>
    public class SeimsDbContext : DbContext
    {
        public SeimsDbContext() { }

        public SeimsDbContext(DbContextOptions<SeimsDbContext> options) : base(options) { }

        public DbSet<InventoryItem> Items { get; set; }
        public DbSet<PerishableItem> PerishableItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<SystemSetting> Settings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryItem>(e =>
            {
                e.ToTable("InventoryItems");
                e.HasKey(i => i.Id);
                e.Property(i => i.Sku).IsRequired().HasMaxLength(30);
                e.HasIndex(i => i.Sku).IsUnique();               // no duplicate IDs in the database either
                e.Property(i => i.Name).IsRequired().HasMaxLength(100);
                e.Property(i => i.StorageLocation).HasMaxLength(100);
                e.Property(i => i.Description).HasMaxLength(500);
                e.Property(i => i.UnitPrice).HasPrecision(18, 2);
                e.Ignore(i => i.Tags);
                e.HasDiscriminator<string>("ItemType")
                    .HasValue<InventoryItem>("Regular")
                    .HasValue<PerishableItem>("Perishable");
            });

            modelBuilder.Entity<PerishableItem>(e =>
            {
                e.Property(p => p.ExpiryDate).HasColumnType("date");
            });

            // ONE-TO-MANY: Supplier (1) ---- (many) InventoryItem
            modelBuilder.Entity<Supplier>(e =>
            {
                e.Property(s => s.Name).IsRequired().HasMaxLength(100);
                e.Property(s => s.ContactEmail).HasMaxLength(150);
                e.Property(s => s.Phone).HasMaxLength(40);
                e.HasMany(s => s.Items)
                    .WithOne(i => i.Supplier)
                    .HasForeignKey(i => i.SupplierId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // ONE-TO-MANY: Category (1) ---- (many) InventoryItem
            modelBuilder.Entity<Category>(e =>
            {
                e.Property(c => c.Name).IsRequired().HasMaxLength(60);
                e.HasIndex(c => c.Name).IsUnique();
                e.Property(c => c.Description).HasMaxLength(200);
                e.HasMany(c => c.Items)
                    .WithOne(i => i.Category)
                    .HasForeignKey(i => i.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<AuditLog>(e =>
            {
                e.Property(a => a.Username).HasMaxLength(50);
                e.Property(a => a.Action).HasMaxLength(30);
                e.Property(a => a.EntityName).HasMaxLength(40);
                e.Property(a => a.EntityKey).HasMaxLength(60);
                e.Property(a => a.Details).HasMaxLength(400);
                e.HasIndex(a => a.Timestamp);
            });

            modelBuilder.Entity<AppUser>(e =>
            {
                e.Property(u => u.Username).IsRequired().HasMaxLength(50);
                e.HasIndex(u => u.Username).IsUnique();
                e.Property(u => u.FullName).HasMaxLength(100);
                e.Property(u => u.PasswordHash).IsRequired().HasMaxLength(200);
                e.Property(u => u.Salt).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<SystemSetting>(e =>
            {
                e.HasKey(s => s.Key);
                e.Property(s => s.Key).HasMaxLength(60);
                e.Property(s => s.Value).HasMaxLength(200);
            });
        }
    }
}
