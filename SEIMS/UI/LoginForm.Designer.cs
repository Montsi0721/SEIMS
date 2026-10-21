namespace SEIMS.UI
{
    partial class LoginForm
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
            this.tileLogo = new SEIMS.UI.Controls.IconTile();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblTagline = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnLogin = new SEIMS.UI.Controls.ThemedButton();
            this.btnExit = new SEIMS.UI.Controls.ThemedButton();
            this.lblFooter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tileLogo
            // 
            this.tileLogo.Name = "tileLogo";
            this.tileLogo.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.tileLogo.BorderColor = System.Drawing.Color.FromArgb(33, 44, 58);
            this.tileLogo.CornerRadius = 16;
            this.tileLogo.FillColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.tileLogo.Glyph = "\uE7B8";
            this.tileLogo.GlyphColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.tileLogo.GlyphSize = 30.0F;
            this.tileLogo.Location = new System.Drawing.Point(180, 40);
            this.tileLogo.Size = new System.Drawing.Size(80, 80);
            this.tileLogo.TabIndex = 0;
            // 
            // lblBrand
            // 
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.AutoSize = false;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblBrand.Location = new System.Drawing.Point(0, 140);
            this.lblBrand.Size = new System.Drawing.Size(440, 40);
            this.lblBrand.Text = "SEIMS";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBrand.TabIndex = 1;
            // 
            // lblTagline
            // 
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.AutoSize = false;
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.lblTagline.Location = new System.Drawing.Point(0, 182);
            this.lblTagline.Size = new System.Drawing.Size(440, 22);
            this.lblTagline.Text = "Secure Enterprise Inventory & Audit Management System";
            this.lblTagline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTagline.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.AutoSize = false;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblUser.Location = new System.Drawing.Point(60, 238);
            this.lblUser.Size = new System.Drawing.Size(320, 22);
            this.lblUser.Text = "Username";
            this.lblUser.TabIndex = 3;
            // 
            // txtUser
            // 
            this.txtUser.Name = "txtUser";
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtUser.Location = new System.Drawing.Point(60, 262);
            this.txtUser.MaxLength = 50;
            this.txtUser.Size = new System.Drawing.Size(320, 28);
            this.txtUser.TabIndex = 4;
            // 
            // lblPass
            // 
            this.lblPass.Name = "lblPass";
            this.lblPass.AutoSize = false;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.lblPass.Location = new System.Drawing.Point(60, 304);
            this.lblPass.Size = new System.Drawing.Size(320, 22);
            this.lblPass.Text = "Password";
            this.lblPass.TabIndex = 5;
            // 
            // txtPass
            // 
            this.txtPass.Name = "txtPass";
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(21, 29, 40);
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.ForeColor = System.Drawing.Color.FromArgb(230, 237, 243);
            this.txtPass.Location = new System.Drawing.Point(60, 328);
            this.txtPass.MaxLength = 64;
            this.txtPass.Size = new System.Drawing.Size(320, 28);
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.TabIndex = 6;
            // 
            // lblError
            // 
            this.lblError.Name = "lblError";
            this.lblError.AutoSize = false;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113);
            this.lblError.Location = new System.Drawing.Point(60, 366);
            this.lblError.Size = new System.Drawing.Size(320, 36);
            this.lblError.TabIndex = 7;
            // 
            // btnLogin
            // 
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Kind = SEIMS.UI.Controls.ButtonKind.Primary;
            this.btnLogin.Location = new System.Drawing.Point(60, 410);
            this.btnLogin.Size = new System.Drawing.Size(320, 40);
            this.btnLogin.Text = "Sign in";
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Kind = SEIMS.UI.Controls.ButtonKind.Secondary;
            this.btnExit.Location = new System.Drawing.Point(60, 460);
            this.btnExit.Size = new System.Drawing.Size(320, 36);
            this.btnExit.Text = "Exit";
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.TabIndex = 9;
            // 
            // lblFooter
            // 
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.AutoSize = false;
            this.lblFooter.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(139, 148, 158);
            this.lblFooter.Location = new System.Drawing.Point(0, 520);
            this.lblFooter.Size = new System.Drawing.Size(440, 22);
            this.lblFooter.Text = "SEIMS v1.0  |  Secure \u2022 Reliable \u2022 Efficient";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFooter.TabIndex = 10;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(9, 13, 18);
            this.AcceptButton = this.btnLogin;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(440, 560);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SEIMS - Sign in";
            this.Controls.Add(this.tileLogo);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.lblTagline);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblFooter);
            this.Name = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private SEIMS.UI.Controls.IconTile tileLogo;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblTagline;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblError;
        private SEIMS.UI.Controls.ThemedButton btnLogin;
        private SEIMS.UI.Controls.ThemedButton btnExit;
        private System.Windows.Forms.Label lblFooter;
    }
}
