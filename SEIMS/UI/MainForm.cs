using System.Globalization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SEIMS.Collections;
using SEIMS.Events;
using SEIMS.Models;
using SEIMS.Services;
using SEIMS.UI.Controls;
using SEIMS.UI.Views;

namespace SEIMS.UI
{
    public partial class MainForm : Form
    {
        private readonly InventoryService _svc;
        private readonly FileLogger _logger;
        private readonly NotificationService _notifier;

        private readonly DashboardView _dashboard;
        private readonly ItemsView _items;
        private readonly CategoriesView _categories;
        private readonly AuditLogsView _audit;
        private readonly ReportsView _reports;
        private readonly SettingsView _settings;
        private readonly List<UserControl> _views = new List<UserControl>();
        private readonly List<NavButton> _allNav = new List<NavButton>();

        private string _current = "dashboard";
        private bool _suppressAlerts;

        public bool LogoutRequested { get; private set; }

        public MainForm(InventoryService svc, FileLogger logger)
        {
            _svc = svc;
            _logger = logger;
            InitializeComponent();

            // the dark menu / toolbar / status bar renderer is applied in code (the designer cannot store a renderer)
            Theme.ApplyToolStrip(menuStrip);
            Theme.ApplyToolStrip(toolStrip);
            Theme.ApplyToolStrip(statusStrip);

            // every page is its own UserControl with its own designer file
            _dashboard = new DashboardView();
            _items = new ItemsView();
            _categories = new CategoriesView();
            _audit = new AuditLogsView();
            _reports = new ReportsView();
            _settings = new SettingsView();
            _dashboard.Initialize(_svc);
            _items.Initialize(_svc);
            _categories.Initialize(_svc);
            _audit.Initialize(_svc, _logger);
            _reports.Initialize(_svc);
            _settings.Initialize(_svc, _logger);

            _views.AddRange(new UserControl[] { _dashboard, _items, _categories, _audit, _reports, _settings });
            foreach (UserControl v in _views)
            {
                v.Dock = DockStyle.Fill;
                v.Visible = false;
                viewHost.Controls.Add(v);
            }

            _allNav.AddRange(new[] { navDashboard, navInventory, navAddItem, navViewItems, navCategories,
                                     navAudit, navViewLogs, navGenReport, navReports, navSettings });

            WireViewEvents();
            ApplyPermissions();

            stsUser.Text = "User: " + SecurityService.CurrentUsername + " (" + SecurityService.CurrentRole + ")   |";
            stsVersion.Text = "SEIMS v" + AppConfig.Version + "   |   Secure \u2022 Reliable \u2022 Efficient";
            mnuUser.Text = SecurityService.CurrentUsername;
            UpdateClock();

            // Question 4: the notification class subscribes to OnStockThresholdCritical
            _notifier = new NotificationService(_svc.Warehouse, _logger.AsHandler(), ShowCriticalAlert);

            ShowView("dashboard");
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            NativeMethods.UseDarkTitleBar(Handle);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _notifier.Dispose();
            base.OnFormClosed(e);
        }

        // ------------------------------------------------------------------ wiring
        // Menu, toolbar, sidebar and timer handlers are connected in MainForm.Designer.cs.
        // Only the events of the page controls (created at run time) are connected here.
        private void WireViewEvents()
        {
            foreach (ItemsGridPanel grid in new[] { _dashboard.Grid, _items.Grid })
            {
                grid.ViewRequested += ViewItem;
                grid.EditRequested += EditItem;
                grid.DeleteRequested += DeleteItem;
            }
            _dashboard.Details.EditClicked += EditItem;
            _dashboard.Details.DeleteClicked += DeleteItem;
        }

        private void clockTimer_Tick(object sender, EventArgs e) { UpdateClock(); }

