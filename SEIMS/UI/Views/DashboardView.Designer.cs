namespace SEIMS.UI.Views
{
    partial class DashboardView
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
            this.tableLower = new System.Windows.Forms.TableLayoutPanel();
            this.itemsGrid = new SEIMS.UI.Controls.ItemsGridPanel();
            this.itemDetails = new SEIMS.UI.Controls.ItemDetailsPanel();
            this.panelSpacer = new System.Windows.Forms.Panel();
            this.tableCards = new System.Windows.Forms.TableLayoutPanel();
            this.cardTotal = new SEIMS.UI.Controls.StatCard();
            this.cardLow = new SEIMS.UI.Controls.StatCard();
            this.cardPerishable = new SEIMS.UI.Controls.StatCard();
            this.cardAudit = new SEIMS.UI.Controls.StatCard();
            this.tableLower.SuspendLayout();
            this.tableCards.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLower
            // 
            this.tableLower.Name = "tableLower";
            this.tableLower.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.tableLower.ColumnCount = 2;
            this.tableLower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLower.RowCount = 1;
            this.tableLower.Size = new System.Drawing.Size(1068, 504);
            this.tableLower.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66F));
            this.tableLower.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLower.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLower.Controls.Add(this.itemsGrid, 0, 0);
            this.tableLower.Controls.Add(this.itemDetails, 1, 0);
            this.tableLower.TabIndex = 0;
            // 
            // itemsGrid
            // 
            this.itemsGrid.Name = "itemsGrid";
            this.itemsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsGrid.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.itemsGrid.PageSize = 10;
            this.itemsGrid.Size = new System.Drawing.Size(688, 504);
            this.itemsGrid.Title = "Recent Inventory Items";
            this.itemsGrid.TabIndex = 0;
            // 
            // itemDetails
            // 
            this.itemDetails.Name = "itemDetails";
            this.itemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemDetails.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.itemDetails.Size = new System.Drawing.Size(360, 504);
            this.itemDetails.TabIndex = 1;
            // 
            // panelSpacer
            // 
            this.panelSpacer.Name = "panelSpacer";
            this.panelSpacer.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.panelSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSpacer.Size = new System.Drawing.Size(1068, 16);
            this.panelSpacer.TabIndex = 1;
            // 
            // tableCards
            // 
            this.tableCards.Name = "tableCards";
            this.tableCards.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.tableCards.ColumnCount = 4;
            this.tableCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableCards.RowCount = 1;
            this.tableCards.Size = new System.Drawing.Size(1068, 130);
            this.tableCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableCards.Controls.Add(this.cardTotal, 0, 0);
            this.tableCards.Controls.Add(this.cardLow, 1, 0);
            this.tableCards.Controls.Add(this.cardPerishable, 2, 0);
            this.tableCards.Controls.Add(this.cardAudit, 3, 0);
            this.tableCards.TabIndex = 2;
            // 
            // cardTotal
            // 
            this.cardTotal.Name = "cardTotal";
            this.cardTotal.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.cardTotal.BorderColor = System.Drawing.Color.FromArgb(33, 44, 58);
            this.cardTotal.Caption = "Total Items";
            this.cardTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTotal.FillColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.cardTotal.Glyph = "\uE7B8";
            this.cardTotal.IconBack = System.Drawing.Color.FromArgb(21, 29, 40);
            this.cardTotal.IconColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.cardTotal.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.cardTotal.Subtitle = "In inventory";
            this.cardTotal.Value = "124";
            this.cardTotal.TabIndex = 0;
            // 
            // cardLow
            // 
            this.cardLow.Name = "cardLow";
            this.cardLow.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.cardLow.BorderColor = System.Drawing.Color.FromArgb(112, 62, 14);
            this.cardLow.Caption = "Low Stock";
            this.cardLow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardLow.FillColor = System.Drawing.Color.FromArgb(38, 23, 10);
            this.cardLow.Glyph = "\uE7BA";
            this.cardLow.IconBack = System.Drawing.Color.FromArgb(64, 36, 12);
            this.cardLow.IconColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.cardLow.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.cardLow.Subtitle = "Below minimum level";
            this.cardLow.Value = "8";
            this.cardLow.TabIndex = 1;
            // 
            // cardPerishable
            // 
            this.cardPerishable.Name = "cardPerishable";
            this.cardPerishable.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.cardPerishable.BorderColor = System.Drawing.Color.FromArgb(24, 92, 52);
            this.cardPerishable.Caption = "Perishable Items";
            this.cardPerishable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardPerishable.FillColor = System.Drawing.Color.FromArgb(10, 33, 23);
            this.cardPerishable.Glyph = "\uE916";
            this.cardPerishable.IconBack = System.Drawing.Color.FromArgb(16, 54, 36);
            this.cardPerishable.IconColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.cardPerishable.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.cardPerishable.Subtitle = "Expiring soon";
            this.cardPerishable.Value = "14";
            this.cardPerishable.TabIndex = 2;
            // 
            // cardAudit
            // 
            this.cardAudit.Name = "cardAudit";
            this.cardAudit.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.cardAudit.BorderColor = System.Drawing.Color.FromArgb(54, 48, 112);
            this.cardAudit.Caption = "Audit Logs";
            this.cardAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardAudit.FillColor = System.Drawing.Color.FromArgb(20, 18, 46);
            this.cardAudit.Glyph = "\uE8A5";
            this.cardAudit.IconBack = System.Drawing.Color.FromArgb(34, 30, 82);
            this.cardAudit.IconColor = System.Drawing.Color.FromArgb(129, 140, 248);
            this.cardAudit.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.cardAudit.Subtitle = "Total records";
            this.cardAudit.Value = "256";
            this.cardAudit.TabIndex = 3;
            // 
            // DashboardView
            // 
            this.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.Size = new System.Drawing.Size(1068, 650);
            this.Controls.Add(this.tableLower);
            this.Controls.Add(this.panelSpacer);
            this.Controls.Add(this.tableCards);
            this.Name = "DashboardView";
            this.tableLower.ResumeLayout(false);
            this.tableLower.PerformLayout();
            this.tableCards.ResumeLayout(false);
            this.tableCards.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLower;
        private SEIMS.UI.Controls.ItemsGridPanel itemsGrid;
        private SEIMS.UI.Controls.ItemDetailsPanel itemDetails;
        private System.Windows.Forms.Panel panelSpacer;
        private System.Windows.Forms.TableLayoutPanel tableCards;
        private SEIMS.UI.Controls.StatCard cardTotal;
        private SEIMS.UI.Controls.StatCard cardLow;
        private SEIMS.UI.Controls.StatCard cardPerishable;
        private SEIMS.UI.Controls.StatCard cardAudit;
    }
}
