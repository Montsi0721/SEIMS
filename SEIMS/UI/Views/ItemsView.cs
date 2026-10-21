using SEIMS.Services;
using SEIMS.UI.Controls;

namespace SEIMS.UI.Views
{
    /// <summary>"View Items": full-width inventory list with search, filter and an expiry date filter.</summary>
    public partial class ItemsView : UserControl, IReloadable
    {
        private InventoryService _svc;

        public ItemsView()
        {
            InitializeComponent();
        }

        public void Initialize(InventoryService svc)
        {
            _svc = svc;
        }

        public ItemsGridPanel Grid { get { return itemsGrid; } }

        public void Reload()
        {
            if (_svc == null) return;
            itemsGrid.SetItems(_svc.Warehouse.ToList());
        }
    }
}
