using System.Globalization;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using SEIMS.Data;
using SEIMS.Models;

namespace SEIMS.Services
{
    /// <summary>
    /// Question 8: reads the structure from the LIVE database, updates the export tracking number
    /// and writes a formatted XML document.
    /// </summary>
    public static class XmlExporter
    {
        public static string Export(SeimsDbContext db, string path)
        {
            SecurityService.Demand(Permission.Export);

            // 1. update the tracking number stored in the database
            SystemSetting setting = db.Settings.FirstOrDefault(s => s.Key == "ExportBatch");
            if (setting == null)
            {
                setting = new SystemSetting { Key = "ExportBatch", Value = "0" };
                db.Settings.Add(setting);
            }

            int batch;
            if (!int.TryParse(setting.Value, out batch)) batch = 0;
            batch++;
            setting.Value = batch.ToString(CultureInfo.InvariantCulture);
            db.SaveChanges();

            string tracking = "EXP-" + batch.ToString("0000");

            // 2. read the current rows
            List<InventoryItem> items = db.Items
                .AsNoTracking()
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .OrderBy(i => i.Sku)
                .ToList();

            // 3. build formatted XML
            var root = new XElement("Inventory",
                new XAttribute("trackingNumber", tracking),
                new XAttribute("generatedAt", DateTime.Now.ToString("s")),
                new XAttribute("generatedBy", Clean(SecurityService.CurrentUsername)),
                new XAttribute("itemCount", items.Count),
                items.Select(i => ItemElement(i)));

            var doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), root);
            doc.Save(path);
            return tracking;
        }

        private static XElement ItemElement(InventoryItem i)
        {
            var element = new XElement("Item",
                new XAttribute("sku", Clean(i.Sku)),
                new XAttribute("type", i.ItemTypeName),
                new XElement("Name", Clean(i.Name)),
                new XElement("Category", Clean(i.CategoryName)),
                new XElement("Supplier", i.Supplier != null ? Clean(i.Supplier.Name) : ""),
                new XElement("Quantity", i.Quantity),
                new XElement("MinimumLevel", i.MinimumLevel),
                new XElement("UnitPrice", i.UnitPrice.ToString("F2", CultureInfo.InvariantCulture)),
                new XElement("TotalValue", i.TotalValue.ToString("F2", CultureInfo.InvariantCulture)),
                new XElement("Status", i.StatusText),
                new XElement("Location", Clean(i.StorageLocation)));

            PerishableItem p = i as PerishableItem;
            if (p != null)
            {
                element.Add(new XElement("Expiry",
                    new XAttribute("date", p.ExpiryDate.ToString("yyyy-MM-dd")),
                    new XAttribute("daysLeft", p.DaysToExpiry)));
            }
            return element;
        }

        private static string Clean(string text)
        {
            return InputSanitizer.StripControl(text);
        }
    }
}