        private void navDashboard_Click(object sender, EventArgs e) { ShowView("dashboard"); }
        private void navInventory_Click(object sender, EventArgs e) { ToggleGroup(navInventory, navAddItem, navViewItems, navCategories); }
        private void navAddItem_Click(object sender, EventArgs e) { AddItem(); }
        private void navViewItems_Click(object sender, EventArgs e) { ShowView("items"); }
        private void navCategories_Click(object sender, EventArgs e) { ShowView("categories"); }
        private void navAudit_Click(object sender, EventArgs e) { ToggleGroup(navAudit, navViewLogs, navGenReport); }
        private void navViewLogs_Click(object sender, EventArgs e) { ShowView("audit"); }
        private void navGenReport_Click(object sender, EventArgs e) { ShowAuditReport(); }
        private void navReports_Click(object sender, EventArgs e) { ShowView("reports"); }
        private void navSettings_Click(object sender, EventArgs e) { ShowView("settings"); }
        private void navLogout_Click(object sender, EventArgs e) { Logout(); }

        private void mnuImport_Click(object sender, EventArgs e) { ImportCsv(); }
        private void mnuExport_Click(object sender, EventArgs e) { _reports.ExportXml(); }
        private void mnuPrint_Click(object sender, EventArgs e) { PrintInventory(); }
        private void mnuLogout_Click(object sender, EventArgs e) { Logout(); }
        private void mnuUserLogout_Click(object sender, EventArgs e) { Logout(); }
        private void mnuExit_Click(object sender, EventArgs e) { Close(); }
        private void mnuAddItem_Click(object sender, EventArgs e) { AddItem(); }
        private void mnuEditItem_Click(object sender, EventArgs e) { EditItem(SelectedItem()); }
        private void mnuDeleteItem_Click(object sender, EventArgs e) { DeleteItem(SelectedItem()); }
        private void mnuRefresh_Click(object sender, EventArgs e) { RefreshFromDatabase(); }
        private void mnuViewLogs_Click(object sender, EventArgs e) { ShowView("audit"); }
        private void mnuGenReport_Click(object sender, EventArgs e) { ShowAuditReport(); }
        private void mnuReports_Click(object sender, EventArgs e) { ShowView("reports"); }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
                "SEIMS v" + AppConfig.Version + "\nSecure Enterprise Inventory & Audit Management System\n\nProgramming using .Net 1 - C7-PN1-11",
                "About SEIMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsAdd_Click(object sender, EventArgs e) { AddItem(); }
        private void tsEdit_Click(object sender, EventArgs e) { EditItem(SelectedItem()); }
        private void tsDelete_Click(object sender, EventArgs e) { DeleteItem(SelectedItem()); }
        private void tsRefresh_Click(object sender, EventArgs e) { RefreshFromDatabase(); }
        private void tsPrint_Click(object sender, EventArgs e) { PrintInventory(); }
        private void tsExport_Click(object sender, EventArgs e) { _reports.ExportXml(); }

        private void ShowAuditReport()
        {
            ShowView("reports");
            _reports.SelectReport(ReportsView.AuditReportIndex);
        }

        private void ApplyPermissions()
        {
            bool edit = SecurityService.Can(Permission.Edit);
            bool delete = SecurityService.Can(Permission.Delete);
            bool print = SecurityService.Can(Permission.Print);
            bool export = SecurityService.Can(Permission.Export);

            mnuAddItem.Enabled = tsAdd.Enabled = navAddItem.Enabled = edit;
            mnuEditItem.Enabled = tsEdit.Enabled = edit;
            mnuDeleteItem.Enabled = tsDelete.Enabled = delete;
            mnuImport.Enabled = SecurityService.Can(Permission.Import);
            mnuPrint.Enabled = tsPrint.Enabled = print;
            mnuExport.Enabled = tsExport.Enabled = export;
        }

