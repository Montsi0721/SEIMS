namespace SEIMS.UI.Controls
{
    partial class ItemDetailsPanel
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
            this.panelTabHost = new System.Windows.Forms.Panel();
            this.kvGeneral = new SEIMS.UI.Controls.KeyValueList();
            this.kvStorage = new SEIMS.UI.Controls.KeyValueList();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.panelDescription = new System.Windows.Forms.Panel();
            this.lblDescText = new System.Windows.Forms.Label();
            this.lblDescTitle = new System.Windows.Forms.Label();
            this.panelDescLine = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.tableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnEdit = new SEIMS.UI.Controls.ThemedButton();
            this.btnDelete = new SEIMS.UI.Controls.ThemedButton();
            this.panelTabBar = new System.Windows.Forms.Panel();
            this.lblTabGeneral = new System.Windows.Forms.Label();
            this.lblTabStorage = new System.Windows.Forms.Label();
            this.lblTabHistory = new System.Windows.Forms.Label();
            this.panelTabUnderline = new System.Windows.Forms.Panel();
            this.panelTabLine = new System.Windows.Forms.Panel();
            this.panelHead = new System.Windows.Forms.Panel();
            this.tileThumb = new SEIMS.UI.Controls.IconTile();
            this.lblName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.flowPills = new System.Windows.Forms.FlowLayoutPanel();
            this.pillType = new SEIMS.UI.Controls.Pill();
            this.pillStatus = new SEIMS.UI.Controls.Pill();
            this.lblHeading = new System.Windows.Forms.Label();
            this.panelTabHost.SuspendLayout();
            this.panelDescription.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.tableButtons.SuspendLayout();
            this.panelTabBar.SuspendLayout();
            this.panelHead.SuspendLayout();
            this.flowPills.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTabHost
            // 
            this.panelTabHost.Name = "panelTabHost";
            this.panelTabHost.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelTabHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabHost.Padding = new System.Windows.Forms.Padding(20, 12, 20, 0);
            this.panelTabHost.Size = new System.Drawing.Size(378, 200);
            this.panelTabHost.Controls.Add(this.kvGeneral);
            this.panelTabHost.Controls.Add(this.kvStorage);
            this.panelTabHost.Controls.Add(this.lstHistory);
            this.panelTabHost.TabIndex = 0;
            // 
            // kvGeneral
            // 
            this.kvGeneral.Name = "kvGeneral";
            this.kvGeneral.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.kvGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kvGeneral.Size = new System.Drawing.Size(338, 188);
            this.kvGeneral.TabIndex = 0;
            // 
            // kvStorage
            // 
            this.kvStorage.Name = "kvStorage";
            this.kvStorage.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.kvStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kvStorage.Size = new System.Drawing.Size(338, 188);
            this.kvStorage.Visible = false;
            this.kvStorage.TabIndex = 1;
            // 
            // lstHistory
            // 
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.lstHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHistory.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHistory.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.HorizontalScrollbar = true;
            this.lstHistory.Size = new System.Drawing.Size(338, 188);
            this.lstHistory.Visible = false;
            this.lstHistory.TabIndex = 2;
            // 
            // panelDescription
            // 
            this.panelDescription.Name = "panelDescription";
            this.panelDescription.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDescription.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.panelDescription.Size = new System.Drawing.Size(418, 112);
            this.panelDescription.Controls.Add(this.lblDescText);
            this.panelDescription.Controls.Add(this.lblDescTitle);
            this.panelDescription.Controls.Add(this.panelDescLine);
            this.panelDescription.TabIndex = 1;
            // 
            // lblDescText
            // 
            this.lblDescText.Name = "lblDescText";
            this.lblDescText.AutoSize = false;
            this.lblDescText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescText.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblDescText.Size = new System.Drawing.Size(378, 73);
            this.lblDescText.Text = "Fresh milk, 1 liter pack. Keep refrigerated between 2\u00B0C and 5\u00B0C.";
            this.lblDescText.TabIndex = 0;
            // 
            // lblDescTitle
            // 
            this.lblDescTitle.Name = "lblDescTitle";
            this.lblDescTitle.AutoSize = false;
            this.lblDescTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescTitle.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblDescTitle.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblDescTitle.Size = new System.Drawing.Size(378, 38);
            this.lblDescTitle.Text = "Description";
            this.lblDescTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDescTitle.TabIndex = 1;
            // 
            // panelDescLine
            // 
            this.panelDescLine.Name = "panelDescLine";
            this.panelDescLine.BackColor = System.Drawing.Color.FromArgb(33, 44, 58);
            this.panelDescLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDescLine.Size = new System.Drawing.Size(378, 1);
            this.panelDescLine.TabIndex = 2;
            // 
            // panelButtons
            // 
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Padding = new System.Windows.Forms.Padding(20, 12, 20, 16);
            this.panelButtons.Size = new System.Drawing.Size(418, 74);
            this.panelButtons.Controls.Add(this.tableButtons);
            this.panelButtons.TabIndex = 2;
            // 
            // tableButtons
            // 
            this.tableButtons.Name = "tableButtons";
            this.tableButtons.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.tableButtons.ColumnCount = 2;
            this.tableButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableButtons.RowCount = 1;
            this.tableButtons.Size = new System.Drawing.Size(378, 46);
            this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableButtons.Controls.Add(this.btnEdit, 0, 0);
            this.tableButtons.Controls.Add(this.btnDelete, 1, 0);
            this.tableButtons.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Kind = SEIMS.UI.Controls.ButtonKind.Ghost;
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.btnEdit.Text = "Edit Item";
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Kind = SEIMS.UI.Controls.ButtonKind.Danger;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.btnDelete.Text = "Delete Item";
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelTabBar
            // 
            this.panelTabBar.Name = "panelTabBar";
            this.panelTabBar.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelTabBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTabBar.Size = new System.Drawing.Size(418, 46);
            this.panelTabBar.Controls.Add(this.lblTabGeneral);
            this.panelTabBar.Controls.Add(this.lblTabStorage);
            this.panelTabBar.Controls.Add(this.lblTabHistory);
            this.panelTabBar.Controls.Add(this.panelTabUnderline);
            this.panelTabBar.Controls.Add(this.panelTabLine);
            this.panelTabBar.TabIndex = 3;
            // 
            // lblTabGeneral
            // 
            this.lblTabGeneral.Name = "lblTabGeneral";
            this.lblTabGeneral.AutoSize = false;
            this.lblTabGeneral.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.lblTabGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTabGeneral.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabGeneral.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblTabGeneral.Location = new System.Drawing.Point(12, 0);
            this.lblTabGeneral.Size = new System.Drawing.Size(96, 44);
            this.lblTabGeneral.Text = "General";
            this.lblTabGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTabGeneral.TabIndex = 0;
            this.lblTabGeneral.Click += new System.EventHandler(this.lblTabGeneral_Click);
            // 
            // lblTabStorage
            // 
            this.lblTabStorage.Name = "lblTabStorage";
            this.lblTabStorage.AutoSize = false;
            this.lblTabStorage.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.lblTabStorage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTabStorage.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabStorage.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblTabStorage.Location = new System.Drawing.Point(108, 0);
            this.lblTabStorage.Size = new System.Drawing.Size(92, 44);
            this.lblTabStorage.Text = "Storage";
            this.lblTabStorage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTabStorage.TabIndex = 1;
            this.lblTabStorage.Click += new System.EventHandler(this.lblTabStorage_Click);
            // 
            // lblTabHistory
            // 
            this.lblTabHistory.Name = "lblTabHistory";
            this.lblTabHistory.AutoSize = false;
            this.lblTabHistory.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.lblTabHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTabHistory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabHistory.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblTabHistory.Location = new System.Drawing.Point(200, 0);
            this.lblTabHistory.Size = new System.Drawing.Size(120, 44);
            this.lblTabHistory.Text = "Audit History";
            this.lblTabHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTabHistory.TabIndex = 2;
            this.lblTabHistory.Click += new System.EventHandler(this.lblTabHistory_Click);
            // 
            // panelTabUnderline
            // 
            this.panelTabUnderline.Name = "panelTabUnderline";
            this.panelTabUnderline.BackColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.panelTabUnderline.Location = new System.Drawing.Point(18, 43);
            this.panelTabUnderline.Size = new System.Drawing.Size(84, 3);
            this.panelTabUnderline.TabIndex = 3;
            // 
            // panelTabLine
            // 
            this.panelTabLine.Name = "panelTabLine";
            this.panelTabLine.BackColor = System.Drawing.Color.FromArgb(33, 44, 58);
            this.panelTabLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTabLine.Size = new System.Drawing.Size(418, 1);
            this.panelTabLine.TabIndex = 4;
            // 
            // panelHead
            // 
            this.panelHead.Name = "panelHead";
            this.panelHead.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHead.Size = new System.Drawing.Size(418, 104);
            this.panelHead.Controls.Add(this.tileThumb);
            this.panelHead.Controls.Add(this.lblName);
            this.panelHead.Controls.Add(this.lblId);
            this.panelHead.Controls.Add(this.flowPills);
            this.panelHead.TabIndex = 4;
            // 
            // tileThumb
            // 
            this.tileThumb.Name = "tileThumb";
            this.tileThumb.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.tileThumb.BorderColor = System.Drawing.Color.FromArgb(33, 44, 58);
            this.tileThumb.CornerRadius = 10;
            this.tileThumb.FillColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.tileThumb.Glyph = "\uE7B8";
            this.tileThumb.GlyphColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.tileThumb.GlyphSize = 30.0F;
            this.tileThumb.Location = new System.Drawing.Point(20, 4);
            this.tileThumb.Size = new System.Drawing.Size(84, 84);
            this.tileThumb.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Name = "lblName";
            this.lblName.AutoSize = false;
            this.lblName.AutoEllipsis = true;
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblName.Location = new System.Drawing.Point(120, 6);
            this.lblName.Size = new System.Drawing.Size(240, 28);
            this.lblName.Text = "Milk (1L)";
            this.lblName.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.Name = "lblId";
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.lblId.Location = new System.Drawing.Point(120, 38);
            this.lblId.Text = "ID: ITM-002";
            this.lblId.TabIndex = 2;
            // 
            // flowPills
            // 
            this.flowPills.Name = "flowPills";
            this.flowPills.AutoSize = true;
            this.flowPills.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowPills.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.flowPills.Location = new System.Drawing.Point(120, 64);
            this.flowPills.Size = new System.Drawing.Size(190, 30);
            this.flowPills.WrapContents = false;
            this.flowPills.Controls.Add(this.pillType);
            this.flowPills.Controls.Add(this.pillStatus);
            this.flowPills.TabIndex = 3;
            // 
            // pillType
            // 
            this.pillType.Name = "pillType";
            this.pillType.Text = "Perishable";
            this.pillType.TabIndex = 0;
            // 
            // pillStatus
            // 
            this.pillStatus.Name = "pillStatus";
            this.pillStatus.Text = "In Stock";
            this.pillStatus.TabIndex = 1;
            // 
            // lblHeading
            // 
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.AutoSize = false;
            this.lblHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblHeading.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblHeading.Size = new System.Drawing.Size(418, 56);
            this.lblHeading.Text = "Item Details";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeading.TabIndex = 5;
            // 
            // ItemDetailsPanel
            // 
            this.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Size = new System.Drawing.Size(420, 620);
            this.Controls.Add(this.panelTabHost);
            this.Controls.Add(this.panelDescription);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTabBar);
            this.Controls.Add(this.panelHead);
            this.Controls.Add(this.lblHeading);
            this.Name = "ItemDetailsPanel";
            this.panelTabHost.ResumeLayout(false);
            this.panelDescription.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.tableButtons.ResumeLayout(false);
            this.tableButtons.PerformLayout();
            this.panelTabBar.ResumeLayout(false);
            this.panelHead.ResumeLayout(false);
            this.flowPills.ResumeLayout(false);
            this.flowPills.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTabHost;
        private SEIMS.UI.Controls.KeyValueList kvGeneral;
        private SEIMS.UI.Controls.KeyValueList kvStorage;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Panel panelDescription;
        private System.Windows.Forms.Label lblDescText;
        private System.Windows.Forms.Label lblDescTitle;
        private System.Windows.Forms.Panel panelDescLine;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.TableLayoutPanel tableButtons;
        private SEIMS.UI.Controls.ThemedButton btnEdit;
        private SEIMS.UI.Controls.ThemedButton btnDelete;
        private System.Windows.Forms.Panel panelTabBar;
        private System.Windows.Forms.Label lblTabGeneral;
        private System.Windows.Forms.Label lblTabStorage;
        private System.Windows.Forms.Label lblTabHistory;
        private System.Windows.Forms.Panel panelTabUnderline;
        private System.Windows.Forms.Panel panelTabLine;
        private System.Windows.Forms.Panel panelHead;
        private SEIMS.UI.Controls.IconTile tileThumb;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.FlowLayoutPanel flowPills;
        private SEIMS.UI.Controls.Pill pillType;
        private SEIMS.UI.Controls.Pill pillStatus;
        private System.Windows.Forms.Label lblHeading;
    }
}
