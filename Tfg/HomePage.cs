using capaEntidad;
using capaNegocio;
using capaPresentacion;
using Google.Protobuf.WellKnownTypes;
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
        cnDgvAllowance cnDgvAllowance = new cnDgvAllowance();
        cnDgvMileage cnDgvMileage = new cnDgvMileage();
        cnDgvUser cnDgvUser = new cnDgvUser();

        public HomePage()
        {
            InitializeComponent();

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            pSolicitudDieta.Visible = false;
            pUsuarios.Visible = false;
            pGestionDietas.Visible = false;

            pGestDietasDietas.Visible = false;
            pGestDietasKilometraje.Visible = false;

            StringBuilder sb = new StringBuilder("User: ", 50);
            sb.Append(ceGlobals.email);
            lbUser.Text = sb.ToString();
            
            ceGlobals.role = cnUser.nameRole(ceGlobals.email);
            lbRole.Text = ceGlobals.role;
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

            cnDgvAllowance.dgvAllowance(dgvDietas);
            cnDgvMileage.dgvUsers(dgvKilometraje);

            dtpTimeDietas.Format = DateTimePickerFormat.Time;
            dtpTimeDietas.ShowUpDown = true;

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
            pGestionDietas.Visible = false;
            pSolicitudDieta.Visible = false;
        }

        private void btnSolDietas_Click(object sender, EventArgs e)
        {
            pUsuarios.Visible = false;
            pGestionDietas.Visible = false;
            pSolicitudDieta.Visible = true;
        }

        private void btnGestDietas_Click(object sender, EventArgs e)
        {
            pUsuarios.Visible = false;
            pGestionDietas.Visible = true;
            pSolicitudDieta.Visible = false;
        }

        private void dgvDietas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvKilometraje_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSolDieta_Click(object sender, EventArgs e)
        {

        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbDepartment.Text = dgvUser.CurrentRow.Cells[0].Value.ToString();
            tbIdUser.Text = dgvUser.CurrentRow.Cells[1].Value.ToString();
            tbEmail.Text = dgvUser.CurrentRow.Cells[2].Value.ToString();
            tbPassword.Text = dgvUser.CurrentRow.Cells[3].Value.ToString();
            tbOcupacion.Text = dgvUser.CurrentRow.Cells[4].Value.ToString();

        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbDepartment.Text = dgvUser.CurrentRow.Cells[0].Value.ToString();
            tbIdUser.Text = dgvUser.CurrentRow.Cells[1].Value.ToString();
            tbEmail.Text = dgvUser.CurrentRow.Cells[2].Value.ToString();
            tbPassword.Text = dgvUser.CurrentRow.Cells[3].Value.ToString();
            tbOcupacion.Text = dgvUser.CurrentRow.Cells[4].Value.ToString();
        }

        private void dgvDietas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbDietasEmail.Text = dgvDietas.CurrentRow.Cells[0].Value.ToString();
            tbDietasTitulo.Text = dgvDietas.CurrentRow.Cells[1].Value.ToString();
            tbDietasObservations.Text = dgvDietas.CurrentRow.Cells[2].Value.ToString();
            tbDietasDate.Text = dgvDietas.CurrentRow.Cells[3].Value.ToString();
            tbDietasStartHour.Text = dgvDietas.CurrentRow.Cells[4].Value.ToString();
            tbDietasEndHour.Text = dgvDietas.CurrentRow.Cells[5].Value.ToString();
            tbDietasState.Text = dgvDietas.CurrentRow.Cells[7].Value.ToString();

        }

        private void dgvKilometraje_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbKilometrajeEmail.Text = dgvKilometraje.CurrentRow.Cells[0].Value.ToString();
            tbKilometrajeTitulo.Text = dgvKilometraje.CurrentRow.Cells[1].Value.ToString();
            tbKilometrajeDate.Text = dgvKilometraje.CurrentRow.Cells[2].Value.ToString();
            tbKilometrajeSubcategory.Text = dgvKilometraje.CurrentRow.Cells[3].Value.ToString();
            tbKilometrajeOrigen.Text = dgvKilometraje.CurrentRow.Cells[4].Value.ToString();
            tbKilometrajeDestino.Text = dgvKilometraje.CurrentRow.Cells[5].Value.ToString();
            tbKilometrajeKilometers.Text = dgvKilometraje.CurrentRow.Cells[6].Value.ToString();
            tbKilometrajePricePerKilometer.Text = dgvKilometraje.CurrentRow.Cells[7].Value.ToString();
            tbKilometrajeFinal.Text = dgvKilometraje.CurrentRow.Cells[8].Value.ToString();
            tbKilometrajeState.Text = dgvKilometraje.CurrentRow.Cells[9].Value.ToString();
            
        }

        private void cbGestDietas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbGestDietas.SelectedItem.Equals("Dietas"))
            {
                pGestDietasDietas.Visible = true;
                pGestDietasKilometraje.Visible = false;
            }
            else
            {
                pGestDietasDietas.Visible = false;
                pGestDietasKilometraje.Visible = true;
            }
        }

        private void cbSolicitudDietas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbGestDietas.SelectedItem.Equals("Dietas"))
            {
                pGestDietasDietas.Visible = true;
                pGestDietasKilometraje.Visible = false;
            }
            else
            {
                pGestDietasDietas.Visible = false;
                pGestDietasKilometraje.Visible = true;
            }
        }
    }
}
