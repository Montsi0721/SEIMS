namespace SEIMS.UI.Views
{
    partial class ItemsView
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
            this.itemsGrid = new SEIMS.UI.Controls.ItemsGridPanel();
            this.SuspendLayout();
            // 
            // itemsGrid
            // 
            this.itemsGrid.Name = "itemsGrid";
            this.itemsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsGrid.PageSize = 12;
            this.itemsGrid.ShowDateFilter = true;
            this.itemsGrid.Size = new System.Drawing.Size(1068, 650);
            this.itemsGrid.Title = "Inventory Items";
            this.itemsGrid.TabIndex = 0;
            // 
            // ItemsView
            // 
            this.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.Size = new System.Drawing.Size(1068, 650);
            this.Controls.Add(this.itemsGrid);
            this.Name = "ItemsView";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private SEIMS.UI.Controls.ItemsGridPanel itemsGrid;
    }
}