        private void ShowView(string key)
        {
            UserControl view;
            NavButton nav;
            string title, subtitle, glyph;

            switch (key)
            {
                case "items":
                    view = _items; nav = navViewItems; glyph = Icons.Package;
                    title = "Inventory"; subtitle = "Browse, search and manage every stock item";
                    SetGroup(navInventory, true, navAddItem, navViewItems, navCategories);
                    break;
                case "categories":
                    view = _categories; nav = navCategories; glyph = Icons.Package;
                    title = "Categories"; subtitle = "Items grouped by category";
                    SetGroup(navInventory, true, navAddItem, navViewItems, navCategories);
                    break;
                case "audit":
                    view = _audit; nav = navViewLogs; glyph = Icons.Document;
                    title = "Audit Logs"; subtitle = "Every change made in the system, with who and when";
                    SetGroup(navAudit, true, navViewLogs, navGenReport);
                    break;
                case "reports":
                    view = _reports; nav = navReports; glyph = Icons.Chart;
                    title = "Reports"; subtitle = "LINQ reports, XML export and secure printing";
                    break;
                case "settings":
                    view = _settings; nav = navSettings; glyph = Icons.Settings;
                    title = "Settings"; subtitle = "Account, permissions and system information";
                    break;
                default:
                    key = "dashboard";
                    view = _dashboard; nav = navDashboard; glyph = Icons.Home;
                    title = "Dashboard"; subtitle = "Overview of inventory, system status and recent activity";
                    break;
            }

            _current = key;
            foreach (UserControl v in _views) v.Visible = false;
            view.Visible = true;
            ((IReloadable)view).Reload();

            lblPageIcon.Text = glyph;
            lblPageTitle.Text = title;
            lblPageSubtitle.Text = subtitle;
            foreach (NavButton n in _allNav) n.Selected = ReferenceEquals(n, nav);
        }

        private void ToggleGroup(NavButton header, params NavButton[] children)
        {
            SetGroup(header, !header.Expanded, children);
        }

        private static void SetGroup(NavButton header, bool expanded, params NavButton[] children)
        {
            header.Expanded = expanded;
            foreach (NavButton c in children) c.Visible = expanded;
        }

        private void ReloadAll()
        {
            foreach (UserControl v in _views) ((IReloadable)v).Reload();
        }

        private void RefreshFromDatabase()
        {
            RunGuarded(() => _svc.Refresh(), "Data refreshed from the database.");
        }

        private InventoryItem SelectedItem()
        {
            return _current == "items" ? _items.Grid.SelectedItem : _dashboard.Grid.SelectedItem;
        }

        private void ViewItem(InventoryItem item)
        {
            if (item == null) return;
            MessageBox.Show(this,
                item.GetItemDetails() + Environment.NewLine + Environment.NewLine + item.GetStorageInstructions(),
                "Item details - " + item.Sku, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AddItem()
        {
            if (!SecurityService.Can(Permission.Edit)) { Denied("add items"); return; }

            using (var dialog = new ItemEditForm(_svc, null))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                InventoryItem created = dialog.ResultItem;
                if (RunGuarded(() => _svc.AddItem(created), "Added " + created.Sku + " - " + created.Name))
                {
                    ShowView("dashboard");
                    _dashboard.Grid.SelectSku(created.Sku);
                }
            }
        }

        private void EditItem(InventoryItem item)
        {
            if (item == null) { Info("Select an item first."); return; }
            if (!SecurityService.Can(Permission.Edit)) { Denied("edit items"); return; }

            using (var dialog = new ItemEditForm(_svc, item))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                InventoryItem edited = dialog.ResultItem;
                RunGuarded(() => _svc.UpdateItem(item, edited), "Updated " + item.Sku);
            }
        }

