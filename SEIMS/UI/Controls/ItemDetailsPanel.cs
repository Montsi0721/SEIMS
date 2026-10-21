using System.ComponentModel;
using SEIMS.Models;
using SEIMS.Services;

namespace SEIMS.UI.Controls
{
    /// <summary>"Item Details" card on the right of the dashboard (General / Storage / Audit History).
    /// The layout is in ItemDetailsPanel.Designer.cs; this file holds the behaviour.</summary>
    public partial class ItemDetailsPanel : UserControl
    {
        private Label[] _tabs;

        public event Action<InventoryItem> EditClicked;
        public event Action<InventoryItem> DeleteClicked;

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InventoryItem Item { get; private set; }

        public ItemDetailsPanel()
        {
            InitializeComponent();
            DoubleBuffered = true;
            _tabs = new[] { lblTabGeneral, lblTabStorage, lblTabHistory };
            SelectTab(0);
            ShowItem(null, null);
        }

        private void lblTabGeneral_Click(object sender, EventArgs e) { SelectTab(0); }
        private void lblTabStorage_Click(object sender, EventArgs e) { SelectTab(1); }
        private void lblTabHistory_Click(object sender, EventArgs e) { SelectTab(2); }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (EditClicked != null && Item != null) EditClicked(Item);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteClicked != null && Item != null) DeleteClicked(Item);
        }

        private void SelectTab(int index)
        {
            kvGeneral.Visible = index == 0;
            kvStorage.Visible = index == 1;
            lstHistory.Visible = index == 2;
            for (int i = 0; i < _tabs.Length; i++) _tabs[i].ForeColor = i == index ? Theme.Text : Theme.Muted;

            Label sel = _tabs[index];
            panelTabUnderline.Left = sel.Left + 6;
            panelTabUnderline.Width = sel.Width - 12;
        }

        /// <summary>Shows an item (null clears the panel).</summary>
        public void ShowItem(InventoryItem item, IList<AuditLog> history)
        {
            Item = item;
            bool can = item != null;
            btnEdit.Enabled = can && SecurityService.Can(Permission.Edit);
            btnDelete.Enabled = can && SecurityService.Can(Permission.Delete);

            lstHistory.Items.Clear();

            if (item == null)
            {
                lblName.Text = "No item selected";
                lblId.Text = "";
                pillType.Visible = false;
                pillStatus.Visible = false;
                kvGeneral.SetPairs(null);
                kvStorage.SetPairs(null);
                lblDescText.Text = "";
                return;
            }

            PerishableItem perishable = item as PerishableItem;

            lblName.Text = item.Name;
            lblId.Text = "ID: " + item.Sku;
            pillType.Visible = true;
            pillStatus.Visible = true;
            pillType.SetTypeText(item.ItemTypeName, perishable != null);
            pillStatus.SetStatus(item.Status, item.StatusText);
            tileThumb.GlyphColor = perishable != null ? Theme.GreenText : Theme.Accent;

            kvGeneral.SetPairs(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Name", item.Name),
                new KeyValuePair<string, string>("Category", item.CategoryName),
                new KeyValuePair<string, string>("Type", item.ItemTypeName),
                new KeyValuePair<string, string>("Quantity", item.Quantity.ToString()),
                new KeyValuePair<string, string>("Minimum Level", item.MinimumLevel.ToString()),
                new KeyValuePair<string, string>("Unit Price", InputSanitizer.Money(item.UnitPrice)),
                new KeyValuePair<string, string>("Expiry Date", perishable != null ? perishable.ExpiryDate.ToString("yyyy-MM-dd") : "N/A"),
                new KeyValuePair<string, string>("Location", item.StorageLocation)
            });

            kvStorage.SetPairs(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Location", item.StorageLocation),
                new KeyValuePair<string, string>("Refrigeration", item.RequiresRefrigeration ? "Required" : "Not required"),
                new KeyValuePair<string, string>("Safe Temperature", perishable != null ? perishable.MinStorageTempC + "\u00B0C to " + perishable.MaxStorageTempC + "\u00B0C" : "Ambient"),
                new KeyValuePair<string, string>("Days To Expiry", perishable != null ? perishable.DaysToExpiry.ToString() : "N/A"),
                new KeyValuePair<string, string>("Supplier", item.Supplier != null ? item.Supplier.Name : "(none)"),
                new KeyValuePair<string, string>("Stock Value", InputSanitizer.Money(item.TotalValue))
            });

            lblDescText.Text = item.Description.Length > 0 ? item.Description : item.GetStorageInstructions();

            if (history != null)
            {
                foreach (AuditLog log in history)
                    lstHistory.Items.Add(log.Timestamp.ToString("yyyy-MM-dd HH:mm") + "  " + log.Action + "  by " + log.Username);
                if (history.Count == 0) lstHistory.Items.Add("No recorded activity yet.");
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(Theme.Border))
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }
    }
}
