using System.ComponentModel;
using System.Drawing.Drawing2D;
using SEIMS.Models;
using SEIMS.Services;

namespace SEIMS.UI.Controls
{
    /// <summary>
    /// "Recent Inventory Items" card: search, filter, DataGridView with coloured status pills,
    /// action icons and a pager. Layout lives in ItemsGridPanel.Designer.cs (open it in the Forms Designer);
    /// this file holds the behaviour. Used on the dashboard and on the Inventory page.
    /// </summary>
    public partial class ItemsGridPanel : UserControl
    {
        private List<InventoryItem> _all = new List<InventoryItem>();
        private List<InventoryItem> _filtered = new List<InventoryItem>();
        private int _page = 1;
        private string _statusFilter = "All";
        private bool _binding;
        private bool _showDateFilter;

        public event Action<InventoryItem> SelectedItemChanged;
        public event Action<InventoryItem> ViewRequested;
        public event Action<InventoryItem> EditRequested;
        public event Action<InventoryItem> DeleteRequested;

        public ItemsGridPanel()
        {
            InitializeComponent();
            PageSize = 10;
            DoubleBuffered = true;
            filterMenu.Renderer = new DarkRenderer();
            dtpExpiry.Value = DateTime.Today.AddDays(30);
        }

        [Category("SEIMS"), DefaultValue(10)]
        public int PageSize { get; set; }

        [Category("SEIMS"), DefaultValue("Recent Inventory Items")]
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        [Category("SEIMS"), DefaultValue(false)]
        public bool ShowDateFilter
        {
            get { return _showDateFilter; }
            set { _showDateFilter = value; chkExpiry.Visible = value; dtpExpiry.Visible = value; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InventoryItem SelectedItem { get; private set; }

        private int S(int px)
        {
            return Theme.Scale(this, px);
        }

        // ------------------------------------------------------------------ designer event handlers
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(true);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            filterMenu.Show(btnFilter, new Point(0, btnFilter.Height));
        }

        private void filterMenu_Opening(object sender, CancelEventArgs e)
        {
            foreach (ToolStripItem it in filterMenu.Items)
            {
                ToolStripMenuItem mi = it as ToolStripMenuItem;
                if (mi != null) mi.Checked = mi.Text == _statusFilter;
            }
        }

        private void filterItem_Click(object sender, EventArgs e)
        {
            _statusFilter = ((ToolStripMenuItem)sender).Text;
            ApplyFilter(true);
        }

        private void chkExpiry_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter(true);
        }

        private void dtpExpiry_ValueChanged(object sender, EventArgs e)
        {
            if (chkExpiry.Checked) ApplyFilter(true);
        }

        private void gridItems_SelectionChanged(object sender, EventArgs e)
        {
            SyncSelection();
        }

        private void gridItems_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            gridItems.Cursor = (e.RowIndex >= 0 && e.ColumnIndex == 6) ? Cursors.Hand : Cursors.Default;
        }

