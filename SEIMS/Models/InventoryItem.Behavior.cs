using System;
using System.Collections.Generic;

namespace SEIMS.Models
{
    /// <summary>
    /// InventoryItem - PART 2 of 2 (partial class, Question 1).
    /// Behaviour: IStorable, ICloneable (deep copy), value comparison, status rules.
    /// </summary>
    public partial class InventoryItem : IStorable, ICloneable, IEquatable<InventoryItem>
    {
        // ---------- derived (read-only) information ----------
        public virtual string ItemTypeName { get { return "Regular"; } }

        public decimal TotalValue { get { return Quantity * UnitPrice; } }

        public string CategoryName
        {
            get { return Category != null ? Category.Name : "Uncategorised"; }
        }

        public StockStatus Status
        {
            get
            {
                if (Quantity < CriticalThreshold) return StockStatus.VeryLow;
                if (Quantity <= MinimumLevel) return StockStatus.LowStock;
                return StockStatus.InStock;
            }
        }

        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case StockStatus.VeryLow: return "Very Low";
                    case StockStatus.LowStock: return "Low Stock";
                    default: return "In Stock";
                }
            }
        }

        // ---------- IStorable ----------
        public virtual bool RequiresRefrigeration { get { return false; } }

        public virtual string GetStorageInstructions()
        {
            return "Store in a cool, dry place (" + StorageLocation + ").";
        }

        public bool CanBeStoredAt(string location)
        {
            return !string.IsNullOrWhiteSpace(location);
        }

        // ---------- polymorphism: override ----------
        /// <summary>Virtual so PerishableItem can OVERRIDE it.</summary>
        public virtual string GetItemDetails()
        {
            string nl = Environment.NewLine;
            return "ID           : " + Sku + nl +
                   "Name         : " + Name + nl +
                   "Category     : " + CategoryName + nl +
                   "Type         : " + ItemTypeName + nl +
                   "Quantity     : " + Quantity + " (minimum " + MinimumLevel + ")" + nl +
                   "Unit price   : M " + UnitPrice.ToString("N2") + nl +
                   "Location     : " + StorageLocation;
        }

        // ---------- polymorphism: member hiding ----------
        /// <summary>Non-virtual on purpose: PerishableItem HIDES it with the 'new' keyword.</summary>
        public string Describe()
        {
            return Sku + " - " + Name;
        }

        // ---------- deep copy (Question 2) ----------
        /// <summary>
        /// Deep copy: a brand new object with its own Tags list, so the copy and the original
        /// never share mutable references. (Category / Supplier are shared on purpose - they are
        /// reference data, not part of the item.)
        /// </summary>
        public virtual InventoryItem DeepCopy()
        {
            InventoryItem copy = new InventoryItem();
            CopyBaseTo(copy);
            return copy;
        }

        object ICloneable.Clone()
        {
            return DeepCopy();
        }

        protected void CopyBaseTo(InventoryItem target)
        {
            target.Id = Id;
            target._sku = _sku;
            target._name = _name;
            target._quantity = _quantity;
            target._minimumLevel = _minimumLevel;
            target._unitPrice = _unitPrice;
            target._storageLocation = _storageLocation;
            target._description = _description;
            target.CreatedAt = CreatedAt;
            target.CategoryId = CategoryId;
            target.Category = Category;
            target.SupplierId = SupplierId;
            target.Supplier = Supplier;
            target.Tags = new List<string>(Tags ?? new List<string>());
        }

        /// <summary>Copies the editable values from another item (used to apply an edited copy back).</summary>
        public virtual void CopyValuesFrom(InventoryItem source)
        {
            Name = source.Name;
            Quantity = source.Quantity;
            MinimumLevel = source.MinimumLevel;
            UnitPrice = source.UnitPrice;
            StorageLocation = source.StorageLocation;
            Description = source.Description;
            CategoryId = source.CategoryId;
            SupplierId = source.SupplierId;
            Tags = new List<string>(source.Tags ?? new List<string>());
        }

        // ---------- value comparison (Question 2) ----------
        public bool Equals(InventoryItem other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Sku, other.Sku, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as InventoryItem);
        }

        public override int GetHashCode()
        {
            return (Sku ?? "").ToUpperInvariant().GetHashCode();
        }

        public override string ToString()
        {
            return Sku + " | " + Name + " | qty " + Quantity;
        }
    }
}
