using SEIMS.Models;
using SEIMS.Services;

namespace SEIMS.UI.Views
{
    /// <summary>Audit trail from the database plus the tail of the plain-text system log file.</summary>
    public partial class AuditLogsView : UserControl, IReloadable
    {
        private InventoryService _svc;
        private FileLogger _logger;

        public AuditLogsView()
        {
            InitializeComponent();
        }

        public void Initialize(InventoryService svc, FileLogger logger)
        {
            _svc = svc;
            _logger = logger;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpFrom.Checked = false;
            dtpTo.Checked = false;
            txtSearch.Text = "";
            Reload();
        }

        public void Reload()
        {
            if (_svc == null) return;
            DateTime? fromDate = dtpFrom.Checked ? dtpFrom.Value : (DateTime?)null;
            DateTime? toDate = dtpTo.Checked ? dtpTo.Value : (DateTime?)null;
            List<AuditLog> logs = _svc.GetAuditLogs(fromDate, toDate, txtSearch.Text, 500);

            gridAudit.Rows.Clear();
            foreach (AuditLog log in logs)
            {
                gridAudit.Rows.Add(log.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"), log.Username, log.Action,
                    log.EntityName, log.EntityKey, log.Details);
            }
            lblCount.Text = logs.Count + " record(s)";

            txtFileLog.Text = string.Join(Environment.NewLine, _logger.ReadLast(60));
            txtFileLog.SelectionStart = txtFileLog.Text.Length;
            txtFileLog.ScrollToCaret();
        }
    }
}
