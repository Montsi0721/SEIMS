using SEIMS.Services;

namespace SEIMS.UI
{
    public partial class LoginForm : Form
    {
        private const int MaxAttempts = 3;
        private int _attempts;

        public LoginForm()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            NativeMethods.UseDarkTitleBar(Handle);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string error = null;

            try
            {
                if (SecurityService.TryLogin(txtUser.Text, txtPass.Text, out error))
                {
                    DialogResult = DialogResult.OK;
                    return;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Could not sign in: " + ex.Message;
                return;
            }

            _attempts++;
            txtPass.Clear();
            txtPass.Focus();

            if (_attempts >= MaxAttempts)
            {
                MessageBox.Show(this, "Too many failed attempts. SEIMS will now close.", "SEIMS",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                return;
            }

            lblError.Text = error + "  (" + (MaxAttempts - _attempts) + " attempt(s) left)";
        }
    }
}
