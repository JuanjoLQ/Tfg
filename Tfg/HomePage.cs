using capaEntidad;
using capaNegocio;
using capaPresentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class HomePage : Form
    {
        bool sidebarExpand;
        bool sidebarSubMenu;
        int aux = 0;
        cnUser cnUser = new cnUser();

        public HomePage()
        {
            InitializeComponent();

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            pSolicitudDieta.Visible = false;
            pUsuarios.Visible = false;
            pGestionDietas.Visible = false;

            StringBuilder sb = new StringBuilder("User: ", 50);
            sb.Append(ceGlobals.email);
            lbUser.Text = sb.ToString();
            
            ceGlobals.role = cnUser.nameRole(ceGlobals.email);

            if (ceGlobals.privileges[1] == 1)
            {
                pGestDietas.Visible = true;
                aux++;
            }
            if (ceGlobals.privileges[2] == 1)
            {
                pGestionUsers.Visible = true;
                aux++;
            }
            if (ceGlobals.privileges[3] == 1)
            {
                pSoliDietas.Visible = true;
                aux++;
            }

            containerModulos.MaximumSize = new Size(180, 37 + 45 * aux);
            containerModulos.Size = new Size(180, 37);

            cnUser.dgvUsers(dgvUser);



            
        }

        // Define min and max size of sizebar
        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void timerSubMenu_Tick(object sender, EventArgs e)
        {
            if (sidebarSubMenu)
            {
                containerModulos.Height -= 5;
                if (containerModulos.Height == containerModulos.MinimumSize.Height)
                {
                    sidebarSubMenu = false;
                    timerSubMenu.Stop();
                }
            }
            else
            {
                containerModulos.Height += 5;
                if (containerModulos.Height == containerModulos.MaximumSize.Height)
                {
                    sidebarSubMenu = true;
                    timerSubMenu.Stop();
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void btnSubMenu_Click(object sender, EventArgs e)
        {
            timerSubMenu.Start();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pUsuarios.Visible = false;
            pSolicitudDieta.Visible = false;
            pGestionDietas.Visible = false;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void pGestionDietas_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRRegistrar_Click(object sender, EventArgs e)
        {
            string role;
            ceUser user = new ceUser(0, tbREmail.Text, tbRPassword.Text);

            Debug.WriteLine(tbREmail.Text);
            Debug.WriteLine(tbRPassword.Text);
            Debug.WriteLine(cbRole.SelectedItem.ToString());
            role = cbRole.SelectedItem.ToString();

            if (cnUser.ValidarDatos(user) == false || role == null)
            {
                return;
            }
            if (cnUser.CrearUser(user, role))
            {
                MessageBox.Show("Usuario creado con éxito.");
            }
            else
            {
                MessageBox.Show("Usuario NO creado con éxito");
            }
        }

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

        private void btnGestUser_Click(object sender, EventArgs e)
        {
            pUsuarios.Visible = true;
            pSolicitudDieta.Visible = false;
            pGestionDietas.Visible = false;
        }

        private void btnSolDietas_Click(object sender, EventArgs e)
        {
            pSolicitudDieta.Visible = true;
            pUsuarios.Visible = false;
            pGestionDietas.Visible = false;
        }

        private void btnGestDietas_Click(object sender, EventArgs e)
        {
            pGestionDietas.Visible = true;
            pSolicitudDieta.Visible = false;
            pUsuarios.Visible = false;
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
