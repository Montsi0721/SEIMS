using System.Text.RegularExpressions;
using SEIMS.Models;
using SEIMS.Services;

namespace SEIMS.UI
{
    /// <summary>Add / edit dialog. Edits a DEEP COPY, so Cancel can never alter the original item.</summary>
    public partial class ItemEditForm : Form
    {
        private readonly InventoryService _svc;
        private readonly InventoryItem _existing;
        private readonly Control[] _perishableControls;

        public InventoryItem ResultItem { get; private set; }

        public ItemEditForm(InventoryService svc, InventoryItem existing)
        {
            _svc = svc;
            _existing = existing;
            InitializeComponent();
            cmbType.SelectedIndex = 0;
            dtExpiry.Value = DateTime.Today.AddDays(14);
            _perishableControls = new Control[] { lblExpiry, dtExpiry, lblMinTemp, numMinTemp, lblMaxTemp, numMaxTemp };

            cmbCategory.DataSource = _svc.Categories.ToList();
            cmbCategory.DisplayMember = "Name";

            var suppliers = new List<Supplier> { new Supplier { Id = 0, Name = "(none)" } };
            suppliers.AddRange(_svc.Suppliers);
            cmbSupplier.DataSource = suppliers;
            cmbSupplier.DisplayMember = "Name";

            if (_existing == null)
            {
                lblHeading.Text = "Add new item";
                Text = "SEIMS - Add item";
            }
            else
            {
                lblHeading.Text = "Edit item";
                Text = "SEIMS - Edit item";
                LoadExisting();
            }

            TogglePerishable();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            NativeMethods.UseDarkTitleBar(Handle);
        }

        private void LoadExisting()
        {
            txtSku.Text = _existing.Sku;
            txtSku.ReadOnly = true;
            txtName.Text = _existing.Name;
            cmbType.SelectedItem = _existing.ItemTypeName;
            cmbType.Enabled = false;
            txtQuantity.Text = _existing.Quantity.ToString();
            txtMin.Text = _existing.MinimumLevel.ToString();
            txtPrice.Text = _existing.UnitPrice.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            txtLocation.Text = _existing.StorageLocation;
            txtDescription.Text = _existing.Description;

            List<Category> cats = (List<Category>)cmbCategory.DataSource;
            int ci = cats.FindIndex(c => c.Id == _existing.CategoryId);
            if (ci >= 0) cmbCategory.SelectedIndex = ci;

            List<Supplier> sups = (List<Supplier>)cmbSupplier.DataSource;
            int si = sups.FindIndex(s => s.Id == (_existing.SupplierId ?? 0));
            if (si >= 0) cmbSupplier.SelectedIndex = si;

            PerishableItem p = _existing as PerishableItem;
            if (p != null)
            {
                DateTime expiry = p.ExpiryDate;
                if (expiry < dtExpiry.MinDate) expiry = dtExpiry.MinDate;
                dtExpiry.Value = expiry;
                numMinTemp.Value = Math.Max(numMinTemp.Minimum, Math.Min(numMinTemp.Maximum, p.MinStorageTempC));
                numMaxTemp.Value = Math.Max(numMaxTemp.Minimum, Math.Min(numMaxTemp.Maximum, p.MaxStorageTempC));
            }
        }

        private void TogglePerishable()
        {
            bool show = cmbType.SelectedItem != null && cmbType.SelectedItem.ToString() == "Perishable";
            foreach (Control c in _perishableControls) c.Visible = show;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_perishableControls != null) TogglePerishable();
        }

        private void numericField_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputSanitizer.AllowDigitsOnly(sender, e);
        }

        private void decimalField_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputSanitizer.AllowDecimalOnly(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            btnSave.Enabled = false;
            try
            {
                ResultItem = BuildItem();
                DialogResult = DialogResult.OK;
            }
            catch (FormatException ex)
            {
                lblError.Text = ex.Message;
            }
            catch (ArgumentException ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private InventoryItem BuildItem()
        {
            bool isNew = _existing == null;

            // text fields are cleaned first (pasted text bypasses the KeyPress guards)
            string sku = InputSanitizer.CleanText(txtSku.Text, 30).ToUpperInvariant();
            string name = InputSanitizer.CleanText(txtName.Text, 100);
            string location = InputSanitizer.CleanText(txtLocation.Text, 100);
            string description = InputSanitizer.CleanText(txtDescription.Text, 500);

            if (isNew)
            {
                if (!Regex.IsMatch(sku, @"^[A-Z0-9\-]{3,30}$"))
                    throw new FormatException("SKU must be 3-30 letters, digits or dashes (for example ITM-125).");
                if (_svc.Warehouse[sku] != null)
                    throw new FormatException("An item with SKU '" + sku + "' already exists.");
            }
            if (name.Length < 2) throw new FormatException("Name is required (at least 2 characters).");
            if (location.Length == 0) throw new FormatException("Storage location is required.");

            int quantity = SafeParser.ToInt32Strict(txtQuantity.Text, "Quantity");
            int minimum = SafeParser.ToInt32Strict(txtMin.Text, "Minimum level");
            decimal price = SafeParser.ToDecimalStrict(txtPrice.Text, "Unit price");

            Category category = cmbCategory.SelectedItem as Category;
            if (category == null) throw new FormatException("Choose a category.");

            Supplier supplier = cmbSupplier.SelectedItem as Supplier;
            int? supplierId = (supplier != null && supplier.Id != 0) ? supplier.Id : (int?)null;

            bool perishable = isNew ? cmbType.SelectedItem.ToString() == "Perishable" : _existing is PerishableItem;
            int minTemp = (int)numMinTemp.Value;
            int maxTemp = (int)numMaxTemp.Value;
            if (perishable && maxTemp < minTemp)
                throw new ArgumentException("Maximum temperature cannot be lower than the minimum.");

            InventoryItem item;
            if (isNew)
            {
                if (perishable)
                    item = new PerishableItem(sku, name, category.Id, quantity, minimum, price, location,
                                              dtExpiry.Value.Date, minTemp, maxTemp);
                else
                    item = new InventoryItem(sku, name, category.Id, quantity, minimum, price, location);
            }
            else
            {
                item = _existing.DeepCopy();     // edit a copy: Cancel leaves the original untouched
                item.Name = name;
                item.Quantity = quantity;
                item.MinimumLevel = minimum;
                item.UnitPrice = price;
                item.StorageLocation = location;

                PerishableItem p = item as PerishableItem;
                if (p != null)
                {
                    p.ExpiryDate = dtExpiry.Value.Date;
                    p.MinStorageTempC = minTemp;
                    p.MaxStorageTempC = maxTemp;
                }
            }

            item.CategoryId = category.Id;
            item.SupplierId = supplierId;
            item.Description = description;
            return item;
        }
    }
}
