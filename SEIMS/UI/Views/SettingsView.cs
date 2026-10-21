using System.Diagnostics;
using Microsoft.Data.SqlClient;
using SEIMS.Models;
using SEIMS.Services;

namespace SEIMS.UI.Views
{
    /// <summary>Read-only system information: account, permissions, database, log file, object tracking.</summary>
    public partial class SettingsView : UserControl, IReloadable
    {
        private InventoryService _svc;
        private FileLogger _logger;

        public SettingsView()
        {
            InitializeComponent();
        }

        public void Initialize(InventoryService svc, FileLogger logger)
        {
            _svc = svc;
            _logger = logger;
        }

        private void btnOpenLog_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = Path.GetDirectoryName(_logger.FilePath);
                Process.Start(new ProcessStartInfo("explorer.exe", "\"" + dir + "\"") { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(FindForm(), ex.Message, "SEIMS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGc_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Reload();
        }

        public void Reload()
        {
            if (_svc == null) return;
            var perms = new List<string>();
            foreach (Permission p in Enum.GetValues(typeof(Permission)))
                if (SecurityService.Can(p)) perms.Add(p.ToString());

            string server = "?", database = "?";
            try
            {
                var csb = new SqlConnectionStringBuilder(AppConfig.ConnectionString);
                server = csb.DataSource;
                database = csb.InitialCatalog;
            }
            catch (ArgumentException) { }

            kvSettings.SetPairs(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Signed in as", SecurityService.CurrentUsername + " (" + SecurityService.CurrentRole + ")"),
                new KeyValuePair<string, string>("Permissions", string.Join(", ", perms)),
                new KeyValuePair<string, string>("SQL Server", server),
                new KeyValuePair<string, string>("Database", database),
                new KeyValuePair<string, string>("Log file", _logger.FilePath),
                new KeyValuePair<string, string>("Critical stock", "below " + InventoryItem.CriticalThreshold + " units"),
                new KeyValuePair<string, string>("Items in memory", _svc.Warehouse.Count.ToString()),
                new KeyValuePair<string, string>("Objects created", InventoryItem.TotalCreated.ToString()),
                new KeyValuePair<string, string>("Objects alive", InventoryItem.ActiveInstances.ToString()),
                new KeyValuePair<string, string>("Parse failures", SafeParser.TotalParseFailures.ToString()),
                new KeyValuePair<string, string>("Version", "SEIMS v" + AppConfig.Version)
            });
        }
    }
}
