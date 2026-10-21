using System.Collections.Generic;

namespace SEIMS.Models
{
    /// <summary>Product category (Electronics, Furniture ...). One category has many items.</summary>
    public class Category
    {
        public Category()
        {
            Items = new List<InventoryItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<InventoryItem> Items { get; set; }
    }
}
