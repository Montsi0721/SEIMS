using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace SEIMS.Models
{
    public enum StockStatus
    {
        InStock = 0,
        LowStock = 1,
        VeryLow = 2
    }

    /// <summary>
    /// InventoryItem - PART 1 of 2 (partial class, Question 1).
    /// This file holds the DATA: fields, encapsulated properties and the
    /// constructor / destructor tracking system.
    /// Part 2 (InventoryItem.Behavior.cs) holds the behaviour.
    /// </summary>
    public partial class InventoryItem
    {
        /// <summary>Stock below this many units is "critical" (Question 4 event threshold).</summary>
        public const int CriticalThreshold = 5;

        // ---------- constructor / destructor tracking system ----------
        private static int _totalCreated;
        private static int _activeInstances;

        public static int TotalCreated { get { return _totalCreated; } }
        public static int ActiveInstances { get { return _activeInstances; } }

        // ---------- private fields (encapsulation) ----------
        private string _sku;
        private string _name;
        private int _quantity;
        private int _minimumLevel;
        private decimal _unitPrice;
        private string _storageLocation;
        private string _description;

        /// <summary>Used by Entity Framework and by DeepCopy.</summary>
        protected InventoryItem()
        {
            _sku = "";
            _name = "";
            _storageLocation = "";
            _description = "";
            CreatedAt = DateTime.Now;
            Tags = new List<string>();
            Interlocked.Increment(ref _totalCreated);
            Interlocked.Increment(ref _activeInstances);
        }

        public InventoryItem(string sku, string name, int categoryId, int quantity,
                             int minimumLevel, decimal unitPrice, string storageLocation)
            : this()
        {
            Sku = sku;
            Name = name;
            CategoryId = categoryId;
            Quantity = quantity;
            MinimumLevel = minimumLevel;
            UnitPrice = unitPrice;
            StorageLocation = storageLocation;
        }

        /// <summary>Destructor (finaliser): keeps the live-instance counter honest.</summary>
        ~InventoryItem()
        {
            Interlocked.Decrement(ref _activeInstances);
            Debug.WriteLine("[InventoryItem] finalised " + _sku + " | active instances = " + _activeInstances);
        }

        // ---------- public properties with validation ----------
        public int Id { get; set; }

        public string Sku
        {
            get { return _sku; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("SKU is required.");
                string v = value.Trim().ToUpperInvariant();
                if (v.Length > 30)
                    throw new ArgumentException("SKU may not be longer than 30 characters.");
                _sku = v;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Item name is required.");
                string v = value.Trim();
                if (v.Length > 100)
                    throw new ArgumentException("Item name may not be longer than 100 characters.");
                _name = v;
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity cannot be negative.");
                _quantity = value;
            }
        }

        public int MinimumLevel
        {
            get { return _minimumLevel; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Minimum level cannot be negative.");
                _minimumLevel = value;
            }
        }

        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Unit price cannot be negative.");
                _unitPrice = value;
            }
        }

        public string StorageLocation
        {
            get { return _storageLocation; }
            set { _storageLocation = (value ?? "").Trim(); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = (value ?? "").Trim(); }
        }

        public DateTime CreatedAt { get; set; }

        // ---------- relationships ----------
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        /// <summary>Free-form tags. Not stored in the database - exists to prove DeepCopy works.</summary>
        public List<string> Tags { get; set; }
    }
}
