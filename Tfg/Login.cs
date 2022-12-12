using capaEntidad;
using capaNegocio;
using capaPresentacion;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
            if (tbEmail.Text == Res.Email)
            {
                tbEmail.Text = string.Empty;
                tbEmail.ForeColor = Color.Black;
            }
        }

        private void tbEmail_LostFocus(object sender, EventArgs e)
        {
            if (tbEmail.Text == string.Empty)
            {
                tbEmail.Text = Res.Email;
                tbEmail.ForeColor = Color.DimGray;
            }
        }

        private void tbPassword_Focus(object sender, EventArgs e)
        {
            if (tbPassword.Text == Res.Pass)
            {
                tbPassword.Text = string.Empty;
                tbPassword.ForeColor = Color.Black;
            }
        }

        private void tbPassword_LostFocus(object sender, EventArgs e)
        {
            if (tbPassword.Text == string.Empty)
            {
                tbPassword.Text = Res.Pass;
                tbPassword.ForeColor = Color.DimGray;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            panelRegister.Visible = true;
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (cnUser.CheckUser(new ceUser(0, tbEmail.Text, tbPassword.Text)))
            {
                ceGlobals.email = tbEmail.Text;

                HomePage homePage = new HomePage();
                homePage.Show();

            }

            

        }

        //
        //
        // Panel Register
        //
        //

        private void tbREmail_Focus(object sender, EventArgs e)
        {
            if (tbREmail.Text == Res.Email)
            {
                tbREmail.Text = string.Empty;
                tbREmail.ForeColor = Color.Black;
            }
        }
        private void tbREmail_LostFocus(object sender, EventArgs e)
        {
            if (tbREmail.Text == string.Empty)
            {
                tbREmail.Text = Res.Email;
                tbREmail.ForeColor = Color.DimGray;
            }
        }

        private void tbRPassword_Focus(object sender, EventArgs e)
        {
            if (tbRPassword.Text == Res.Pass)
            {
                tbRPassword.Text = string.Empty;
                tbRPassword.ForeColor = Color.Black;
            }
        }
        private void tbRPassword_LostFocus(object sender, EventArgs e)
        {
            if (tbRPassword.Text == string.Empty)
            {
                tbRPassword.Text = Res.Pass;
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
            if(ceGlobals.lang == null)
            {
                Debug.WriteLine("Form load Lang Default");
                ceGlobals.lang = "en-US";
            }
                
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ceGlobals.lang);
            cbLanguage.SelectedIndex = 0;
            GetLanguage();
        }

        private void GetLanguage()
        {
            lbLogin.Text = Res.Login;
            tbEmail.Text = Res.Email;
            tbPassword.Text = Res.Pass;
            btnRegistrar.Text = Res.Register;
            btnLogin.Text = Res.Login;

            lbRegister.Text = Res.Register;
            tbREmail.Text = Res.Email;
            tbRPassword.Text= Res.Pass;
            btnRRegistrar.Text = Res.Register;   

            btnSalir.Text = Res.Exit;

        }

        private void cbLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbLanguage.SelectedItem.Equals("ES - Spanish"))
            {
                ceGlobals.lang = "";
            }
            else
            {
                ceGlobals.lang = "en-US";
            }
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ceGlobals.lang);
            GetLanguage();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
                
    }
}