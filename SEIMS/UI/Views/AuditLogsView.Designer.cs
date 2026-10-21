namespace SEIMS.UI.Views
{
    partial class AuditLogsView
    {
        /// <summary>Required designer variable.</summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>Clean up any resources being used.</summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>Required method for Designer support - do not modify
        /// the contents of this method with the code editor.</summary>
        private void InitializeComponent()
        {
            this.cardMain = new SEIMS.UI.Controls.CardPanel();
            this.gridAudit = new SEIMS.UI.Controls.DarkGrid();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelLog = new System.Windows.Forms.Panel();
            this.txtFileLog = new System.Windows.Forms.TextBox();
            this.lblLogTitle = new System.Windows.Forms.Label();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnApply = new SEIMS.UI.Controls.ThemedButton();
            this.btnReset = new SEIMS.UI.Controls.ThemedButton();
            this.lblCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridAudit)).BeginInit();
            this.cardMain.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardMain
            // 
            this.cardMain.Name = "cardMain";
            this.cardMain.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.cardMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardMain.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.cardMain.Size = new System.Drawing.Size(1068, 650);
            this.cardMain.Controls.Add(this.gridAudit);
            this.cardMain.Controls.Add(this.panelLog);
            this.cardMain.Controls.Add(this.panelFilter);
            this.cardMain.TabIndex = 0;
            // 
            // gridAudit
            // 
            this.gridAudit.Name = "gridAudit";
            this.gridAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAudit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colUser,
            this.colAction,
            this.colEntity,
            this.colKey,
            this.colDetails});
            this.gridAudit.TabIndex = 0;
            // 
            // colTime
            // 
            this.colTime.Name = "colTime";
            this.colTime.FillWeight = 16.0F;
            this.colTime.HeaderText = "Time";
            this.colTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colUser
            // 
            this.colUser.Name = "colUser";
            this.colUser.FillWeight = 10.0F;
            this.colUser.HeaderText = "User";
            this.colUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colAction
            // 
            this.colAction.Name = "colAction";
            this.colAction.FillWeight = 10.0F;
            this.colAction.HeaderText = "Action";
            this.colAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colEntity
            // 
            this.colEntity.Name = "colEntity";
            this.colEntity.FillWeight = 14.0F;
            this.colEntity.HeaderText = "Entity";
            this.colEntity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colKey
            // 
            this.colKey.Name = "colKey";
            this.colKey.FillWeight = 12.0F;
            this.colKey.HeaderText = "Key";
            this.colKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colDetails
            // 
            this.colDetails.Name = "colDetails";
            this.colDetails.FillWeight = 38.0F;
            this.colDetails.HeaderText = "Details";
            this.colDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panelLog
            // 
            this.panelLog.Name = "panelLog";
            this.panelLog.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLog.Padding = new System.Windows.Forms.Padding(20, 8, 20, 12);
            this.panelLog.Size = new System.Drawing.Size(1066, 190);
            this.panelLog.Controls.Add(this.txtFileLog);
            this.panelLog.Controls.Add(this.lblLogTitle);
            this.panelLog.TabIndex = 1;
            // 
            // txtFileLog
            // 
            this.txtFileLog.Name = "txtFileLog";
            this.txtFileLog.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.txtFileLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFileLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileLog.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtFileLog.Multiline = true;
            this.txtFileLog.ReadOnly = true;
            this.txtFileLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFileLog.Size = new System.Drawing.Size(1026, 144);
            this.txtFileLog.TabIndex = 0;
            // 
            // lblLogTitle
            // 
            this.lblLogTitle.Name = "lblLogTitle";
            this.lblLogTitle.AutoSize = false;
            this.lblLogTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLogTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogTitle.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblLogTitle.Size = new System.Drawing.Size(1026, 26);
            this.lblLogTitle.Text = "System alert log (seims.log)";
            this.lblLogTitle.TabIndex = 1;
            // 
            // panelFilter
            // 
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Size = new System.Drawing.Size(1066, 66);
            this.panelFilter.Controls.Add(this.lblFrom);
            this.panelFilter.Controls.Add(this.dtpFrom);
            this.panelFilter.Controls.Add(this.lblTo);
            this.panelFilter.Controls.Add(this.dtpTo);
            this.panelFilter.Controls.Add(this.txtSearch);
            this.panelFilter.Controls.Add(this.btnApply);
            this.panelFilter.Controls.Add(this.btnReset);
            this.panelFilter.Controls.Add(this.lblCount);
            this.panelFilter.TabIndex = 2;
            // 
            // lblFrom
            // 
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblFrom.Location = new System.Drawing.Point(20, 24);
            this.lblFrom.Text = "From";
            this.lblFrom.TabIndex = 0;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Checked = false;
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(64, 20);
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(120, 23);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.Name = "lblTo";
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblTo.Location = new System.Drawing.Point(200, 24);
            this.lblTo.Text = "To";
            this.lblTo.TabIndex = 2;
            // 
            // dtpTo
            // 
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Checked = false;
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(228, 20);
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size(120, 23);
            this.dtpTo.TabIndex = 3;
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtSearch.Location = new System.Drawing.Point(366, 18);
            this.txtSearch.MaxLength = 60;
            this.txtSearch.Size = new System.Drawing.Size(240, 23);
            this.txtSearch.PlaceholderText = "User, action, SKU or text...";
            this.txtSearch.TabIndex = 4;
            // 
            // btnApply
            // 
            this.btnApply.Name = "btnApply";
            this.btnApply.Kind = SEIMS.UI.Controls.ButtonKind.Primary;
            this.btnApply.Location = new System.Drawing.Point(620, 17);
            this.btnApply.Size = new System.Drawing.Size(80, 30);
            this.btnApply.Text = "Apply";
            this.btnApply.TabIndex = 5;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnReset
            // 
            this.btnReset.Name = "btnReset";
            this.btnReset.Kind = SEIMS.UI.Controls.ButtonKind.Secondary;
            this.btnReset.Location = new System.Drawing.Point(706, 17);
            this.btnReset.Size = new System.Drawing.Size(80, 30);
            this.btnReset.Text = "Reset";
            this.btnReset.TabIndex = 6;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblCount
            // 
            this.lblCount.Name = "lblCount";
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.lblCount.Location = new System.Drawing.Point(806, 24);
            this.lblCount.TabIndex = 7;
            // 
            // AuditLogsView
            // 
            this.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.Size = new System.Drawing.Size(1068, 650);
            this.Controls.Add(this.cardMain);
            this.Name = "AuditLogsView";
            ((System.ComponentModel.ISupportInitialize)(this.gridAudit)).EndInit();
            this.cardMain.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private SEIMS.UI.Controls.CardPanel cardMain;
        private SEIMS.UI.Controls.DarkGrid gridAudit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDetails;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.TextBox txtFileLog;
        private System.Windows.Forms.Label lblLogTitle;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.TextBox txtSearch;
        private SEIMS.UI.Controls.ThemedButton btnApply;
        private SEIMS.UI.Controls.ThemedButton btnReset;
        private System.Windows.Forms.Label lblCount;
    }
}
