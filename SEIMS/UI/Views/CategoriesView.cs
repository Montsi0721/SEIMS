using SEIMS.Models;
using SEIMS.Services;

namespace SEIMS.UI.Views
{
    /// <summary>TreeView of categories and the items inside them (uses the warehouse iterator).</summary>
    public partial class CategoriesView : UserControl, IReloadable
    {
        private InventoryService _svc;

        public CategoriesView()
        {
            InitializeComponent();
        }

        public void Initialize(InventoryService svc)
        {
            _svc = svc;
        }

        public void Reload()
        {
            if (_svc == null) return;
            treeCategories.BeginUpdate();
            treeCategories.Nodes.Clear();
            TreeNode root = treeCategories.Nodes.Add("All categories (" + _svc.Warehouse.Count + " items)");
            foreach (Category cat in _svc.Categories)
            {
                List<InventoryItem> items = _svc.Warehouse.ItemsInCategory(cat.Name).ToList();   // custom iterator
                TreeNode node = root.Nodes.Add(cat.Name + " (" + items.Count + ")");
                node.Tag = cat;
                foreach (InventoryItem item in items)
                {
                    TreeNode child = node.Nodes.Add(item.Sku + "   " + item.Name);
                    child.Tag = item;
                }
            }
            root.Expand();
            treeCategories.EndUpdate();
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            treeCategories.ExpandAll();
        }

        private void btnCollapse_Click(object sender, EventArgs e)
        {
            treeCategories.CollapseAll();
            if (treeCategories.Nodes.Count > 0) treeCategories.Nodes[0].Expand();
        }

        private void treeCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_svc == null) return;
            string nl = Environment.NewLine;
            InventoryItem item = e.Node.Tag as InventoryItem;
            Category cat = e.Node.Tag as Category;

            if (item != null)
            {
                txtDetail.Text = item.GetItemDetails() + nl + nl + "Handling      : " + item.GetStorageInstructions() +
                                 nl + "Stock status  : " + item.StatusText;
            }
            else if (cat != null)
            {
                List<InventoryItem> items = _svc.Warehouse.ItemsInCategory(cat.Name).ToList();
                txtDetail.Text = "Category      : " + cat.Name + nl +
                                 "Description   : " + cat.Description + nl + nl +
                                 "Items         : " + items.Count + nl +
                                 "Total units   : " + items.Sum(i => i.Quantity) + nl +
                                 "Stock value   : " + InputSanitizer.Money(items.Sum(i => i.TotalValue)) + nl +
                                 "Low / very low: " + items.Count(i => i.Status != StockStatus.InStock);
            }
            else
            {
                txtDetail.Text = "Select a category or an item to see its details.";
            }
        }
    }
}
