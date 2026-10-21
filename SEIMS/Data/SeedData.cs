using SEIMS.Models;
using SEIMS.Services;

namespace SEIMS.Data
{
    /// <summary>First-run data: demo accounts, categories, suppliers and 124 stock items.</summary>
    public static class SeedData
    {
        public static void Seed(SeimsDbContext db)
        {
            if (!db.Users.Any()) SeedUsers(db);
            if (!db.Categories.Any()) SeedInventory(db);
        }

        private static void SeedUsers(SeimsDbContext db)
        {
            AddUser(db, "admin", "System Administrator", "Admin@123", UserRole.Admin);
            AddUser(db, "manager", "Warehouse Manager", "Manager@123", UserRole.Manager);
            AddUser(db, "viewer", "Audit Viewer", "Viewer@123", UserRole.Viewer);
            db.SaveChanges();
        }

        private static void AddUser(SeimsDbContext db, string username, string fullName, string password, UserRole role)
        {
            string salt, hash;
            SecurityService.CreateHash(password, out salt, out hash);
            db.Users.Add(new AppUser
            {
                Username = username,
                FullName = fullName,
                Salt = salt,
                PasswordHash = hash,
                Role = role,
                IsActive = true
            });
        }

        private static void SeedInventory(SeimsDbContext db)
        {
            var electronics = new Category { Name = "Electronics", Description = "Computers and accessories" };
            var food = new Category { Name = "Food & Beverages", Description = "Perishable and packaged food" };
            var furniture = new Category { Name = "Furniture", Description = "Office and warehouse furniture" };
            var office = new Category { Name = "Office Supplies", Description = "Stationery and consumables" };
            db.Categories.AddRange(electronics, food, furniture, office);

            var sTech = new Supplier { Name = "TechSource Ltd", ContactEmail = "sales@techsource.example", Phone = "+266 5000 0001" };
            var sFresh = new Supplier { Name = "FreshFarm Foods", ContactEmail = "orders@freshfarm.example", Phone = "+266 5000 0002" };
            var sHome = new Supplier { Name = "HomeStyle Furniture", ContactEmail = "info@homestyle.example", Phone = "+266 5000 0003" };
            var sOffice = new Supplier { Name = "OfficeHub Supplies", ContactEmail = "hello@officehub.example", Phone = "+266 5000 0004" };
            db.Suppliers.AddRange(sTech, sFresh, sHome, sOffice);
            db.SaveChanges();

            var list = new List<InventoryItem>();

            // ---- the ten rows shown on the dashboard design ----
            list.Add(new InventoryItem("ITM-001", "Laptop HP ProBook", electronics.Id, 15, 3, 11999.00m, "Warehouse A - Shelf 1") { SupplierId = sTech.Id, Description = "14-inch business laptop, 16GB RAM, 512GB SSD." });
            list.Add(new PerishableItem("ITM-002", "Milk (1L)", food.Id, 42, 10, 12.50m, "Warehouse A - Shelf 3", new DateTime(2026, 10, 25), 2, 5) { SupplierId = sFresh.Id, Description = "Fresh milk, 1 liter pack. Keep refrigerated between 2\u00B0C and 5\u00B0C." });
            list.Add(new InventoryItem("ITM-003", "Office Chair", furniture.Id, 8, 2, 1450.00m, "Warehouse B - Zone 2") { SupplierId = sHome.Id, Description = "Ergonomic office chair with lumbar support." });
            list.Add(new PerishableItem("ITM-004", "Tomatoes", food.Id, 5, 10, 18.00m, "Warehouse A - Shelf 4", new DateTime(2026, 10, 18), 8, 12) { SupplierId = sFresh.Id, Description = "Fresh tomatoes, 1kg crates." });
            list.Add(new InventoryItem("ITM-005", "Printer Ink (Black)", office.Id, 20, 5, 320.00m, "Warehouse B - Shelf 7") { SupplierId = sOffice.Id, Description = "Black ink cartridge for laser printers." });
            list.Add(new PerishableItem("ITM-006", "Chicken Breast", food.Id, 3, 10, 85.00m, "Cold Room 1", new DateTime(2026, 10, 16), 0, 4) { SupplierId = sFresh.Id, Description = "Fresh chicken breast, 1kg packs. Keep refrigerated." });
            list.Add(new InventoryItem("ITM-007", "Mouse Wireless", electronics.Id, 12, 4, 220.00m, "Warehouse A - Shelf 2") { SupplierId = sTech.Id, Description = "2.4GHz wireless optical mouse." });
            list.Add(new PerishableItem("ITM-008", "Yogurt", food.Id, 6, 10, 14.50m, "Warehouse A - Shelf 3", new DateTime(2026, 10, 22), 2, 6) { SupplierId = sFresh.Id, Description = "Plain yogurt, 500ml tubs." });
            list.Add(new InventoryItem("ITM-009", "Paper Ream A4", office.Id, 50, 10, 75.00m, "Warehouse B - Shelf 1") { SupplierId = sOffice.Id, Description = "80gsm A4 paper, 500 sheets." });
            list.Add(new PerishableItem("ITM-010", "Orange Juice", food.Id, 4, 10, 28.00m, "Warehouse A - Shelf 5", new DateTime(2026, 10, 30), 2, 8) { SupplierId = sFresh.Id, Description = "100% orange juice, 1 liter." });

            // ---- generated stock so reports run over a realistic data set (124 items in total) ----
            string[][] names =
            {
                new[] { "USB-C Cable", "Wireless Keyboard", "24\" Monitor", "HDMI Cable", "Webcam HD", "Headset", "Wi-Fi Router", "External SSD 1TB", "Laptop Stand", "Power Bank" },
                new[] { "Eggs (Tray of 30)", "Butter 500g", "Cheddar Cheese", "Bread Loaf", "Lettuce", "Carrots (1kg)", "Beef Mince 1kg", "Fish Fillet", "Cream 500ml", "Apples (1kg)" },
                new[] { "Standing Desk", "Filing Cabinet", "Bookshelf", "Visitor Chair", "Meeting Table", "Storage Locker", "Monitor Arm", "Whiteboard" },
                new[] { "Stapler", "Ballpoint Pens (Box)", "Notebook A5", "Marker Set", "Folder Pack", "Sticky Notes", "Toner Cartridge", "Envelope Pack" }
            };
            Category[] cats = { electronics, food, furniture, office };
            Supplier[] sups = { sTech, sFresh, sHome, sOffice };
            var rnd = new Random(2026);

            for (int n = 11; n <= 124; n++)
            {
                int c = n % 4;
                string[] pool = names[c];
                string baseName = pool[(n / 4) % pool.Length];
                int round = (n / 4) / pool.Length + 1;
                string name = round > 1 ? baseName + " (Series " + round + ")" : baseName;
                string sku = "ITM-" + n.ToString("000");
                int qty = rnd.Next(0, 90);
                int min = rnd.Next(5, 16);
                decimal price;
                switch (c)
                {
                    case 0: price = rnd.Next(80, 8000); break;
                    case 1: price = rnd.Next(8, 200); break;
                    case 2: price = rnd.Next(300, 6000); break;
                    default: price = rnd.Next(15, 900); break;
                }
                string loc = "Warehouse " + (char)('A' + rnd.Next(3)) + " - Shelf " + rnd.Next(1, 13);

                InventoryItem item;
                if (c == 1)
                    item = new PerishableItem(sku, name, cats[c].Id, qty, min, price, loc, DateTime.Today.AddDays(rnd.Next(1, 75)), 0, 6);
                else
                    item = new InventoryItem(sku, name, cats[c].Id, qty, min, price, loc);

                item.SupplierId = sups[c].Id;
                item.Description = cats[c].Name + " stock item supplied for the warehouse.";
                list.Add(item);
            }

            db.Items.AddRange(list);
            db.AuditLogs.Add(new AuditLog
            {
                Timestamp = DateTime.Now,
                Username = "system",
                Action = "INIT",
                EntityName = "Database",
                EntityKey = "SeimsDb",
                Details = "Database created and seeded with " + list.Count + " items."
            });
            db.SaveChanges();
        }
    }
}
