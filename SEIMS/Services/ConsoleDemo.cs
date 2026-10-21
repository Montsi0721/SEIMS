using System.Runtime.CompilerServices;
using SEIMS.Collections;
using SEIMS.Events;
using SEIMS.Models;

namespace SEIMS.Services
{
    /// <summary>
    /// Run SEIMS.exe with the argument --demo (or set it under Project > Debug properties).
    /// Opens a console that prints a trace of every OOP / delegate / LINQ feature - handy
    /// for the "Debugging Console application traces" screenshots.
    /// </summary>
    public static class ConsoleDemo
    {
        public static void Run()
        {
            NativeMethods.OpenConsole();
            Console.Title = "SEIMS - console trace";

            Section("1. Classes, inheritance, override and member hiding");
            Category electronics = new Category { Id = 1, Name = "Electronics" };
            Category food = new Category { Id = 2, Name = "Food & Beverages" };
            InventoryItem laptop = new InventoryItem("ITM-001", "Laptop HP ProBook", 1, 15, 3, 11999m, "Warehouse A - Shelf 1") { Category = electronics, SupplierId = 1 };
            PerishableItem milk = new PerishableItem("ITM-002", "Milk (1L)", 2, 42, 10, 12.50m, "Warehouse A - Shelf 3", DateTime.Today.AddDays(13), 2, 5) { Category = food, SupplierId = 2 };
            Console.WriteLine(laptop.GetItemDetails());
            Console.WriteLine();
            Console.WriteLine(milk.GetItemDetails());
            InventoryItem milkAsBase = milk;
            Console.WriteLine("Describe() via derived reference : " + milk.Describe());
            Console.WriteLine("Describe() via base reference    : " + milkAsBase.Describe() + "   <- 'new' hides, so base version runs");
            Console.WriteLine("GetItemDetails() via base ref    : overridden version runs -> " + milkAsBase.GetItemDetails().Contains("Expiry"));

            Section("2. Constructor / destructor tracking");
            Console.WriteLine("Created so far: " + InventoryItem.TotalCreated + " | active: " + InventoryItem.ActiveInstances);
            CreateTemporaryItems();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("After GC.Collect(): active = " + InventoryItem.ActiveInstances + " (temporary items finalised)");

            Section("3. Deep copy and value comparison");
            InventoryItem copy = milk.DeepCopy();
            copy.Tags.Add("promo");
            Console.WriteLine("Same reference?  " + ReferenceEquals(milk, copy));
            Console.WriteLine("Equal by value?  " + milk.Equals(copy) + " (same SKU)");
            Console.WriteLine("Tags original/copy: " + milk.Tags.Count + " / " + copy.Tags.Count + "  <- lists are not shared");
            Console.WriteLine("Hash codes equal? " + (milk.GetHashCode() == copy.GetHashCode()));

            Section("4. Custom collection: indexer, iterator, duplicate protection");
            ItemWarehouse warehouse = new ItemWarehouse();
            warehouse.Add(laptop);
            warehouse.Add(milk);
            Console.WriteLine("warehouse[\"ITM-002\"] = " + warehouse["ITM-002"]);
            Console.WriteLine("warehouse[\"nope\"]    = " + (warehouse["nope"] == null ? "null" : "found"));
            foreach (InventoryItem item in warehouse.ItemsInCategory("Food & Beverages"))
                Console.WriteLine("Iterator (Food & Beverages): " + item.Sku);
            try
            {
                warehouse.Add(copy);
            }
            catch (DuplicateItemException ex)
            {
                Console.WriteLine("Duplicate blocked: " + ex.Message);
            }

            Section("5. Delegate + event + notification class");
            FileLogger logger = new FileLogger(AppConfig.LogFilePath);
            LogHandler handler = logger.AsHandler();
            handler("Console demo started");
            using (NotificationService notifier = new NotificationService(warehouse, handler, msg => Console.WriteLine("ALERT ON SCREEN -> " + msg)))
            {
                warehouse.AdjustQuantity(laptop, 9);
                Console.WriteLine("Quantity 9: no event (not below 5).");
                warehouse.AdjustQuantity(laptop, 2);
            }
            Console.WriteLine("Last log lines read back with StreamReader:");
            foreach (string line in logger.ReadLast(3)) Console.WriteLine("   " + line);

            Section("6. Safe conversions and try / catch / finally");
            foreach (string input in new[] { "15", "abc", "99999999999", "-3", "" })
            {
                int value;
                bool ok = SafeParser.TryInt(input, out value);
                Console.WriteLine("TryInt(\"" + input + "\") -> " + ok + (ok ? " value=" + value : ""));
                try
                {
                    Console.WriteLine("   ToInt32Strict -> " + SafeParser.ToInt32Strict(input, "Quantity"));
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("   FormatException handled: " + ex.Message);
                }
            }
            Console.WriteLine("Total parse failures so far (static counter): " + SafeParser.TotalParseFailures);

            Section("7. LINQ - query syntax and method syntax");
            List<Supplier> suppliers = new List<Supplier>
            {
                new Supplier { Id = 1, Name = "TechSource Ltd" },
                new Supplier { Id = 2, Name = "FreshFarm Foods" }
            };
            ReportEngine engine = new ReportEngine(warehouse.ToList(), suppliers);
            Console.WriteLine("Total asset value (query)  : " + engine.TotalAssetValueQuerySyntax().ToString("N2"));
            Console.WriteLine("Total asset value (method) : " + engine.TotalAssetValueMethodSyntax().ToString("N2"));
            Console.WriteLine("Average unit price         : " + engine.AverageUnitPrice().ToString("N2"));
            foreach (ItemValueRow row in engine.TopByStockValueQuerySyntax(5))
                Console.WriteLine("   top (orderby desc) " + row.Sku + " " + row.TotalValue.ToString("N2"));
            foreach (SupplierCategoryRow row in engine.SupplierCategoryQuerySyntax())
                Console.WriteLine("   join+group: " + row.Supplier + " / " + row.Category + " = " + row.Items + " item(s)");

            Console.WriteLine();
            Console.WriteLine("Log file: " + logger.FilePath);
            Console.WriteLine("Press ENTER to close...");
            Console.ReadLine();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void CreateTemporaryItems()
        {
            for (int i = 0; i < 3; i++)
                new InventoryItem("TMP-" + i, "Temporary " + i, 1, 1, 1, 1m, "nowhere");
        }

        private static void Section(string title)
        {
            Console.WriteLine();
            Console.WriteLine("==== " + title + " ====");
        }
    }
}