        private void DeleteItem(InventoryItem item)
        {
            if (item == null) { Info("Select an item first."); return; }
            if (!SecurityService.Can(Permission.Delete)) { Denied("delete items (Administrators only)"); return; }

            DialogResult answer = MessageBox.Show(this,
                "Delete " + item.Sku + " - " + item.Name + "?\n\nThis cannot be undone.",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (answer != DialogResult.Yes) return;

            string sku = item.Sku;
            RunGuarded(() => _svc.DeleteItem(item), "Deleted " + sku);
        }

        private void ImportCsv()
        {
            if (!SecurityService.Can(Permission.Import)) { Denied("import data"); return; }

            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                dialog.Title = "Import items (sku,name,category,quantity,minimumLevel,unitPrice,location)";
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                ImportResult result;
                _suppressAlerts = true;
                try
                {
                    result = CsvImporter.Import(dialog.FileName, _svc, _logger.AsHandler());
                }
                finally
                {
                    _suppressAlerts = false;
                }

                ReloadAll();
                string message = result.Imported + " item(s) imported, " + result.Skipped + " skipped.";
                if (result.Errors.Count > 0)
                    message += "\n\n" + string.Join("\n", result.Errors.Take(8));
                MessageBox.Show(this, message, "Import finished", MessageBoxButtons.OK,
                    result.Skipped > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
            }
        }

        private void PrintInventory()
        {
            if (!SecurityService.Can(Permission.Print)) { Denied("print"); return; }

            bool full = SecurityService.CurrentRole == UserRole.Admin;
            var lines = new List<string>();
            lines.Add(Fit("SKU", 10) + Fit("Name", 28) + Fit("Category", 20) + Fit("Qty", 6) + Fit("Status", 12) + (full ? "Value (M)" : ""));
            lines.Add(new string('-', 90));
            foreach (InventoryItem i in _svc.Warehouse)
            {
                lines.Add(Fit(i.Sku, 10) + Fit(i.Name, 28) + Fit(i.CategoryName, 20) + Fit(i.Quantity.ToString(), 6) +
                          Fit(i.StatusText, 12) + (full ? i.TotalValue.ToString("N2", CultureInfo.InvariantCulture) : ""));
            }

            try
            {
                SecurePrinter.ShowPreview(this, "SEIMS Inventory Listing", lines,
                    msg => _svc.Audit("PRINT", "Inventory", "listing", msg));
            }
            catch (UnauthorizedAccessException ex)
            {
                Denied(ex.Message);
            }
        }

        private static string Fit(string text, int width)
        {
            text = InputSanitizer.StripControl(text);
            if (text.Length >= width) text = text.Substring(0, width - 1);
            return text.PadRight(width);
        }

        private void Logout()
        {
            DialogResult answer = MessageBox.Show(this, "Log out of SEIMS?", "Log out",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;
            LogoutRequested = true;
            Close();
        }

        // ------------------------------------------------------------------ helpers
        /// <summary>Runs a data action with specific exception handling (FormatException-style,
        /// SqlException, DbUpdateException ...) and refreshes every page on success.</summary>
        private bool RunGuarded(Action action, string successMessage)
        {
            try
            {
                action();
                SetStatus(successMessage, false);
                ReloadAll();
                return true;
            }
            catch (DuplicateItemException ex) { Warn(ex.Message); }
            catch (UnauthorizedAccessException ex) { Denied(ex.Message); }
            catch (DbUpdateException ex)
            {
                SqlException sql = ex.InnerException as SqlException;
                _logger.Write("DB UPDATE ERROR: " + ex);
                Error("The database rejected the change:\n\n" + (sql != null ? sql.Message : ex.Message));
            }
            catch (SqlException ex)
            {
                _logger.Write("SQL ERROR: " + ex);
                Error("SQL Server error:\n\n" + ex.Message);
            }
            catch (ArgumentException ex) { Warn(ex.Message); }
            catch (Exception ex)
            {
                _logger.Write("ERROR: " + ex);
                Error(ex.Message);
            }
            return false;
        }

        private void ShowCriticalAlert(string message)
        {
            SetStatus("\u26A0 " + message, true);
            if (!_suppressAlerts)
                MessageBox.Show(this, message, "Critical stock alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void SetStatus(string text, bool alert)
        {
            stsAlert.Text = text;
            stsAlert.ForeColor = alert ? Theme.Orange : Theme.Muted;
        }

        private void UpdateClock()
        {
            lblDate.Text = DateTime.Now.ToString("ddd, dd MMM yyyy", CultureInfo.InvariantCulture) +
                           Environment.NewLine + DateTime.Now.ToString("HH:mm", CultureInfo.InvariantCulture);
        }

        private void Denied(string what)
        {
            MessageBox.Show(this, "Access denied: " + what, "SEIMS - security", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void Warn(string message)
        {
            MessageBox.Show(this, message, "SEIMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Info(string message)
        {
            MessageBox.Show(this, message, "SEIMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Error(string message)
        {
            MessageBox.Show(this, message, "SEIMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lblPageIcon_Click(object sender, EventArgs e)
        {

        }
    }
}
