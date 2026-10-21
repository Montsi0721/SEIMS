using Microsoft.EntityFrameworkCore;
using SEIMS.Collections;
using SEIMS.Data;
using SEIMS.Models;

namespace SEIMS.Services
{
    public class DashboardStats
    {
        public int TotalItems { get; set; }
        public int LowStock { get; set; }
        public int ExpiringSoon { get; set; }
        public int AuditRecords { get; set; }
    }

    /// <summary>
    /// Single entry point between the user interface and the database.
    /// Every destructive / changing action checks the user's role and writes an audit record.
    /// </summary>
    public sealed class InventoryService : IDisposable
    {
        private readonly SeimsDbContext _db = new SeimsDbContext();

        public ItemWarehouse Warehouse { get; private set; }
        public FileLogger Logger { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<Supplier> Suppliers { get; private set; }

        public InventoryService(FileLogger logger)
        {
            Logger = logger;
            Warehouse = new ItemWarehouse();
            Categories = new List<Category>();
            Suppliers = new List<Supplier>();
        }

        public void Initialize()
        {
            Refresh();
            Logger.Write("Inventory service started: " + Warehouse.Count + " items loaded for " + SecurityService.CurrentUsername + ".");
        }

        /// <summary>Reloads everything from the database (data bound straight from Entity Framework).</summary>
        public void Refresh()
        {
            _db.ChangeTracker.Clear();
            Categories = _db.Categories.OrderBy(c => c.Name).ToList();
            Suppliers = _db.Suppliers.OrderBy(s => s.Name).ToList();
            List<InventoryItem> items = _db.Items
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .OrderBy(i => i.Id)
                .ToList();
            Warehouse.Load(items);
        }

        public DashboardStats GetStats()
        {
            return new DashboardStats
            {
                TotalItems = Warehouse.Count,
                LowStock = Warehouse.Count(i => i.Status != StockStatus.InStock),
                ExpiringSoon = Warehouse.OfType<PerishableItem>().Count(p => p.IsExpiringSoon),
                AuditRecords = _db.AuditLogs.Count()
            };
        }

        // ------------------------------------------------------------------ CRUD
        public void AddItem(InventoryItem item)
        {
            SecurityService.Demand(Permission.Edit);

            if (Warehouse.Contains(item))
                throw new DuplicateItemException(item.Sku);

            item.Category = Categories.FirstOrDefault(c => c.Id == item.CategoryId);
            item.Supplier = Suppliers.FirstOrDefault(s => s.Id == item.SupplierId);

            _db.Items.Add(item);
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                _db.Entry(item).State = EntityState.Detached;
                throw;
            }

            Warehouse.Add(item);
            Audit("ADD", "InventoryItem", item.Sku, "Added " + item.Name + " (qty " + item.Quantity + ").");
            Warehouse.NotifyIfCritical(item);
        }

        public void UpdateItem(InventoryItem tracked, InventoryItem edited)
        {
            SecurityService.Demand(Permission.Edit);

            string before = "qty " + tracked.Quantity + ", price " + tracked.UnitPrice.ToString("N2");
            tracked.CopyValuesFrom(edited);
            tracked.Category = Categories.FirstOrDefault(c => c.Id == tracked.CategoryId);
            tracked.Supplier = Suppliers.FirstOrDefault(s => s.Id == tracked.SupplierId);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                _db.Entry(tracked).Reload();
                throw;
            }

            string after = "qty " + tracked.Quantity + ", price " + tracked.UnitPrice.ToString("N2");
            Audit("UPDATE", "InventoryItem", tracked.Sku, tracked.Name + ": " + before + " -> " + after);
            Warehouse.NotifyIfCritical(tracked);
        }

        public void DeleteItem(InventoryItem item)
        {
            SecurityService.Demand(Permission.Delete);   // Admin only

            string sku = item.Sku;
            string name = item.Name;

            _db.Items.Remove(item);
            _db.SaveChanges();
            Warehouse.Remove(item);

            Audit("DELETE", "InventoryItem", sku, "Deleted " + name + ".");
        }

        // ------------------------------------------------------------------ audit trail
        public void Audit(string action, string entity, string key, string details)
        {
            var log = new AuditLog
            {
                Timestamp = DateTime.Now,
                Username = SecurityService.CurrentUsername,
                Action = action,
                EntityName = entity,
                EntityKey = key,
                Details = InputSanitizer.CleanText(details, 400)
            };
            _db.AuditLogs.Add(log);
            _db.SaveChanges();

            Logger.Write(action + " " + entity + " " + key + " by " + log.Username + " - " + log.Details);
        }

        public List<AuditLog> GetAuditLogs(DateTime? fromDate, DateTime? toDate, string text, int take)
        {
            IQueryable<AuditLog> query = _db.AuditLogs.AsNoTracking();

            if (fromDate.HasValue)
            {
                DateTime start = fromDate.Value.Date;
                query = query.Where(a => a.Timestamp >= start);
            }
            if (toDate.HasValue)
            {
                DateTime end = toDate.Value.Date.AddDays(1);
                query = query.Where(a => a.Timestamp < end);
            }
            if (!string.IsNullOrWhiteSpace(text))
            {
                string t = InputSanitizer.CleanText(text, 60);
                query = query.Where(a => a.Username.Contains(t) || a.Action.Contains(t) ||
                                         a.EntityKey.Contains(t) || a.Details.Contains(t));
            }

            return query.OrderByDescending(a => a.Timestamp).Take(take).ToList();
        }

        public List<AuditLog> GetItemHistory(string sku)
        {
            return _db.AuditLogs.AsNoTracking()
                .Where(a => a.EntityKey == sku)
                .OrderByDescending(a => a.Timestamp)
                .Take(25)
                .ToList();
        }

        public List<AuditSummaryRow> GetAuditSummary()
        {
            var rows = _db.AuditLogs.AsNoTracking()
                .GroupBy(a => a.Username)
                .Select(g => new AuditSummaryRow
                {
                    User = g.Key,
                    Actions = g.Count(),
                    LastAction = g.Max(a => a.Timestamp)
                })
                .ToList();
            return rows.OrderByDescending(r => r.Actions).ToList();
        }

        // ------------------------------------------------------------------ export
        public string ExportXml(string path)
        {
            string tracking = XmlExporter.Export(_db, path);
            Audit("EXPORT", "Inventory", tracking, "XML export written to " + Path.GetFileName(path));
            return tracking;
        }

        public ReportEngine CreateReportEngine()
        {
            return new ReportEngine(Warehouse.ToList(), Suppliers);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
