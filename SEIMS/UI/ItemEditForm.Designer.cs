namespace SEIMS.UI
{
    partial class ItemEditForm
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
            this.panelScroll = new System.Windows.Forms.Panel();
            this.tableFields = new System.Windows.Forms.TableLayoutPanel();
            this.lblSku = new System.Windows.Forms.Label();
            this.txtSku = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.dtExpiry = new System.Windows.Forms.DateTimePicker();
            this.lblMinTemp = new System.Windows.Forms.Label();
            this.numMinTemp = new System.Windows.Forms.NumericUpDown();
            this.lblMaxTemp = new System.Windows.Forms.Label();
            this.numMaxTemp = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSave = new SEIMS.UI.Controls.ThemedButton();
            this.btnCancel = new SEIMS.UI.Controls.ThemedButton();
            this.lblHeading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMinTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTemp)).BeginInit();
            this.panelScroll.SuspendLayout();
            this.tableFields.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelScroll
            // 
            this.panelScroll.Name = "panelScroll";
            this.panelScroll.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.panelScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelScroll.Size = new System.Drawing.Size(540, 504);
            this.panelScroll.AutoScroll = true;
            this.panelScroll.Controls.Add(this.tableFields);
            this.panelScroll.TabIndex = 0;
            // 
            // tableFields
            // 
            this.tableFields.Name = "tableFields";
            this.tableFields.AutoSize = true;
            this.tableFields.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableFields.BackColor = System.Drawing.Color.FromArgb(15, 21, 29);
            this.tableFields.ColumnCount = 2;
            this.tableFields.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableFields.Location = new System.Drawing.Point(0, 0);
            this.tableFields.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.tableFields.RowCount = 13;
            this.tableFields.Size = new System.Drawing.Size(522, 560);
            this.tableFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableFields.Controls.Add(this.lblSku, 0, 0);
            this.tableFields.Controls.Add(this.txtSku, 1, 0);
            this.tableFields.Controls.Add(this.lblName, 0, 1);
            this.tableFields.Controls.Add(this.txtName, 1, 1);
            this.tableFields.Controls.Add(this.lblType, 0, 2);
            this.tableFields.Controls.Add(this.cmbType, 1, 2);
            this.tableFields.Controls.Add(this.lblCategory, 0, 3);
            this.tableFields.Controls.Add(this.cmbCategory, 1, 3);
            this.tableFields.Controls.Add(this.lblSupplier, 0, 4);
            this.tableFields.Controls.Add(this.cmbSupplier, 1, 4);
            this.tableFields.Controls.Add(this.lblQuantity, 0, 5);
            this.tableFields.Controls.Add(this.txtQuantity, 1, 5);
            this.tableFields.Controls.Add(this.lblMin, 0, 6);
            this.tableFields.Controls.Add(this.txtMin, 1, 6);
            this.tableFields.Controls.Add(this.lblPrice, 0, 7);
            this.tableFields.Controls.Add(this.txtPrice, 1, 7);
            this.tableFields.Controls.Add(this.lblLocation, 0, 8);
            this.tableFields.Controls.Add(this.txtLocation, 1, 8);
            this.tableFields.Controls.Add(this.lblExpiry, 0, 9);
            this.tableFields.Controls.Add(this.dtExpiry, 1, 9);
            this.tableFields.Controls.Add(this.lblMinTemp, 0, 10);
            this.tableFields.Controls.Add(this.numMinTemp, 1, 10);
            this.tableFields.Controls.Add(this.lblMaxTemp, 0, 11);
            this.tableFields.Controls.Add(this.numMaxTemp, 1, 11);
            this.tableFields.Controls.Add(this.lblDescription, 0, 12);
            this.tableFields.Controls.Add(this.txtDescription, 1, 12);
            this.tableFields.TabIndex = 0;
            // 
            // lblSku
            // 
            this.lblSku.Name = "lblSku";
            this.lblSku.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSku.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblSku.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblSku.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblSku.Size = new System.Drawing.Size(144, 30);
            this.lblSku.Text = "SKU / ID";
            this.lblSku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSku.TabIndex = 0;
            // 
            // txtSku
            // 
            this.txtSku.Name = "txtSku";
            this.txtSku.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.txtSku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSku.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSku.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtSku.MaxLength = 30;
            this.txtSku.Size = new System.Drawing.Size(352, 27);
            this.txtSku.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtSku.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtSku.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Name = "lblName";
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblName.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblName.Size = new System.Drawing.Size(144, 30);
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Name = "txtName";
            this.txtName.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtName.MaxLength = 100;
            this.txtName.Size = new System.Drawing.Size(352, 27);
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtName.TabIndex = 3;
            // 
            // lblType
            // 
            this.lblType.Name = "lblType";
            this.lblType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblType.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblType.Size = new System.Drawing.Size(144, 30);
            this.lblType.Text = "Type";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblType.TabIndex = 4;
            // 
            // cmbType
            // 
            this.cmbType.Name = "cmbType";
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.cmbType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbType.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Size = new System.Drawing.Size(352, 25);
            this.cmbType.Items.AddRange(new object[] {"Regular", "Perishable"});
            this.cmbType.TabIndex = 5;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblCategory.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblCategory.Size = new System.Drawing.Size(144, 30);
            this.lblCategory.Text = "Category";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCategory.TabIndex = 6;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbCategory.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Size = new System.Drawing.Size(352, 25);
            this.cmbCategory.TabIndex = 7;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSupplier.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblSupplier.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblSupplier.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblSupplier.Size = new System.Drawing.Size(144, 30);
            this.lblSupplier.Text = "Supplier";
            this.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSupplier.TabIndex = 8;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.cmbSupplier.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cmbSupplier.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSupplier.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Size = new System.Drawing.Size(352, 25);
            this.cmbSupplier.TabIndex = 9;
            // 
            // lblQuantity
            // 
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblQuantity.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblQuantity.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblQuantity.Size = new System.Drawing.Size(144, 30);
            this.lblQuantity.Text = "Quantity";
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQuantity.TabIndex = 10;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantity.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtQuantity.MaxLength = 9;
            this.txtQuantity.Size = new System.Drawing.Size(352, 27);
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtQuantity.TabIndex = 11;
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericField_KeyPress);
            // 
            // lblMin
            // 
            this.lblMin.Name = "lblMin";
            this.lblMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMin.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblMin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblMin.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblMin.Size = new System.Drawing.Size(144, 30);
            this.lblMin.Text = "Minimum level";
            this.lblMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMin.TabIndex = 12;
            // 
            // txtMin
            // 
            this.txtMin.Name = "txtMin";
            this.txtMin.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMin.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtMin.MaxLength = 9;
            this.txtMin.Size = new System.Drawing.Size(352, 27);
            this.txtMin.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtMin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtMin.TabIndex = 13;
            this.txtMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericField_KeyPress);
            // 
            // lblPrice
            // 
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblPrice.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblPrice.Size = new System.Drawing.Size(144, 30);
            this.lblPrice.Text = "Unit price (M)";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPrice.TabIndex = 14;
            // 
            // txtPrice
            // 
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtPrice.MaxLength = 12;
            this.txtPrice.Size = new System.Drawing.Size(352, 27);
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPrice.TabIndex = 15;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.decimalField_KeyPress);
            // 
            // lblLocation
            // 
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblLocation.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblLocation.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblLocation.Size = new System.Drawing.Size(144, 30);
            this.lblLocation.Text = "Storage location";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLocation.TabIndex = 16;
            // 
            // txtLocation
            // 
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtLocation.MaxLength = 100;
            this.txtLocation.Size = new System.Drawing.Size(352, 27);
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtLocation.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtLocation.TabIndex = 17;
            // 
            // lblExpiry
            // 
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExpiry.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblExpiry.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblExpiry.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblExpiry.Size = new System.Drawing.Size(144, 30);
            this.lblExpiry.Text = "Expiry date";
            this.lblExpiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblExpiry.TabIndex = 18;
            // 
            // dtExpiry
            // 
            this.dtExpiry.Name = "dtExpiry";
            this.dtExpiry.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.dtExpiry.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpiry.Size = new System.Drawing.Size(352, 23);
            this.dtExpiry.TabIndex = 19;
            // 
            // lblMinTemp
            // 
            this.lblMinTemp.Name = "lblMinTemp";
            this.lblMinTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinTemp.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblMinTemp.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblMinTemp.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblMinTemp.Size = new System.Drawing.Size(144, 30);
            this.lblMinTemp.Text = "Min temp (\u00B0C)";
            this.lblMinTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMinTemp.TabIndex = 20;
            // 
            // numMinTemp
            // 
            this.numMinTemp.Name = "numMinTemp";
            this.numMinTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.numMinTemp.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.numMinTemp.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.numMinTemp.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.numMinTemp.Maximum = new decimal(new int[] {60, 0, 0, 0});
            this.numMinTemp.Minimum = new decimal(new int[] {40, 0, 0, -2147483648});
            this.numMinTemp.Size = new System.Drawing.Size(352, 23);
            this.numMinTemp.Value = new decimal(new int[] {2, 0, 0, 0});
            this.numMinTemp.TabIndex = 21;
            // 
            // lblMaxTemp
            // 
            this.lblMaxTemp.Name = "lblMaxTemp";
            this.lblMaxTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxTemp.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblMaxTemp.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblMaxTemp.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblMaxTemp.Size = new System.Drawing.Size(144, 30);
            this.lblMaxTemp.Text = "Max temp (\u00B0C)";
            this.lblMaxTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMaxTemp.TabIndex = 22;
            // 
            // numMaxTemp
            // 
            this.numMaxTemp.Name = "numMaxTemp";
            this.numMaxTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.numMaxTemp.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.numMaxTemp.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.numMaxTemp.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.numMaxTemp.Maximum = new decimal(new int[] {60, 0, 0, 0});
            this.numMaxTemp.Minimum = new decimal(new int[] {40, 0, 0, -2147483648});
            this.numMaxTemp.Size = new System.Drawing.Size(352, 23);
            this.numMaxTemp.Value = new decimal(new int[] {5, 0, 0, 0});
            this.numMaxTemp.TabIndex = 23;
            // 
            // lblDescription
            // 
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblDescription.MinimumSize = new System.Drawing.Size(0, 30);
            this.lblDescription.Size = new System.Drawing.Size(144, 30);
            this.lblDescription.Text = "Description";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDescription.TabIndex = 24;
            // 
            // txtDescription
            // 
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Size = new System.Drawing.Size(352, 80);
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDescription.Multiline = true;
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.TabIndex = 25;
            // 
            // panelFooter
            // 
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Size = new System.Drawing.Size(540, 96);
            this.panelFooter.Controls.Add(this.lblError);
            this.panelFooter.Controls.Add(this.btnSave);
            this.panelFooter.Controls.Add(this.btnCancel);
            this.panelFooter.TabIndex = 1;
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.AutoSize = false;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            this.lblError.Location = new System.Drawing.Point(24, 8);
            this.lblError.Size = new System.Drawing.Size(492, 36);
            this.lblError.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Kind = SEIMS.UI.Controls.ButtonKind.Primary;
            this.btnSave.Location = new System.Drawing.Point(236, 48);
            this.btnSave.Size = new System.Drawing.Size(140, 36);
            this.btnSave.Text = "Save item";
            this.btnSave.TabIndex = 1;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Kind = SEIMS.UI.Controls.ButtonKind.Secondary;
            this.btnCancel.Location = new System.Drawing.Point(386, 48);
            this.btnCancel.Size = new System.Drawing.Size(130, 36);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.TabIndex = 2;
            // 
            // lblHeading
            // 
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.AutoSize = false;
            this.lblHeading.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblHeading.Padding = new System.Windows.Forms.Padding(24, 0, 0, 0);
            this.lblHeading.Size = new System.Drawing.Size(540, 60);
            this.lblHeading.Text = "Item";
            this.lblHeading.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeading.TabIndex = 2;
            // 
            // ItemEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(540, 660);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SEIMS - Item";
            this.Controls.Add(this.panelScroll);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.lblHeading);
            this.Name = "ItemEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.numMinTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTemp)).EndInit();
            this.panelScroll.ResumeLayout(false);
            this.tableFields.ResumeLayout(false);
            this.tableFields.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelScroll;
        private System.Windows.Forms.TableLayoutPanel tableFields;
        private System.Windows.Forms.Label lblSku;
        private System.Windows.Forms.TextBox txtSku;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblExpiry;
        private System.Windows.Forms.DateTimePicker dtExpiry;
        private System.Windows.Forms.Label lblMinTemp;
        private System.Windows.Forms.NumericUpDown numMinTemp;
        private System.Windows.Forms.Label lblMaxTemp;
        private System.Windows.Forms.NumericUpDown numMaxTemp;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblError;
        private SEIMS.UI.Controls.ThemedButton btnSave;
        private SEIMS.UI.Controls.ThemedButton btnCancel;
        private System.Windows.Forms.Label lblHeading;
    }
}
