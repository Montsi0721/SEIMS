using SEIMS.Models;
using SEIMS.Services;
using SEIMS.UI.Controls;

namespace SEIMS.UI.Views
{
    /// <summary>The dashboard from the design: four summary cards, recent items grid and item details.
    /// Open DashboardView.Designer.cs in the Forms Designer to move / resize anything.</summary>
    public partial class DashboardView : UserControl, IReloadable
    {
        private InventoryService _svc;

        public DashboardView()
        {
            InitializeComponent();
            itemsGrid.SelectedItemChanged += OnSelectedChanged;
        }

        public void Initialize(InventoryService svc)
        {
            _svc = svc;
        }

        public ItemsGridPanel Grid { get { return itemsGrid; } }
        public ItemDetailsPanel Details { get { return itemDetails; } }

        public void Reload()
        {
            if (_svc == null) return;
            DashboardStats stats = _svc.GetStats();
            cardTotal.SetValue(stats.TotalItems.ToString());
            cardLow.SetValue(stats.LowStock.ToString());
            cardPerishable.SetValue(stats.ExpiringSoon.ToString());
            cardAudit.SetValue(stats.AuditRecords.ToString());
            itemsGrid.SetItems(_svc.Warehouse.ToList());
        }

        private void OnSelectedChanged(InventoryItem item)
        {
            if (_svc == null) return;
            List<AuditLog> history = null;
            if (item != null)
            {
                try { history = _svc.GetItemHistory(item.Sku); }
                catch (Exception) { history = new List<AuditLog>(); }
            }
            itemDetails.ShowItem(item, history);
        }
    }
}
