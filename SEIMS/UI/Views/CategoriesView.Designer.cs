namespace SEIMS.UI.Views
{
    partial class CategoriesView
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
            this.panelRight = new System.Windows.Forms.Panel();
            this.cardDetail = new SEIMS.UI.Controls.CardPanel();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.panelLeft = new SEIMS.UI.Controls.CardPanel();
            this.treeCategories = new System.Windows.Forms.TreeView();
            this.panelToolbar = new System.Windows.Forms.Panel();
            this.lblCategories = new System.Windows.Forms.Label();
            this.btnExpand = new SEIMS.UI.Controls.ThemedButton();
            this.btnCollapse = new SEIMS.UI.Controls.ThemedButton();
            this.panelRight.SuspendLayout();
            this.cardDetail.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRight
            // 
            this.panelRight.Name = "panelRight";
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.panelRight.Size = new System.Drawing.Size(648, 650);
            this.panelRight.Controls.Add(this.cardDetail);
            this.panelRight.TabIndex = 0;
            // 
            // cardDetail
            // 
            this.cardDetail.Name = "cardDetail";
            this.cardDetail.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.cardDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardDetail.Padding = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.cardDetail.Size = new System.Drawing.Size(632, 650);
            this.cardDetail.Controls.Add(this.txtDetail);
            this.cardDetail.TabIndex = 0;
            // 
            // txtDetail
            // 
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.txtDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetail.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetail.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtDetail.Multiline = true;
            this.txtDetail.ReadOnly = true;
            this.txtDetail.Size = new System.Drawing.Size(592, 610);
            this.txtDetail.Text = "Select a category or an item to see its details.";
            this.txtDetail.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panelLeft.Size = new System.Drawing.Size(420, 650);
            this.panelLeft.Controls.Add(this.treeCategories);
            this.panelLeft.Controls.Add(this.panelToolbar);
            this.panelLeft.TabIndex = 1;
            // 
            // treeCategories
            // 
            this.treeCategories.Name = "treeCategories";
            this.treeCategories.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.treeCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCategories.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeCategories.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.treeCategories.ItemHeight = 26;
            this.treeCategories.LineColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.treeCategories.ShowLines = true;
            this.treeCategories.Size = new System.Drawing.Size(418, 592);
            this.treeCategories.TabIndex = 0;
            this.treeCategories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeCategories_AfterSelect);
            // 
            // panelToolbar
            // 
            this.panelToolbar.Name = "panelToolbar";
            this.panelToolbar.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar.Size = new System.Drawing.Size(418, 56);
            this.panelToolbar.Controls.Add(this.lblCategories);
            this.panelToolbar.Controls.Add(this.btnExpand);
            this.panelToolbar.Controls.Add(this.btnCollapse);
            this.panelToolbar.TabIndex = 1;
            // 
            // lblCategories
            // 
            this.lblCategories.Name = "lblCategories";
            this.lblCategories.AutoSize = true;
            this.lblCategories.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategories.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblCategories.Location = new System.Drawing.Point(20, 14);
            this.lblCategories.Text = "Categories";
            this.lblCategories.TabIndex = 0;
            // 
            // btnExpand
            // 
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Kind = SEIMS.UI.Controls.ButtonKind.Secondary;
            this.btnExpand.Location = new System.Drawing.Point(230, 13);
            this.btnExpand.Size = new System.Drawing.Size(80, 30);
            this.btnExpand.Text = "Expand";
            this.btnExpand.TabIndex = 1;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // btnCollapse
            // 
            this.btnCollapse.Name = "btnCollapse";
            this.btnCollapse.Kind = SEIMS.UI.Controls.ButtonKind.Secondary;
            this.btnCollapse.Location = new System.Drawing.Point(316, 13);
            this.btnCollapse.Size = new System.Drawing.Size(80, 30);
            this.btnCollapse.Text = "Collapse";
            this.btnCollapse.TabIndex = 2;
            this.btnCollapse.Click += new System.EventHandler(this.btnCollapse_Click);
            // 
            // CategoriesView
            // 
            this.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.Size = new System.Drawing.Size(1068, 650);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "CategoriesView";
            this.panelRight.ResumeLayout(false);
            this.cardDetail.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelToolbar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelRight;
        private SEIMS.UI.Controls.CardPanel cardDetail;
        private System.Windows.Forms.TextBox txtDetail;
        private SEIMS.UI.Controls.CardPanel panelLeft;
        private System.Windows.Forms.TreeView treeCategories;
        private System.Windows.Forms.Panel panelToolbar;
        private System.Windows.Forms.Label lblCategories;
        private SEIMS.UI.Controls.ThemedButton btnExpand;
        private SEIMS.UI.Controls.ThemedButton btnCollapse;
    }
}
