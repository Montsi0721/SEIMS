using System.Collections.Generic;

namespace SEIMS.Models
{
    /// <summary>
    /// Supplier. Explicit ONE-TO-MANY relationship (Question 8): one Supplier has many InventoryItems.
    /// </summary>
    public class Supplier
    {
        public Supplier()
        {
            Items = new List<InventoryItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string Phone { get; set; }
        public ICollection<InventoryItem> Items { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
