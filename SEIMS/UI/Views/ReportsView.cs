using SEIMS.Models;
using SEIMS.Services;

namespace SEIMS.UI.Views
{
    /// <summary>LINQ reports (query syntax and method syntax), XML export and secure printing.</summary>
    public partial class ReportsView : UserControl, IReloadable
    {
        public const int AuditReportIndex = 8;

        private InventoryService _svc;
        private bool _ready;

        public ReportsView()
        {
            InitializeComponent();
            cmbReport.SelectedIndex = 0;
            _ready = true;
        }

        public void Initialize(InventoryService svc)
        {
            _svc = svc;
        }

        private void cmbReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_ready) Reload();
        }

        private void btnRun_Click(object sender, EventArgs e) { Reload(); }
        private void btnExportXml_Click(object sender, EventArgs e) { ExportXml(); }
        private void btnPrint_Click(object sender, EventArgs e) { PrintReport(); }

        public void SelectReport(int index)
        {
            if (index >= 0 && index < cmbReport.Items.Count) cmbReport.SelectedIndex = index;
            Reload();
        }

        public void Reload()
        {
            if (_svc == null) return;
            ReportEngine engine = _svc.CreateReportEngine();
            lblSummary.Text = "Total asset value (query): " + InputSanitizer.Money(engine.TotalAssetValueQuerySyntax()) +
                              "    (method): " + InputSanitizer.Money(engine.TotalAssetValueMethodSyntax()) +
                              "    Average unit price: " + InputSanitizer.Money(engine.AverageUnitPrice()) +
                              "    Items: " + _svc.Warehouse.Count;

            object data;
            switch (cmbReport.SelectedIndex)
            {
                case 0: data = engine.TopByStockValueQuerySyntax(15); break;
                case 1: data = engine.TopByStockValueMethodSyntax(15); break;
                case 2: data = engine.ByCategoryQuerySyntax(); break;
                case 3: data = engine.ByCategoryMethodSyntax(); break;
                case 4: data = engine.SupplierCategoryQuerySyntax(); break;
                case 5: data = engine.SupplierCategoryMethodSyntax(); break;
                case 6: data = engine.LowStock(); break;
                case 7: data = engine.ExpiringSoon(); break;
                default: data = _svc.GetAuditSummary(); break;
            }

            gridReport.DataSource = data;
            foreach (DataGridViewColumn col in gridReport.Columns)
            {
                if (col.ValueType == typeof(decimal))
                {
                    col.DefaultCellStyle.Format = "N2";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (col.ValueType == typeof(DateTime))
                {
                    col.DefaultCellStyle.Format = col.Name == "ExpiryDate" ? "yyyy-MM-dd" : "yyyy-MM-dd HH:mm";
                }
            }
        }

        public void ExportXml()
        {
            if (!SecurityService.Can(Permission.Export))
            {
                MessageBox.Show(FindForm(), "Your role is not allowed to export data.", "Access denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "XML file (*.xml)|*.xml";
                dialog.FileName = "SEIMS_Inventory_" + DateTime.Now.ToString("yyyyMMdd") + ".xml";
                if (dialog.ShowDialog(FindForm()) != DialogResult.OK) return;

                try
                {
                    string tracking = _svc.ExportXml(dialog.FileName);
                    MessageBox.Show(FindForm(), "Export complete.\nTracking number: " + tracking, "SEIMS",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(FindForm(), ex.Message, "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(FindForm(), "Could not write the file:\n" + ex.Message, "Export failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(FindForm(), "Export failed:\n" + ex.Message, "Export failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void PrintReport()
        {
            if (!SecurityService.Can(Permission.Print))
            {
                MessageBox.Show(FindForm(), "Your role is not allowed to print.", "Access denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // financial columns are hidden on paper unless the user is an Admin
            var financial = new HashSet<string> { "UnitPrice", "TotalValue", "AverageUnitPrice" };
            bool full = SecurityService.CurrentRole == UserRole.Admin;
            var lines = new List<string>();

            var header = new List<string>();
            foreach (DataGridViewColumn col in gridReport.Columns) header.Add(Pad(col.HeaderText));
            lines.Add(string.Join(" ", header));
            lines.Add(new string('-', Math.Min(110, header.Count * 19)));

            foreach (DataGridViewRow row in gridReport.Rows)
            {
                var cells = new List<string>();
                foreach (DataGridViewColumn col in gridReport.Columns)
                {
                    object shown = row.Cells[col.Index].FormattedValue;
                    string text = (!full && financial.Contains(col.Name)) ? "***" : (shown == null ? "" : shown.ToString());
                    cells.Add(Pad(text));
                }
                lines.Add(string.Join(" ", cells));
            }

            try
            {
                SecurePrinter.ShowPreview(FindForm(), cmbReport.Text, lines,
                    msg => _svc.Audit("PRINT", "Report", cmbReport.SelectedIndex.ToString(), msg));
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(FindForm(), ex.Message, "Access denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static string Pad(string text)
        {
            text = InputSanitizer.StripControl(text);
            if (text.Length > 18) text = text.Substring(0, 18);
            return text.PadRight(18);
        }
    }
}
