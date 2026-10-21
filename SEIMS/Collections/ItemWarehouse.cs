using System.Collections;
using SEIMS.Models;

namespace SEIMS.Collections
{
    /// <summary>Delegate for the critical-stock event (Question 4).</summary>
    public delegate void StockCriticalHandler(InventoryItem item, int quantity);

    public class DuplicateItemException : Exception
    {
        public string Sku { get; private set; }

        public DuplicateItemException(string sku)
            : base("An item with SKU '" + sku + "' already exists.")
        {
            Sku = sku;
        }
    }

    /// <summary>
    /// Custom collection (Question 3): string indexer, custom iterator (yield return)
    /// and the OnStockThresholdCritical event (Question 4).
    /// </summary>
    public class ItemWarehouse : IEnumerable<InventoryItem>
    {
        private readonly List<InventoryItem> _items = new List<InventoryItem>();

        /// <summary>Fires when an item's stock falls below InventoryItem.CriticalThreshold (5 units).</summary>
        public event StockCriticalHandler OnStockThresholdCritical;

        public int Count { get { return _items.Count; } }

        // ---------- custom indexer: warehouse["ITM-002"] ----------
        public InventoryItem this[string sku]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(sku)) return null;
                string key = sku.Trim();
                foreach (InventoryItem item in _items)
                {
                    if (string.Equals(item.Sku, key, StringComparison.OrdinalIgnoreCase))
                        return item;
                }
                return null;
            }
        }

        // second indexer: warehouse[0]
        public InventoryItem this[int index]
        {
            get { return _items[index]; }
        }

        public bool Contains(InventoryItem item)
        {
            return _items.Contains(item); // uses InventoryItem.Equals (value comparison on SKU)
        }

        public void Add(InventoryItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (Contains(item)) throw new DuplicateItemException(item.Sku);
            _items.Add(item);
        }

        public bool Remove(InventoryItem item)
        {
            return _items.Remove(item);
        }

        /// <summary>Replaces the contents (used when reloading from the database).</summary>
        public void Load(IEnumerable<InventoryItem> items)
        {
            _items.Clear();
            foreach (InventoryItem item in items)
            {
                if (!_items.Contains(item)) _items.Add(item);
            }
        }

        // ---------- custom iterator (yield return) ----------
        public IEnumerable<InventoryItem> ItemsInCategory(string categoryName)
        {
            foreach (InventoryItem item in _items)
            {
                if (string.Equals(item.CategoryName, categoryName, StringComparison.OrdinalIgnoreCase))
                    yield return item;
            }
        }

        public IEnumerator<InventoryItem> GetEnumerator()
        {
            foreach (InventoryItem item in _items)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // ---------- stock changes + event ----------
        public void AdjustQuantity(InventoryItem item, int newQuantity)
        {
            item.Quantity = newQuantity;
            NotifyIfCritical(item);
        }

        public void NotifyIfCritical(InventoryItem item)
        {
            if (item.Quantity < InventoryItem.CriticalThreshold)
            {
                StockCriticalHandler handler = OnStockThresholdCritical;
                if (handler != null) handler(item, item.Quantity);
            }
        }
    }
}
