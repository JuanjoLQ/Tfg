using Microsoft.VisualBasic.ApplicationServices;

namespace Tfg
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void tbEmail_Focus(object sender, EventArgs e)
        {
            if (tbEmail.Text == "Email")
            {
                tbEmail.Text = "";
                tbEmail.ForeColor = Color.Black;
            }
        }

        private void tbEmail_LostFocus(object sender, EventArgs e)
        {
            if (tbEmail.Text == "")
            {
                tbEmail.Text = "Email";
                tbEmail.ForeColor = Color.DimGray;
            }
        }

        private void tbPassword_Focus(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Password")
            {
                tbPassword.Text = "";
                tbPassword.ForeColor = Color.Black;
            }
        }

        private void tbPassword_LostFocus(object sender, EventArgs e)
        {
            if (tbPassword.Text == "")
            {
                tbPassword.Text = "Password";
                tbPassword.ForeColor = Color.DimGray;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            panelRegister.Visible = true;
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        //
        //
        // Panel Register
        //
        //

        private void btnRRegistrar_Click(object sender, EventArgs e)
        {
            panelRegister.Visible = false;
        }

        private void tbREmail_Focus(object sender, EventArgs e)
        {
            if (tbREmail.Text == "Email")
            {
                tbREmail.Text = "";
                tbREmail.ForeColor = Color.Black;
            }
        }
        private void tbREmail_LostFocus(object sender, EventArgs e)
        {
            if (tbREmail.Text == "")
            {
                tbREmail.Text = "Email";
                tbREmail.ForeColor = Color.DimGray;
            }
        }

        private void tbRPassword_Focus(object sender, EventArgs e)
        {
            if (tbRPassword.Text == "Password")
            {
                tbRPassword.Text = "";
                tbRPassword.ForeColor = Color.Black;
            }
        }
        private void tbRPassword_LostFocus(object sender, EventArgs e)
        {
            if (tbRPassword.Text == "")
            {
                tbRPassword.Text = "Password";
                tbRPassword.ForeColor = Color.DimGray;
            }
        }


    }
}