        private void gridItems_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            gridItems.Cursor = Cursors.Default;
        }

        private void gridItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ViewRequested != null) ViewRequested(RowItem(e.RowIndex));
        }

        // ------------------------------------------------------------------ data
        public void SetItems(IEnumerable<InventoryItem> items)
        {
            _all = items.ToList();
            ApplyFilter(false);
        }

        private void ApplyFilter(bool resetPage)
        {
            string q = InputSanitizer.CleanText(txtSearch.Text, 60);
            IEnumerable<InventoryItem> source = _all;

            if (q.Length > 0)
            {
                source = source.Where(i =>
                    i.Sku.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    i.Name.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    i.CategoryName.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            switch (_statusFilter)
            {
                case "In Stock": source = source.Where(i => i.Status == StockStatus.InStock); break;
                case "Low Stock": source = source.Where(i => i.Status == StockStatus.LowStock); break;
                case "Very Low": source = source.Where(i => i.Status == StockStatus.VeryLow); break;
                case "Perishable": source = source.Where(i => i is PerishableItem); break;
                case "Regular": source = source.Where(i => !(i is PerishableItem)); break;
            }

            if (ShowDateFilter && chkExpiry.Checked)
            {
                DateTime limit = dtpExpiry.Value.Date;
                source = source.OfType<PerishableItem>().Where(p => p.ExpiryDate.Date <= limit).Cast<InventoryItem>();
            }

            _filtered = source.ToList();
            if (resetPage) _page = 1;
            BindPage();
        }

        private void BindPage()
        {
            int total = _filtered.Count;
            int pages = Math.Max(1, (int)Math.Ceiling(total / (double)PageSize));
            if (_page > pages) _page = pages;
            if (_page < 1) _page = 1;

            List<InventoryItem> pageItems = _filtered.Skip((_page - 1) * PageSize).Take(PageSize).ToList();
            string keep = SelectedItem != null ? SelectedItem.Sku : null;

            _binding = true;
            gridItems.Rows.Clear();
            foreach (InventoryItem it in pageItems)
            {
                int idx = gridItems.Rows.Add(it.Sku, it.Name, it.CategoryName, it.ItemTypeName, it.Quantity, it.StatusText, "");
                gridItems.Rows[idx].Tag = it;
            }

            gridItems.ClearSelection();
            DataGridViewRow target = null;
            foreach (DataGridViewRow row in gridItems.Rows)
            {
                InventoryItem ri = row.Tag as InventoryItem;
                if (keep != null && ri != null && ri.Sku == keep) { target = row; break; }
            }
            if (target == null && gridItems.Rows.Count > 0) target = gridItems.Rows[0];
            if (target != null)
            {
                target.Selected = true;
                gridItems.CurrentCell = target.Cells[1];
            }
            _binding = false;

            SyncSelection();

            if (total == 0)
                lblShowing.Text = "No items found";
            else
                lblShowing.Text = "Showing " + ((_page - 1) * PageSize + 1) + " - " +
                                  Math.Min(_page * PageSize, total) + " of " + total + " items";

            BuildPager(pages);
        }

        public void SelectSku(string sku)
        {
            foreach (DataGridViewRow row in gridItems.Rows)
            {
                InventoryItem it = row.Tag as InventoryItem;
                if (it != null && it.Sku == sku) { row.Selected = true; gridItems.CurrentCell = row.Cells[1]; return; }
            }
        }

        private InventoryItem RowItem(int rowIndex)
        {
            return gridItems.Rows[rowIndex].Tag as InventoryItem;
        }

        private void SyncSelection()
        {
            if (_binding) return;
            InventoryItem now = null;
            if (gridItems.SelectedRows.Count > 0) now = gridItems.SelectedRows[0].Tag as InventoryItem;
            SelectedItem = now;
            if (SelectedItemChanged != null) SelectedItemChanged(now);
        }

        // ------------------------------------------------------------------ pager (built from the data, not in the designer)
        private void BuildPager(int pages)
        {
            flowPager.SuspendLayout();
            foreach (Control c in flowPager.Controls.Cast<Control>().ToList()) { flowPager.Controls.Remove(c); c.Dispose(); }

            flowPager.Controls.Add(MakePageButton("\u2039", false, _page > 1, () => { _page--; BindPage(); }));

            var numbers = new SortedSet<int> { 1, pages, _page - 1, _page, _page + 1 };
            if (_page <= 3) for (int n = 1; n <= 5; n++) numbers.Add(n);
            int previous = 0;
            foreach (int n in numbers.Where(n => n >= 1 && n <= pages))
            {
                if (previous != 0 && n - previous > 1)
                {
                    var dots = new Label { Text = "...", AutoSize = false, Width = 30, Height = 34, ForeColor = Theme.Muted, TextAlign = ContentAlignment.MiddleCenter, Margin = new Padding(2, 0, 2, 0) };
                    flowPager.Controls.Add(dots);
                }
                int target = n;
                flowPager.Controls.Add(MakePageButton(n.ToString(), n == _page, true, () => { _page = target; BindPage(); }));
                previous = n;
            }

            flowPager.Controls.Add(MakePageButton("\u203A", false, _page < pages, () => { _page++; BindPage(); }));
            flowPager.ResumeLayout();
        }

        private Button MakePageButton(string text, bool current, bool enabled, Action click)
        {
            var b = new Button();
            b.Text = text;
            b.Size = new Size(34, 34);
            b.Margin = new Padding(3, 0, 3, 0);
            Theme.StyleButton(b, current ? Theme.Selected : Theme.Panel2, enabled ? Theme.Text : Theme.Muted,
                current ? Theme.Accent : Theme.Border);
            b.Enabled = enabled;
            b.Click += (s, e) => click();
            return b;
        }

        // ------------------------------------------------------------------ cell painting
        private static Color CategoryColor(string category)
        {
            switch (category)
            {
                case "Electronics": return Color.FromArgb(59, 130, 246);
                case "Food & Beverages": return Color.FromArgb(34, 160, 90);
                case "Furniture": return Color.FromArgb(150, 90, 230);
                case "Office Supplies": return Color.FromArgb(217, 140, 20);
                default: return Color.FromArgb(100, 110, 125);
            }
        }

        private void gridItems_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex != 0 && e.ColumnIndex != 5 && e.ColumnIndex != 6) return;
            InventoryItem item = RowItem(e.RowIndex);
            if (item == null) return;

            e.Paint(e.ClipBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.SelectionBackground);

            Graphics g = e.Graphics;
            Rectangle cell = e.CellBounds;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int d = S(26);

            if (e.ColumnIndex == 0)
            {
                Rectangle dot = new Rectangle(cell.X + S(8), cell.Y + (cell.Height - d) / 2, d, d);
                using (var b = new SolidBrush(CategoryColor(item.CategoryName))) g.FillEllipse(b, dot);
                string initial = item.CategoryName.Length > 0 ? item.CategoryName.Substring(0, 1) : "?";
                TextRenderer.DrawText(g, initial, Theme.SmallBold, dot, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
                TextRenderer.DrawText(g, item.Sku, Theme.Body,
                    new Rectangle(cell.X + S(44), cell.Y, cell.Width - S(44), cell.Height), Theme.Text,
                    TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPadding);
            }
            else if (e.ColumnIndex == 5)
            {
                Color fill;
                switch (item.Status)
                {
                    case StockStatus.VeryLow: fill = Theme.Red; break;
                    case StockStatus.LowStock: fill = Theme.Orange; break;
                    default: fill = Theme.Green; break;
                }
                Size text = TextRenderer.MeasureText(item.StatusText, Theme.SmallBold);
                Rectangle pill = new Rectangle(cell.X + S(8), cell.Y + (cell.Height - d) / 2, text.Width + S(22), d);
                using (GraphicsPath path = Theme.RoundedPath(pill, d / 2))
                using (var b = new SolidBrush(fill))
                    g.FillPath(b, path);
                TextRenderer.DrawText(g, item.StatusText, Theme.SmallBold, pill, Color.White,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }
            else
            {
                string[] glyphs = { Icons.View, Icons.Edit, Icons.Delete };
                Color[] colors =
                {
                    Theme.Accent,
                    SecurityService.Can(Permission.Edit) ? Theme.Accent : Theme.Muted,
                    SecurityService.Can(Permission.Delete) ? Color.FromArgb(239, 68, 68) : Theme.Muted
                };
                for (int k = 0; k < 3; k++)
                {
                    TextRenderer.DrawText(g, glyphs[k], Theme.IconM,
                        new Rectangle(cell.X + S(12) + k * S(34), cell.Y, S(28), cell.Height), colors[k],
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
                }
            }

            e.Handled = true;
        }

        private void gridItems_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || e.RowIndex < 0 || e.ColumnIndex != 6) return;

            int rel = e.X - S(12);
            if (rel < 0) return;
            int k = rel / S(34);
            if (k > 2 || rel % S(34) > S(28)) return;

            InventoryItem item = RowItem(e.RowIndex);
            if (item == null) return;

            gridItems.Rows[e.RowIndex].Selected = true;
            if (k == 0 && ViewRequested != null) ViewRequested(item);
            else if (k == 1 && EditRequested != null) EditRequested(item);
            else if (k == 2 && DeleteRequested != null) DeleteRequested(item);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(Theme.Border))
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }
    }
}
