namespace SEIMS.UI
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            panelContent = new Panel();
            viewHost = new Panel();
            panelHeader = new Panel();
            lblPageIcon = new Label();
            lblPageTitle = new Label();
            lblPageSubtitle = new Label();
            lblDateIcon = new Label();
            lblDate = new Label();
            panelSidebar = new Panel();
            flowNav = new FlowLayoutPanel();
            panelNavBottom = new Panel();
            panelNavLine = new Panel();
            panelLogo = new Panel();
            lblBrand = new Label();
            lblTagline = new Label();
            panelSidebarBorder = new Panel();
            toolStrip = new ToolStrip();
            tsAdd = new ToolStripButton();
            tsEdit = new ToolStripButton();
            tsDelete = new ToolStripButton();
            sepTool1 = new ToolStripSeparator();
            tsRefresh = new ToolStripButton();
            sepTool2 = new ToolStripSeparator();
            tsPrint = new ToolStripButton();
            tsExport = new ToolStripButton();
            menuStrip = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuImport = new ToolStripMenuItem();
            mnuExport = new ToolStripMenuItem();
            sepFile1 = new ToolStripSeparator();
            mnuPrint = new ToolStripMenuItem();
            sepFile2 = new ToolStripSeparator();
            mnuLogout = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            mnuInventory = new ToolStripMenuItem();
            mnuAddItem = new ToolStripMenuItem();
            mnuEditItem = new ToolStripMenuItem();
            mnuDeleteItem = new ToolStripMenuItem();
            sepInv1 = new ToolStripSeparator();
            mnuRefresh = new ToolStripMenuItem();
            mnuAudit = new ToolStripMenuItem();
            mnuViewLogs = new ToolStripMenuItem();
            mnuGenReport = new ToolStripMenuItem();
            mnuReports = new ToolStripMenuItem();
            mnuHelp = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            mnuUser = new ToolStripMenuItem();
            mnuUserLogout = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            stsOnline = new ToolStripStatusLabel();
            stsAlert = new ToolStripStatusLabel();
            stsUser = new ToolStripStatusLabel();
            stsVersion = new ToolStripStatusLabel();
            clockTimer = new System.Windows.Forms.Timer(components);
            panelContent.SuspendLayout();
            panelHeader.SuspendLayout();
            panelSidebar.SuspendLayout();
            panelNavBottom.SuspendLayout();
            panelLogo.SuspendLayout();
            toolStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(9, 13, 18);
            panelContent.Controls.Add(viewHost);
            panelContent.Controls.Add(panelHeader);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(250, 74);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(24, 18, 24, 18);
            panelContent.Size = new Size(778, 643);
            panelContent.TabIndex = 0;
            // 
            // viewHost
            // 
            viewHost.BackColor = Color.FromArgb(9, 13, 18);
            viewHost.Dock = DockStyle.Fill;
            viewHost.Location = new Point(24, 106);
            viewHost.Name = "viewHost";
            viewHost.Size = new Size(730, 519);
            viewHost.TabIndex = 0;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(9, 13, 18);
            panelHeader.Controls.Add(lblPageIcon);
            panelHeader.Controls.Add(lblPageTitle);
            panelHeader.Controls.Add(lblPageSubtitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(24, 18);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(730, 88);
            panelHeader.TabIndex = 1;
            // 
            // lblPageIcon
            // 
            lblPageIcon.Font = new Font("Segoe MDL2 Assets", 22F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPageIcon.ForeColor = Color.FromArgb(139, 148, 158);
            lblPageIcon.Location = new Point(14, 15);
            lblPageIcon.Name = "lblPageIcon";
            lblPageIcon.Size = new Size(42, 46);
            lblPageIcon.TabIndex = 0;
            lblPageIcon.Text = "";
            lblPageIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblPageIcon.Click += lblPageIcon_Click;
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPageTitle.ForeColor = Color.FromArgb(230, 237, 243);
            lblPageTitle.Location = new Point(62, 6);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(188, 46);
            lblPageTitle.TabIndex = 1;
            lblPageTitle.Text = "Dashboard";
            // 
            // lblPageSubtitle
            // 
            lblPageSubtitle.AutoSize = true;
            lblPageSubtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPageSubtitle.ForeColor = Color.FromArgb(139, 148, 158);
            lblPageSubtitle.Location = new Point(64, 55);
            lblPageSubtitle.Name = "lblPageSubtitle";
            lblPageSubtitle.Size = new Size(395, 21);
            lblPageSubtitle.TabIndex = 2;
            lblPageSubtitle.Text = "Overview of inventory, system status and recent activity";
            // 
            // lblDateIcon
            // 
            lblDateIcon.BackColor = Color.FromArgb(15, 21, 29);
            lblDateIcon.Font = new Font("Segoe MDL2 Assets", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDateIcon.ForeColor = Color.FromArgb(230, 237, 243);
            lblDateIcon.Location = new Point(10, 10);
            lblDateIcon.Name = "lblDateIcon";
            lblDateIcon.Size = new Size(32, 32);
            lblDateIcon.TabIndex = 0;
            lblDateIcon.Text = "";
            lblDateIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            lblDate.BackColor = Color.FromArgb(15, 21, 29);
            lblDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDate.ForeColor = Color.FromArgb(230, 237, 243);
            lblDate.Location = new Point(48, 6);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(140, 42);
            lblDate.TabIndex = 1;
            lblDate.Text = "Thu, 09 Oct 2026\r\n21:34";
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(12, 17, 23);
            panelSidebar.Controls.Add(flowNav);
            panelSidebar.Controls.Add(panelNavBottom);
            panelSidebar.Controls.Add(panelLogo);
            panelSidebar.Controls.Add(panelSidebarBorder);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 74);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(250, 643);
            panelSidebar.TabIndex = 1;
            // 
            // flowNav
            // 
            flowNav.BackColor = Color.FromArgb(12, 17, 23);
            flowNav.Dock = DockStyle.Fill;
            flowNav.FlowDirection = FlowDirection.TopDown;
            flowNav.Location = new Point(0, 108);
            flowNav.Name = "flowNav";
            flowNav.Padding = new Padding(0, 8, 0, 0);
            flowNav.Size = new Size(249, 469);
            flowNav.TabIndex = 0;
            flowNav.WrapContents = false;
            // 
            // panelNavBottom
            // 
            panelNavBottom.BackColor = Color.FromArgb(12, 17, 23);
            panelNavBottom.Controls.Add(panelNavLine);
            panelNavBottom.Dock = DockStyle.Bottom;
            panelNavBottom.Location = new Point(0, 577);
            panelNavBottom.Name = "panelNavBottom";
            panelNavBottom.Size = new Size(249, 66);
            panelNavBottom.TabIndex = 1;
            // 
            // panelNavLine
            // 
            panelNavLine.BackColor = Color.FromArgb(33, 44, 58);
            panelNavLine.Dock = DockStyle.Top;
            panelNavLine.Location = new Point(0, 0);
            panelNavLine.Name = "panelNavLine";
            panelNavLine.Size = new Size(249, 1);
            panelNavLine.TabIndex = 1;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(12, 17, 23);
            panelLogo.Controls.Add(lblBrand);
            panelLogo.Controls.Add(lblTagline);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(249, 108);
            panelLogo.TabIndex = 2;
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBrand.ForeColor = Color.FromArgb(230, 237, 243);
            lblBrand.Location = new Point(21, 18);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(94, 37);
            lblBrand.TabIndex = 1;
            lblBrand.Text = "SEIMS";
            // 
            // lblTagline
            // 
            lblTagline.AutoSize = true;
            lblTagline.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTagline.ForeColor = Color.FromArgb(139, 148, 158);
            lblTagline.Location = new Point(21, 60);
            lblTagline.Name = "lblTagline";
            lblTagline.Size = new Size(186, 20);
            lblTagline.TabIndex = 2;
            lblTagline.Text = "Inventory • Security • Audit";
            // 
            // panelSidebarBorder
            // 
            panelSidebarBorder.BackColor = Color.FromArgb(33, 44, 58);
            panelSidebarBorder.Dock = DockStyle.Right;
            panelSidebarBorder.Location = new Point(249, 0);
            panelSidebarBorder.Name = "panelSidebarBorder";
            panelSidebarBorder.Size = new Size(1, 643);
            panelSidebarBorder.TabIndex = 3;
            // 
            // toolStrip
            // 
            toolStrip.BackColor = Color.FromArgb(12, 17, 23);
            toolStrip.ForeColor = Color.FromArgb(230, 237, 243);
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.ImageScalingSize = new Size(20, 20);
            toolStrip.Items.AddRange(new ToolStripItem[] { tsAdd, tsEdit, tsDelete, sepTool1, tsRefresh, sepTool2, tsPrint, tsExport });
            toolStrip.Location = new Point(0, 33);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new Padding(10, 2, 10, 2);
            toolStrip.Size = new Size(1028, 41);
            toolStrip.TabIndex = 2;
            // 
            // tsAdd
            // 
            tsAdd.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsAdd.Font = new Font("Segoe MDL2 Assets", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsAdd.ForeColor = Color.FromArgb(230, 237, 243);
            tsAdd.Name = "tsAdd";
            tsAdd.Padding = new Padding(6, 4, 6, 4);
            tsAdd.Size = new Size(48, 34);
            tsAdd.Text = "";
            tsAdd.ToolTipText = "Add item";
            tsAdd.Click += tsAdd_Click;
            // 
            // tsEdit
            // 
            tsEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsEdit.Font = new Font("Segoe MDL2 Assets", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsEdit.ForeColor = Color.FromArgb(230, 237, 243);
            tsEdit.Name = "tsEdit";
            tsEdit.Padding = new Padding(6, 4, 6, 4);
            tsEdit.Size = new Size(48, 34);
            tsEdit.Text = "";
            tsEdit.ToolTipText = "Edit selected item";
            tsEdit.Click += tsEdit_Click;
            // 
            // tsDelete
            // 
            tsDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsDelete.Font = new Font("Segoe MDL2 Assets", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsDelete.ForeColor = Color.FromArgb(230, 237, 243);
            tsDelete.Name = "tsDelete";
            tsDelete.Padding = new Padding(6, 4, 6, 4);
            tsDelete.Size = new Size(48, 34);
            tsDelete.Text = "";
            tsDelete.ToolTipText = "Delete selected item";
            tsDelete.Click += tsDelete_Click;
            // 
            // sepTool1
            // 
            sepTool1.Name = "sepTool1";
            sepTool1.Size = new Size(6, 37);
            // 
            // tsRefresh
            // 
            tsRefresh.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsRefresh.Font = new Font("Segoe MDL2 Assets", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsRefresh.ForeColor = Color.FromArgb(230, 237, 243);
            tsRefresh.Name = "tsRefresh";
            tsRefresh.Padding = new Padding(6, 4, 6, 4);
            tsRefresh.Size = new Size(48, 34);
            tsRefresh.Text = "";
            tsRefresh.ToolTipText = "Refresh";
            tsRefresh.Click += tsRefresh_Click;
            // 
            // sepTool2
            // 
            sepTool2.Name = "sepTool2";
            sepTool2.Size = new Size(6, 37);
            // 
            // tsPrint
            // 
            tsPrint.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsPrint.Font = new Font("Segoe MDL2 Assets", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsPrint.ForeColor = Color.FromArgb(230, 237, 243);
            tsPrint.Name = "tsPrint";
            tsPrint.Padding = new Padding(6, 4, 6, 4);
            tsPrint.Size = new Size(48, 34);
            tsPrint.Text = "";
            tsPrint.ToolTipText = "Print inventory";
            tsPrint.Click += tsPrint_Click;
            // 
            // tsExport
            // 
            tsExport.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsExport.Font = new Font("Segoe MDL2 Assets", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tsExport.ForeColor = Color.FromArgb(230, 237, 243);
            tsExport.Name = "tsExport";
            tsExport.Padding = new Padding(6, 4, 6, 4);
            tsExport.Size = new Size(48, 34);
            tsExport.Text = "";
            tsExport.ToolTipText = "Export XML";
            tsExport.Click += tsExport_Click;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.FromArgb(12, 17, 23);
            menuStrip.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuStrip.ForeColor = Color.FromArgb(230, 237, 243);
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { mnuFile, mnuInventory, mnuAudit, mnuReports, mnuHelp, mnuUser });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(8, 4, 8, 4);
            menuStrip.Size = new Size(1028, 33);
            menuStrip.TabIndex = 3;
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuImport, mnuExport, sepFile1, mnuPrint, sepFile2, mnuLogout, mnuExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(48, 25);
            mnuFile.Text = "&File";
            // 
            // mnuImport
            // 
            mnuImport.Name = "mnuImport";
            mnuImport.ShortcutKeys = Keys.Control | Keys.I;
            mnuImport.Size = new Size(261, 26);
            mnuImport.Text = "Import CSV...";
            mnuImport.Click += mnuImport_Click;
            // 
            // mnuExport
            // 
            mnuExport.Name = "mnuExport";
            mnuExport.ShortcutKeys = Keys.Control | Keys.E;
            mnuExport.Size = new Size(261, 26);
            mnuExport.Text = "Export XML...";
            mnuExport.Click += mnuExport_Click;
            // 
            // sepFile1
            // 
            sepFile1.Name = "sepFile1";
            sepFile1.Size = new Size(258, 6);
            // 
            // mnuPrint
            // 
            mnuPrint.Name = "mnuPrint";
            mnuPrint.ShortcutKeys = Keys.Control | Keys.P;
            mnuPrint.Size = new Size(261, 26);
            mnuPrint.Text = "Print inventory...";
            mnuPrint.Click += mnuPrint_Click;
            // 
            // sepFile2
            // 
            sepFile2.Name = "sepFile2";
            sepFile2.Size = new Size(258, 6);
            // 
            // mnuLogout
            // 
            mnuLogout.Name = "mnuLogout";
            mnuLogout.Size = new Size(261, 26);
            mnuLogout.Text = "Log out";
            mnuLogout.Click += mnuLogout_Click;
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuExit.Size = new Size(261, 26);
            mnuExit.Text = "Exit";
            mnuExit.Click += mnuExit_Click;
            // 
            // mnuInventory
            // 
            mnuInventory.DropDownItems.AddRange(new ToolStripItem[] { mnuAddItem, mnuEditItem, mnuDeleteItem, sepInv1, mnuRefresh });
            mnuInventory.Name = "mnuInventory";
            mnuInventory.Size = new Size(90, 25);
            mnuInventory.Text = "&Inventory";
            // 
            // mnuAddItem
            // 
            mnuAddItem.Name = "mnuAddItem";
            mnuAddItem.ShortcutKeys = Keys.Control | Keys.N;
            mnuAddItem.Size = new Size(312, 26);
            mnuAddItem.Text = "Add item";
            mnuAddItem.Click += mnuAddItem_Click;
            // 
            // mnuEditItem
            // 
            mnuEditItem.Name = "mnuEditItem";
            mnuEditItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.E;
            mnuEditItem.Size = new Size(312, 26);
            mnuEditItem.Text = "Edit selected item";
            mnuEditItem.Click += mnuEditItem_Click;
            // 
            // mnuDeleteItem
            // 
            mnuDeleteItem.Name = "mnuDeleteItem";
            mnuDeleteItem.ShortcutKeys = Keys.Delete;
            mnuDeleteItem.Size = new Size(312, 26);
            mnuDeleteItem.Text = "Delete selected item";
            mnuDeleteItem.Click += mnuDeleteItem_Click;
            // 
            // sepInv1
            // 
            sepInv1.Name = "sepInv1";
            sepInv1.Size = new Size(309, 6);
            // 
            // mnuRefresh
            // 
            mnuRefresh.Name = "mnuRefresh";
            mnuRefresh.ShortcutKeys = Keys.F5;
            mnuRefresh.Size = new Size(312, 26);
            mnuRefresh.Text = "Refresh";
            mnuRefresh.Click += mnuRefresh_Click;
            // 
            // mnuAudit
            // 
            mnuAudit.DropDownItems.AddRange(new ToolStripItem[] { mnuViewLogs, mnuGenReport });
            mnuAudit.Name = "mnuAudit";
            mnuAudit.Size = new Size(98, 25);
            mnuAudit.Text = "&Audit Logs";
            // 
            // mnuViewLogs
            // 
            mnuViewLogs.Name = "mnuViewLogs";
            mnuViewLogs.Size = new Size(204, 26);
            mnuViewLogs.Text = "View logs";
            mnuViewLogs.Click += mnuViewLogs_Click;
            // 
            // mnuGenReport
            // 
            mnuGenReport.Name = "mnuGenReport";
            mnuGenReport.Size = new Size(204, 26);
            mnuGenReport.Text = "Generate report";
            mnuGenReport.Click += mnuGenReport_Click;
            // 
            // mnuReports
            // 
            mnuReports.Name = "mnuReports";
            mnuReports.Size = new Size(78, 25);
            mnuReports.Text = "&Reports";
            mnuReports.Click += mnuReports_Click;
            // 
            // mnuHelp
            // 
            mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuAbout });
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Size = new Size(56, 25);
            mnuHelp.Text = "&Help";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(184, 26);
            mnuAbout.Text = "About SEIMS";
            mnuAbout.Click += mnuAbout_Click;
            // 
            // mnuUser
            // 
            mnuUser.Alignment = ToolStripItemAlignment.Right;
            mnuUser.DropDownItems.AddRange(new ToolStripItem[] { mnuUserLogout });
            mnuUser.Name = "mnuUser";
            mnuUser.Size = new Size(68, 25);
            mnuUser.Text = "admin";
            // 
            // mnuUserLogout
            // 
            mnuUserLogout.Name = "mnuUserLogout";
            mnuUserLogout.Size = new Size(147, 26);
            mnuUserLogout.Text = "Log out";
            mnuUserLogout.Click += mnuUserLogout_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(12, 17, 23);
            statusStrip.ForeColor = Color.FromArgb(230, 237, 243);
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { stsOnline, stsAlert, stsUser, stsVersion });
            statusStrip.Location = new Point(0, 717);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1028, 26);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 4;
            // 
            // stsOnline
            // 
            stsOnline.ForeColor = Color.FromArgb(74, 222, 128);
            stsOnline.Name = "stsOnline";
            stsOnline.Size = new Size(120, 20);
            stsOnline.Text = "●  System Online";
            // 
            // stsAlert
            // 
            stsAlert.ForeColor = Color.FromArgb(139, 148, 158);
            stsAlert.Name = "stsAlert";
            stsAlert.Size = new Size(444, 20);
            stsAlert.Spring = true;
            stsAlert.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // stsUser
            // 
            stsUser.ForeColor = Color.FromArgb(139, 148, 158);
            stsUser.Name = "stsUser";
            stsUser.Size = new Size(161, 20);
            stsUser.Text = "User: admin (Admin)   |";
            // 
            // stsVersion
            // 
            stsVersion.ForeColor = Color.FromArgb(139, 148, 158);
            stsVersion.Name = "stsVersion";
            stsVersion.Size = new Size(288, 20);
            stsVersion.Text = "SEIMS v1.0   |   Secure • Reliable • Efficient";
            // 
            // clockTimer
            // 
            clockTimer.Enabled = true;
            clockTimer.Interval = 15000;
            clockTimer.Tick += clockTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(9, 13, 18);
            ClientSize = new Size(1028, 743);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            Controls.Add(toolStrip);
            Controls.Add(menuStrip);
            Controls.Add(statusStrip);
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(1022, 706);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SEIMS - Secure Enterprise Inventory & Audit Management System";
            panelContent.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelSidebar.ResumeLayout(false);
            panelNavBottom.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel viewHost;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblPageIcon;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;
        private SEIMS.UI.Controls.CardPanel panelDate;
        private System.Windows.Forms.Label lblDateIcon;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.FlowLayoutPanel flowNav;
        private SEIMS.UI.Controls.NavButton navDashboard;
        private SEIMS.UI.Controls.NavButton navInventory;
        private SEIMS.UI.Controls.NavButton navAddItem;
        private SEIMS.UI.Controls.NavButton navViewItems;
        private SEIMS.UI.Controls.NavButton navCategories;
        private SEIMS.UI.Controls.NavButton navAudit;
        private SEIMS.UI.Controls.NavButton navViewLogs;
        private SEIMS.UI.Controls.NavButton navGenReport;
        private SEIMS.UI.Controls.NavButton navReports;
        private SEIMS.UI.Controls.NavButton navSettings;
        private System.Windows.Forms.Panel panelNavBottom;
        private SEIMS.UI.Controls.NavButton navLogout;
        private System.Windows.Forms.Panel panelNavLine;
        private System.Windows.Forms.Panel panelLogo;
        private SEIMS.UI.Controls.IconTile tileSidebarLogo;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Panel panelSidebarBorder;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsAdd;
        private System.Windows.Forms.ToolStripButton tsEdit;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator sepTool1;
        private System.Windows.Forms.ToolStripButton tsRefresh;
        private System.Windows.Forms.ToolStripSeparator sepTool2;
        private System.Windows.Forms.ToolStripButton tsPrint;
        private System.Windows.Forms.ToolStripButton tsExport;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuImport;
        private System.Windows.Forms.ToolStripMenuItem mnuExport;
        private System.Windows.Forms.ToolStripSeparator sepFile1;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripSeparator sepFile2;
        private System.Windows.Forms.ToolStripMenuItem mnuLogout;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuInventory;
        private System.Windows.Forms.ToolStripMenuItem mnuAddItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteItem;
        private System.Windows.Forms.ToolStripSeparator sepInv1;
        private System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuAudit;
        private System.Windows.Forms.ToolStripMenuItem mnuViewLogs;
        private System.Windows.Forms.ToolStripMenuItem mnuGenReport;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuUser;
        private System.Windows.Forms.ToolStripMenuItem mnuUserLogout;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel stsOnline;
        private System.Windows.Forms.ToolStripStatusLabel stsAlert;
        private System.Windows.Forms.ToolStripStatusLabel stsUser;
        private System.Windows.Forms.ToolStripStatusLabel stsVersion;
        private System.Windows.Forms.Timer clockTimer;
    }
}
