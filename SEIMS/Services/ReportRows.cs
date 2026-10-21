namespace SEIMS.Services
{
    public class ItemValueRow
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalValue { get; set; }
    }

    public class CategorySummaryRow
    {
        public string Category { get; set; }
        public int Items { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalValue { get; set; }
        public decimal AverageUnitPrice { get; set; }
    }

    public class SupplierCategoryRow
    {
        public string Supplier { get; set; }
        public string Category { get; set; }
        public int Items { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalValue { get; set; }
    }

    public class LowStockRow
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int MinimumLevel { get; set; }
        public string Status { get; set; }
    }

    public class ExpiryRow
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int DaysLeft { get; set; }
        public int Quantity { get; set; }
    }

    public class AuditSummaryRow
    {
        public string User { get; set; }
        public int Actions { get; set; }
        public DateTime LastAction { get; set; }
    }
}
