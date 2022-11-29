namespace Tfg
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.panelRegister = new System.Windows.Forms.Panel();
            this.btnRRegistrar = new System.Windows.Forms.Button();
            this.lbRegister = new System.Windows.Forms.Label();
            this.tbRPassword = new System.Windows.Forms.TextBox();
            this.tbREmail = new System.Windows.Forms.TextBox();
            this.lbLogin = new System.Windows.Forms.Label();
            this.panelRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.ForeColor = System.Drawing.Color.DimGray;
            this.tbPassword.Location = new System.Drawing.Point(185, 97);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(74, 23);
            this.tbPassword.TabIndex = 2;
            this.tbPassword.Text = "Password";
            this.tbPassword.GotFocus += new System.EventHandler(this.tbPassword_Focus);
            this.tbPassword.LostFocus += new System.EventHandler(this.tbPassword_LostFocus);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(185, 150);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(92, 27);
            this.btnRegistrar.TabIndex = 3;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(185, 194);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(92, 27);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbEmail
            // 
            this.tbEmail.ForeColor = System.Drawing.Color.DimGray;
            this.tbEmail.Location = new System.Drawing.Point(185, 56);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(74, 23);
            this.tbEmail.TabIndex = 1;
            this.tbEmail.Text = "Email";
            this.tbEmail.GotFocus += new System.EventHandler(this.tbEmail_Focus);
            this.tbEmail.LostFocus += new System.EventHandler(this.tbEmail_LostFocus);
            // 
            // panelRegister
            // 
            this.panelRegister.BackColor = System.Drawing.Color.LightGray;
            this.panelRegister.Controls.Add(this.btnRRegistrar);
            this.panelRegister.Controls.Add(this.lbRegister);
            this.panelRegister.Controls.Add(this.tbRPassword);
            this.panelRegister.Controls.Add(this.tbREmail);
            this.panelRegister.Location = new System.Drawing.Point(374, 77);
            this.panelRegister.Name = "panelRegister";
            this.panelRegister.Size = new System.Drawing.Size(306, 248);
            this.panelRegister.TabIndex = 5;
            this.panelRegister.Visible = false;
            // 
            // btnRRegistrar
            // 
            this.btnRRegistrar.Location = new System.Drawing.Point(55, 150);
            this.btnRRegistrar.Name = "btnRRegistrar";
            this.btnRRegistrar.Size = new System.Drawing.Size(92, 27);
            this.btnRRegistrar.TabIndex = 7;
            this.btnRRegistrar.Text = "Registrar";
            this.btnRRegistrar.UseVisualStyleBackColor = true;
            this.btnRRegistrar.Click += new System.EventHandler(this.btnRRegistrar_Click);
            // 
            // lbRegister
            // 
            this.lbRegister.AutoSize = true;
            this.lbRegister.Location = new System.Drawing.Point(73, 10);
            this.lbRegister.Name = "lbRegister";
            this.lbRegister.Size = new System.Drawing.Size(49, 15);
            this.lbRegister.TabIndex = 7;
            this.lbRegister.Text = "Register";
            // 
            // tbRPassword
            // 
            this.tbRPassword.ForeColor = System.Drawing.Color.DimGray;
            this.tbRPassword.Location = new System.Drawing.Point(73, 105);
            this.tbRPassword.Name = "tbRPassword";
            this.tbRPassword.Size = new System.Drawing.Size(74, 23);
            this.tbRPassword.TabIndex = 3;
            this.tbRPassword.Text = "Password";
            this.tbRPassword.GotFocus += new System.EventHandler(this.tbRPassword_Focus);
            this.tbRPassword.LostFocus += new System.EventHandler(this.tbRPassword_LostFocus);
            // 
            // tbREmail
            // 
            this.tbREmail.ForeColor = System.Drawing.Color.DimGray;
            this.tbREmail.Location = new System.Drawing.Point(73, 51);
            this.tbREmail.Name = "tbREmail";
            this.tbREmail.Size = new System.Drawing.Size(74, 23);
            this.tbREmail.TabIndex = 2;
            this.tbREmail.Text = "Email";
            this.tbREmail.GotFocus += new System.EventHandler(this.tbREmail_Focus);
            this.tbREmail.LostFocus += new System.EventHandler(this.tbREmail_LostFocus);
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(185, 22);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(37, 15);
            this.lbLogin.TabIndex = 6;
            this.lbLogin.Text = "Login";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbLogin);
            this.Controls.Add(this.panelRegister);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.tbPassword);
            this.Name = "Login";
            this.Text = "Form1";
            this.panelRegister.ResumeLayout(false);
            this.panelRegister.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox tbPassword;
        private Button btnRegistrar;
        private Button btnLogin;
        private TextBox tbEmail;
        private Panel panelRegister;
        private Button btnRRegistrar;
        private Label lbRegister;
        private TextBox tbRPassword;
        private TextBox tbREmail;
        private Label lbLogin;
    }
}