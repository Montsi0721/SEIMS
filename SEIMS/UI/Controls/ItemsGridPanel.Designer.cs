namespace SEIMS.UI.Controls
{
    partial class ItemsGridPanel
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
            this.components = new System.ComponentModel.Container();
            this.gridItems = new SEIMS.UI.Controls.DarkGrid();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblShowing = new System.Windows.Forms.Label();
            this.flowPager = new System.Windows.Forms.FlowLayoutPanel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelSearch = new SEIMS.UI.Controls.CardPanel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.btnFilter = new SEIMS.UI.Controls.ThemedButton();
            this.chkExpiry = new System.Windows.Forms.CheckBox();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.filterMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            this.panelFooter.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelSearch.SuspendLayout();
            this.filterMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridItems
            // 
            this.gridItems.Name = "gridItems";
            this.gridItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colCategory,
            this.colType,
            this.colQuantity,
            this.colStatus,
            this.colActions});
            this.gridItems.TabIndex = 0;
            this.gridItems.SelectionChanged += new System.EventHandler(this.gridItems_SelectionChanged);
            this.gridItems.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridItems_CellPainting);
            this.gridItems.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridItems_CellMouseClick);
            this.gridItems.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridItems_CellMouseMove);
            this.gridItems.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridItems_CellMouseLeave);
            this.gridItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridItems_CellDoubleClick);
            // 
            // colId
            // 
            this.colId.Name = "colId";
            this.colId.FillWeight = 14.0F;
            this.colId.HeaderText = "ID";
            this.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colName
            // 
            this.colName.Name = "colName";
            this.colName.FillWeight = 22.0F;
            this.colName.HeaderText = "Name";
            this.colName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colCategory
            // 
            this.colCategory.Name = "colCategory";
            this.colCategory.FillWeight = 17.0F;
            this.colCategory.HeaderText = "Category";
            this.colCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colType
            // 
            this.colType.Name = "colType";
            this.colType.FillWeight = 12.0F;
            this.colType.HeaderText = "Type";
            this.colType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colQuantity
            // 
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.FillWeight = 10.0F;
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colStatus
            // 
            this.colStatus.Name = "colStatus";
            this.colStatus.FillWeight = 13.0F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colActions
            // 
            this.colActions.Name = "colActions";
            this.colActions.FillWeight = 12.0F;
            this.colActions.HeaderText = "Actions";
            this.colActions.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panelFooter
            // 
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Size = new System.Drawing.Size(758, 62);
            this.panelFooter.Controls.Add(this.lblShowing);
            this.panelFooter.Controls.Add(this.flowPager);
            this.panelFooter.TabIndex = 1;
            // 
            // lblShowing
            // 
            this.lblShowing.Name = "lblShowing";
            this.lblShowing.AutoSize = true;
            this.lblShowing.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowing.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblShowing.Location = new System.Drawing.Point(20, 22);
            this.lblShowing.Text = "Showing 1 - 10 of 124 items";
            this.lblShowing.TabIndex = 0;
            // 
            // flowPager
            // 
            this.flowPager.Name = "flowPager";
            this.flowPager.AutoSize = true;
            this.flowPager.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowPager.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.flowPager.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowPager.Location = new System.Drawing.Point(700, 0);
            this.flowPager.Padding = new System.Windows.Forms.Padding(0, 12, 16, 0);
            this.flowPager.Size = new System.Drawing.Size(58, 62);
            this.flowPager.WrapContents = false;
            this.flowPager.TabIndex = 1;
            // 
            // panelHeader
            // 
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Size = new System.Drawing.Size(758, 68);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.panelSearch);
            this.panelHeader.Controls.Add(this.btnFilter);
            this.panelHeader.Controls.Add(this.chkExpiry);
            this.panelHeader.Controls.Add(this.dtpExpiry);
            this.panelHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Text = "Recent Inventory Items";
            this.lblTitle.TabIndex = 0;
            // 
            // panelSearch
            // 
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.panelSearch.Location = new System.Drawing.Point(368, 15);
            this.panelSearch.Padding = new System.Windows.Forms.Padding(0, 10, 8, 0);
            this.panelSearch.Size = new System.Drawing.Size(320, 38);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Controls.Add(this.lblSearchIcon);
            this.panelSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtSearch.MaxLength = 60;
            this.txtSearch.Size = new System.Drawing.Size(278, 20);
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.PlaceholderText = "Search by name, ID or category...";
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearchIcon
            // 
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.AutoSize = false;
            this.lblSearchIcon.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.lblSearchIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSearchIcon.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchIcon.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.lblSearchIcon.Size = new System.Drawing.Size(34, 28);
            this.lblSearchIcon.Text = "\uE721";
            this.lblSearchIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSearchIcon.TabIndex = 1;
            // 
            // btnFilter
            // 
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Kind = SEIMS.UI.Controls.ButtonKind.Secondary;
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnFilter.Font = new System.Drawing.Font("Segoe MDL2 Assets", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(698, 15);
            this.btnFilter.Size = new System.Drawing.Size(42, 38);
            this.btnFilter.Text = "\uE71C";
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // chkExpiry
            // 
            this.chkExpiry.Name = "chkExpiry";
            this.chkExpiry.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.chkExpiry.AutoSize = true;
            this.chkExpiry.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.chkExpiry.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.chkExpiry.Location = new System.Drawing.Point(138, 22);
            this.chkExpiry.Size = new System.Drawing.Size(100, 19);
            this.chkExpiry.Text = "Expiry before";
            this.chkExpiry.Visible = false;
            this.chkExpiry.TabIndex = 3;
            this.chkExpiry.CheckedChanged += new System.EventHandler(this.chkExpiry_CheckedChanged);
            // 
            // dtpExpiry
            // 
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.dtpExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiry.Location = new System.Drawing.Point(244, 20);
            this.dtpExpiry.Size = new System.Drawing.Size(110, 23);
            this.dtpExpiry.Visible = false;
            this.dtpExpiry.TabIndex = 4;
            this.dtpExpiry.ValueChanged += new System.EventHandler(this.dtpExpiry_ValueChanged);
            // 
            // filterMenu
            // 
            this.filterMenu.Name = "filterMenu";
            this.filterMenu.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.filterMenu.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.filterMenu.Size = new System.Drawing.Size(130, 148);
            this.filterMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFilterAll,
            this.mnuFilterInStock,
            this.mnuFilterLowStock,
            this.mnuFilterVeryLow,
            this.mnuFilterPerishable,
            this.mnuFilterRegular});
            this.filterMenu.Opening += new System.ComponentModel.CancelEventHandler(this.filterMenu_Opening);
            // 
            // ItemsGridPanel
            // 
            this.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Size = new System.Drawing.Size(760, 520);
            this.Controls.Add(this.gridItems);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelHeader);
            this.Name = "ItemsGridPanel";
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.filterMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private SEIMS.UI.Controls.DarkGrid gridItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActions;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblShowing;
        private System.Windows.Forms.FlowLayoutPanel flowPager;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private SEIMS.UI.Controls.CardPanel panelSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchIcon;
        private SEIMS.UI.Controls.ThemedButton btnFilter;
        private System.Windows.Forms.CheckBox chkExpiry;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.ContextMenuStrip filterMenu;
    }
}
