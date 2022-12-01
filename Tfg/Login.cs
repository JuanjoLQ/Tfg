using capaEntidad;
using capaNegocio;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;

namespace Tfg
{
    public partial class Login : Form
    {
        cnUser cnUser = new cnUser();

        public Login()
        {
            InitializeComponent();
        }

        private void tbEmail_Focus(object sender, EventArgs e)
        {
            if (tbEmail.Text == "Email")
            {
                tbEmail.Text = string.Empty;
                tbEmail.ForeColor = Color.Black;
            }
        }

        private void tbEmail_LostFocus(object sender, EventArgs e)
        {
            if (tbEmail.Text == string.Empty)
            {
                tbEmail.Text = "Email";
                tbEmail.ForeColor = Color.DimGray;
            }
        }

        private void tbPassword_Focus(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Password")
            {
                tbPassword.Text = string.Empty;
                tbPassword.ForeColor = Color.Black;
            }
        }

        private void tbPassword_LostFocus(object sender, EventArgs e)
        {
            if (tbPassword.Text == string.Empty)
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
            cnUser.PruebaMySql();
        }

        //
        //
        // Panel Register
        //
        //


        private void tbREmail_Focus(object sender, EventArgs e)
        {
            if (tbREmail.Text == "Email")
            {
                tbREmail.Text = string.Empty;
                tbREmail.ForeColor = Color.Black;
            }
        }
        private void tbREmail_LostFocus(object sender, EventArgs e)
        {
            if (tbREmail.Text == string.Empty)
            {
                tbREmail.Text = "Email";
                tbREmail.ForeColor = Color.DimGray;
            }
        }

        private void tbRPassword_Focus(object sender, EventArgs e)
        {
            if (tbRPassword.Text == "Password")
            {
                tbRPassword.Text = string.Empty;
                tbRPassword.ForeColor = Color.Black;
            }
        }
        private void tbRPassword_LostFocus(object sender, EventArgs e)
        {
            if (tbRPassword.Text == string.Empty)
            {
                tbRPassword.Text = "Password";
                tbRPassword.ForeColor = Color.DimGray;

            }
        }
        
        private void btnRRegistrar_Click(object sender, EventArgs e)
        {
            panelRegister.Visible = false;

            ceUser user = new ceUser(0, tbREmail.Text, tbRPassword.Text);
            
            Debug.WriteLine(tbREmail.Text);
            Debug.WriteLine(tbRPassword.Text);

            
            if (cnUser.ValidarDatos(user) == false)
            {
                return;
            }
            cnUser.CrearUser(user);
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}