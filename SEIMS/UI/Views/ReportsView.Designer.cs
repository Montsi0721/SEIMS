namespace SEIMS.UI.Views
{
    partial class ReportsView
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
            this.gridReport = new SEIMS.UI.Controls.DarkGrid();
            this.lblSummary = new System.Windows.Forms.Label();
            this.panelBar = new System.Windows.Forms.Panel();
            this.cmbReport = new System.Windows.Forms.ComboBox();
            this.btnRun = new SEIMS.UI.Controls.ThemedButton();
            this.btnExportXml = new SEIMS.UI.Controls.ThemedButton();
            this.btnPrint = new SEIMS.UI.Controls.ThemedButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).BeginInit();
            this.cardMain.SuspendLayout();
            this.panelBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardMain
            // 
            this.cardMain.Name = "cardMain";
            this.cardMain.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.cardMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardMain.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.cardMain.Size = new System.Drawing.Size(1068, 650);
            this.cardMain.Controls.Add(this.gridReport);
            this.cardMain.Controls.Add(this.lblSummary);
            this.cardMain.Controls.Add(this.panelBar);
            this.cardMain.TabIndex = 0;
            // 
            // gridReport
            // 
            this.gridReport.Name = "gridReport";
            this.gridReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReport.RowTemplate.Height = 38;
            this.gridReport.TabIndex = 0;
            // 
            // lblSummary
            // 
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.AutoSize = false;
            this.lblSummary.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblSummary.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblSummary.Size = new System.Drawing.Size(1066, 40);
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSummary.TabIndex = 1;
            // 
            // panelBar
            // 
            this.panelBar.Name = "panelBar";
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Size = new System.Drawing.Size(1066, 66);
            this.panelBar.Controls.Add(this.cmbReport);
            this.panelBar.Controls.Add(this.btnRun);
            this.panelBar.Controls.Add(this.btnExportXml);
            this.panelBar.Controls.Add(this.btnPrint);
            this.panelBar.TabIndex = 2;
            // 
            // cmbReport
            // 
            this.cmbReport.Name = "cmbReport";
            this.cmbReport.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.cmbReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReport.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.cmbReport.FormattingEnabled = true;
            this.cmbReport.Location = new System.Drawing.Point(20, 18);
            this.cmbReport.Size = new System.Drawing.Size(430, 25);
            this.cmbReport.Items.AddRange(new object[] {
                "Top stock value - query syntax (orderby descending)",
                "Top stock value - method syntax (OrderByDescending)",
                "Category summary - group by (query syntax)",
                "Category summary - GroupBy (method syntax)",
                "Suppliers x categories - join + group (query syntax)",
                "Suppliers x categories - Join + GroupBy (method syntax)",
                "Low stock items",
                "Perishables expiring soon",
                "Audit activity by user (database)"});
            this.cmbReport.TabIndex = 0;
            this.cmbReport.SelectedIndexChanged += new System.EventHandler(this.cmbReport_SelectedIndexChanged);
            // 
            // btnRun
            // 
            this.btnRun.Name = "btnRun";
            this.btnRun.Kind = SEIMS.UI.Controls.ButtonKind.Primary;
            this.btnRun.Location = new System.Drawing.Point(464, 17);
            this.btnRun.Size = new System.Drawing.Size(100, 32);
            this.btnRun.Text = "Run report";
            this.btnRun.TabIndex = 1;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnExportXml
            // 
            this.btnExportXml.Name = "btnExportXml";
            this.btnExportXml.Kind = SEIMS.UI.Controls.ButtonKind.Secondary;
            this.btnExportXml.Location = new System.Drawing.Point(572, 17);
            this.btnExportXml.Size = new System.Drawing.Size(100, 32);
            this.btnExportXml.Text = "Export XML";
            this.btnExportXml.TabIndex = 2;
            this.btnExportXml.Click += new System.EventHandler(this.btnExportXml_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Kind = SEIMS.UI.Controls.ButtonKind.Secondary;
            this.btnPrint.Location = new System.Drawing.Point(680, 17);
            this.btnPrint.Size = new System.Drawing.Size(110, 32);
            this.btnPrint.Text = "Print preview";
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ReportsView
            // 
            this.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.Size = new System.Drawing.Size(1068, 650);
            this.Controls.Add(this.cardMain);
            this.Name = "ReportsView";
            ((System.ComponentModel.ISupportInitialize)(this.gridReport)).EndInit();
            this.cardMain.ResumeLayout(false);
            this.panelBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private SEIMS.UI.Controls.CardPanel cardMain;
        private SEIMS.UI.Controls.DarkGrid gridReport;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.ComboBox cmbReport;
        private SEIMS.UI.Controls.ThemedButton btnRun;
        private SEIMS.UI.Controls.ThemedButton btnExportXml;
        private SEIMS.UI.Controls.ThemedButton btnPrint;
    }
}
