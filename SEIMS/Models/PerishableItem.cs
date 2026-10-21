using System;

namespace SEIMS.Models
{
    /// <summary>Derived class (Question 1): items that expire and need controlled storage.</summary>
    public class PerishableItem : InventoryItem
    {
        public const int ExpiringSoonDays = 30;

        public DateTime ExpiryDate { get; set; }
        public int MinStorageTempC { get; set; }
        public int MaxStorageTempC { get; set; }

        /// <summary>Used by Entity Framework and DeepCopy.</summary>
        protected PerishableItem() : base()
        {
            ExpiryDate = DateTime.Today.AddDays(14);
            MinStorageTempC = 2;
            MaxStorageTempC = 5;
        }

        public PerishableItem(string sku, string name, int categoryId, int quantity,
                              int minimumLevel, decimal unitPrice, string storageLocation,
                              DateTime expiryDate, int minTempC, int maxTempC)
            : base(sku, name, categoryId, quantity, minimumLevel, unitPrice, storageLocation)
        {
            ExpiryDate = expiryDate;
            MinStorageTempC = minTempC;
            MaxStorageTempC = maxTempC;
        }

        public int DaysToExpiry { get { return (ExpiryDate.Date - DateTime.Today).Days; } }
        public bool IsExpired { get { return DaysToExpiry < 0; } }
        public bool IsExpiringSoon { get { return DaysToExpiry <= ExpiringSoonDays; } }

        public override string ItemTypeName { get { return "Perishable"; } }

        public override bool RequiresRefrigeration { get { return MaxStorageTempC <= 8; } }

        public override string GetStorageInstructions()
        {
            if (RequiresRefrigeration)
                return "Keep refrigerated between " + MinStorageTempC + "\u00B0C and " + MaxStorageTempC + "\u00B0C.";
            return "Store at " + MinStorageTempC + "\u00B0C to " + MaxStorageTempC + "\u00B0C. Use before the expiry date.";
        }

        /// <summary>OVERRIDE (Question 1): extends the base description with expiry information.</summary>
        public override string GetItemDetails()
        {
            string nl = Environment.NewLine;
            return base.GetItemDetails() + nl +
                   "Expiry date  : " + ExpiryDate.ToString("yyyy-MM-dd") + " (" + DaysToExpiry + " day(s) left)" + nl +
                   "Storage temp : " + MinStorageTempC + "\u00B0C to " + MaxStorageTempC + "\u00B0C";
        }

        /// <summary>MEMBER HIDING (Question 1): 'new' hides InventoryItem.Describe().</summary>
        public new string Describe()
        {
            return base.Describe() + " (perishable, expires " + ExpiryDate.ToString("yyyy-MM-dd") + ")";
        }

        public override InventoryItem DeepCopy()
        {
            PerishableItem copy = new PerishableItem();
            CopyBaseTo(copy);
            copy.ExpiryDate = ExpiryDate;
            copy.MinStorageTempC = MinStorageTempC;
            copy.MaxStorageTempC = MaxStorageTempC;
            return copy;
        }

        public override void CopyValuesFrom(InventoryItem source)
        {
            base.CopyValuesFrom(source);
            PerishableItem other = source as PerishableItem;
            if (other != null)
            {
                ExpiryDate = other.ExpiryDate;
                MinStorageTempC = other.MinStorageTempC;
                MaxStorageTempC = other.MaxStorageTempC;
            }
        }
    }
}
