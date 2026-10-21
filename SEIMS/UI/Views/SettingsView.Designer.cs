namespace SEIMS.UI.Views
{
    partial class SettingsView
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
            this.kvSettings = new SEIMS.UI.Controls.KeyValueList();
            this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOpenLog = new SEIMS.UI.Controls.ThemedButton();
            this.btnGc = new SEIMS.UI.Controls.ThemedButton();
            this.lblHeading = new System.Windows.Forms.Label();
            this.cardMain.SuspendLayout();
            this.flowButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardMain
            // 
            this.cardMain.Name = "cardMain";
            this.cardMain.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.cardMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardMain.Padding = new System.Windows.Forms.Padding(28, 28, 28, 28);
            this.cardMain.Size = new System.Drawing.Size(1068, 650);
            this.cardMain.Controls.Add(this.kvSettings);
            this.cardMain.Controls.Add(this.flowButtons);
            this.cardMain.Controls.Add(this.lblHeading);
            this.cardMain.TabIndex = 0;
            // 
            // kvSettings
            // 
            this.kvSettings.Name = "kvSettings";
            this.kvSettings.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.kvSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kvSettings.RowHeight = 34;
            this.kvSettings.Size = new System.Drawing.Size(1012, 478);
            this.kvSettings.TabIndex = 0;
            // 
            // flowButtons
            // 
            this.flowButtons.Name = "flowButtons";
            this.flowButtons.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.flowButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowButtons.Size = new System.Drawing.Size(1012, 52);
            this.flowButtons.Controls.Add(this.btnOpenLog);
            this.flowButtons.Controls.Add(this.btnGc);
            this.flowButtons.TabIndex = 1;
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Kind = SEIMS.UI.Controls.ButtonKind.Secondary;
            this.btnOpenLog.Size = new System.Drawing.Size(140, 34);
            this.btnOpenLog.Text = "Open log folder";
            this.btnOpenLog.TabIndex = 0;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // btnGc
            // 
            this.btnGc.Name = "btnGc";
            this.btnGc.Kind = SEIMS.UI.Controls.ButtonKind.Secondary;
            this.btnGc.Size = new System.Drawing.Size(180, 34);
            this.btnGc.Text = "Run garbage collection";
            this.btnGc.TabIndex = 1;
            this.btnGc.Click += new System.EventHandler(this.btnGc_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.AutoSize = false;
            this.lblHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblHeading.Size = new System.Drawing.Size(1012, 44);
            this.lblHeading.Text = "System information";
            this.lblHeading.TabIndex = 2;
            // 
            // SettingsView
            // 
            this.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.Size = new System.Drawing.Size(1068, 650);
            this.Controls.Add(this.cardMain);
            this.Name = "SettingsView";
            this.cardMain.ResumeLayout(false);
            this.flowButtons.ResumeLayout(false);
            this.flowButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private SEIMS.UI.Controls.CardPanel cardMain;
        private SEIMS.UI.Controls.KeyValueList kvSettings;
        private System.Windows.Forms.FlowLayoutPanel flowButtons;
        private SEIMS.UI.Controls.ThemedButton btnOpenLog;
        private SEIMS.UI.Controls.ThemedButton btnGc;
        private System.Windows.Forms.Label lblHeading;
    }
}
