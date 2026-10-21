using SEIMS.Models;

namespace SEIMS.Services
{
    /// <summary>
    /// Reporting engine (Question 7). Every report is written TWICE - once in LINQ query syntax
    /// and once in method syntax - and covers orderby descending, Sum / Average aggregates
    /// and a Join + Group linking items to their suppliers.
    /// </summary>
    public class ReportEngine
    {
        private readonly IEnumerable<InventoryItem> _items;
        private readonly IEnumerable<Supplier> _suppliers;

        public ReportEngine(IEnumerable<InventoryItem> items, IEnumerable<Supplier> suppliers)
        {
            _items = items;
            _suppliers = suppliers;
        }

        // ---------- orderby descending ----------
        public List<ItemValueRow> TopByStockValueQuerySyntax(int take)
        {
            var query = from i in _items
                        orderby i.TotalValue descending
                        select ToRow(i);
            return query.Take(take).ToList();
        }

        public List<ItemValueRow> TopByStockValueMethodSyntax(int take)
        {
            return _items
                .OrderByDescending(i => i.TotalValue)
                .Select(i => ToRow(i))
                .Take(take)
                .ToList();
        }

        // ---------- aggregate operators ----------
        public decimal TotalAssetValueQuerySyntax()
        {
            return (from i in _items select i.TotalValue).Sum();
        }

        public decimal TotalAssetValueMethodSyntax()
        {
            return _items.Sum(i => i.TotalValue);
        }

        public decimal AverageUnitPrice()
        {
            return _items.Any() ? _items.Average(i => i.UnitPrice) : 0m;
        }

        // ---------- group ----------
        public List<CategorySummaryRow> ByCategoryQuerySyntax()
        {
            var query = from i in _items
                        group i by i.CategoryName into g
                        orderby g.Sum(x => x.TotalValue) descending
                        select new CategorySummaryRow
                        {
                            Category = g.Key,
                            Items = g.Count(),
                            TotalQuantity = g.Sum(x => x.Quantity),
                            TotalValue = g.Sum(x => x.TotalValue),
                            AverageUnitPrice = g.Average(x => x.UnitPrice)
                        };
            return query.ToList();
        }

        public List<CategorySummaryRow> ByCategoryMethodSyntax()
        {
            return _items
                .GroupBy(i => i.CategoryName)
                .OrderByDescending(g => g.Sum(x => x.TotalValue))
                .Select(g => new CategorySummaryRow
                {
                    Category = g.Key,
                    Items = g.Count(),
                    TotalQuantity = g.Sum(x => x.Quantity),
                    TotalValue = g.Sum(x => x.TotalValue),
                    AverageUnitPrice = g.Average(x => x.UnitPrice)
                })
                .ToList();
        }

        // ---------- join + group: items linked to suppliers ----------
        public List<SupplierCategoryRow> SupplierCategoryQuerySyntax()
        {
            var query = from i in _items
                        join s in _suppliers on i.SupplierId equals (int?)s.Id
                        group i by new { Supplier = s.Name, Category = i.CategoryName } into g
                        orderby g.Key.Supplier, g.Key.Category
                        select new SupplierCategoryRow
                        {
                            Supplier = g.Key.Supplier,
                            Category = g.Key.Category,
                            Items = g.Count(),
                            TotalQuantity = g.Sum(x => x.Quantity),
                            TotalValue = g.Sum(x => x.TotalValue)
                        };
            return query.ToList();
        }

        public List<SupplierCategoryRow> SupplierCategoryMethodSyntax()
        {
            return _items
                .Join(_suppliers, i => i.SupplierId, s => (int?)s.Id, (i, s) => new { Item = i, Supplier = s })
                .GroupBy(x => new { Supplier = x.Supplier.Name, Category = x.Item.CategoryName })
                .OrderBy(g => g.Key.Supplier)
                .ThenBy(g => g.Key.Category)
                .Select(g => new SupplierCategoryRow
                {
                    Supplier = g.Key.Supplier,
                    Category = g.Key.Category,
                    Items = g.Count(),
                    TotalQuantity = g.Sum(x => x.Item.Quantity),
                    TotalValue = g.Sum(x => x.Item.TotalValue)
                })
                .ToList();
        }

        // ---------- filters ----------
        public List<LowStockRow> LowStock()
        {
            var query = from i in _items
                        where i.Status != StockStatus.InStock
                        orderby i.Quantity
                        select new LowStockRow
                        {
                            Sku = i.Sku,
                            Name = i.Name,
                            Category = i.CategoryName,
                            Quantity = i.Quantity,
                            MinimumLevel = i.MinimumLevel,
                            Status = i.StatusText
                        };
            return query.ToList();
        }

        public List<ExpiryRow> ExpiringSoon()
        {
            return _items
                .OfType<PerishableItem>()
                .Where(p => p.IsExpiringSoon)
                .OrderBy(p => p.ExpiryDate)
                .Select(p => new ExpiryRow
                {
                    Sku = p.Sku,
                    Name = p.Name,
                    ExpiryDate = p.ExpiryDate,
                    DaysLeft = p.DaysToExpiry,
                    Quantity = p.Quantity
                })
                .ToList();
        }

        private static ItemValueRow ToRow(InventoryItem i)
        {
            return new ItemValueRow
            {
                Sku = i.Sku,
                Name = i.Name,
                Category = i.CategoryName,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                TotalValue = i.TotalValue
            };
        }
    }
}
