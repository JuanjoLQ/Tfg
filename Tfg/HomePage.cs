using capaDatos;
using capaEntidad;
using capaNegocio;
using capaPresentacion;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
using Tfg;

namespace capaPresentacion
{
    public partial class HomePage : Form
    {
        bool sidebarExpand;
        bool sidebarSubMenu;
        int aux = 0;
        cnUser cnUser = new cnUser();
        cnAllowance cnAllowance = new cnAllowance();
        cnMileage cnMileage = new cnMileage();
        cnDgvAllowance cnDgvAllowance = new cnDgvAllowance();
        cnDgvMileage cnDgvMileage = new cnDgvMileage();
        cnDgvUser cnDgvUser = new cnDgvUser();
        cdGlobals cdGlobals = new cdGlobals();

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

            cdGlobals.setId(ceGlobals.email);

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

            containerModulos.MaximumSize = new Size(180, 37 + 67 * aux);
            containerModulos.Size = new Size(180, 37);

            cnUser.dgvUsers(dgvUser);

            cnDgvAllowance.dgvAllowance(dgvAllowances);
            cnDgvMileage.dgvMileage(dgvMileage);

            pSolSolicitudDietas.Visible = false;
            pSolKilometraje.Visible = false;

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ceGlobals.lang);
            GetLanguage(); ;
            

        }

        private void GetLanguage()
        {
            translateBars();
            translateModules();
        }

        private void translateBars()
        {
            btnSalirHome.Text = Res.Exit;
            btnSubMenu.Text = Res.modules;
            btnGestUsers.Text = Res.pManUsers;
            btnSolDietas.Text = Res.pSolAllowance;
            btnGestDietas.Text = Res.pManAllowance;
            btnSettings.Text = Res.pSettings;
            lbTitle.Text = Res.lbHomePage;
            lbRole.Text = Res.lbRole;
            lbUser.Text = Res.lbUser;
            lbMenu.Text = Res.lbMenu;
            
        }

        private void translateModules()
        {
            translateUsers();
            translateSolAllowances();
            translateManageAllowances();

        }

        private void translateUsers()
        {
            // Labels y textboxs
            lbGestUsers.Text = Res.lbGestUsers;
            lbRegisterUser.Text = Res.lbRegisterUser;
            tbREmail.PlaceholderText = Res.Email;
            tbRPassword.PlaceholderText = Res.Pass;
            btnRRegistrar.Text = Res.btnRegistrar;
            btnUpdateDtgUsers.Text = Res.updateTable;
            btnEliminarUser.Text = Res.removeUser;

            tbEmail.PlaceholderText = Res.Email;
            tbPassword.PlaceholderText = Res.Pass;
            tbDepartment.PlaceholderText = Res.department;
            tbIdUser.PlaceholderText = Res.idUser;
            tbOcupacion.PlaceholderText = Res.job;

            // dgvUser
            dgvUser.Columns[0].HeaderText = Res.idUser;
            dgvUser.Columns[1].HeaderText = Res.Email;
            dgvUser.Columns[2].HeaderText = Res.Pass;
            dgvUser.Columns[3].HeaderText = Res.department;
            dgvUser.Columns[4].HeaderText = Res.job;

        }
        private void translateSolAllowances()
        {
            lbTitleSolDieta.Text = Res.lbTitleReqAllowances;
            lbReqAllowancesOptions.Text = Res.lbReqAllowancesOptions;

            // Allowances
            lbReqAllowancesTitleAllowances.Text = Res.allowances;
            lbReqAllowancesTitle.Text = Res.title;
            lbReqAllowancesObservations.Text = Res.observations;
            lbReqAllowancesStartHour.Text = Res.startHour;
            lbReqAllowancesEndHour.Text = Res.endHour;
            lbReqAllowancesDate.Text = Res.date;

            tbReqAllowancesTitle.PlaceholderText = Res.title;
            tbReqAllowancesObservations.PlaceholderText = Res.observations;

            btnReqAllowancesUploadFile.Text = Res.UploadFile;
            btnRequestAllowances.Text = Res.requestAllowance;

            // Mileages
            lbMileageTitle.Text = Res.mileage;
            lbReqMileage.Text = Res.mileage;
            lbTitleMileage.Text = Res.title;
            lbReqMileageDate.Text = Res.date;
            lbReqMileageSubcategory.Text = Res.subcategory;
            lbReqMileageOrigin.Text = Res.origin;
            lbReqMileageDestination.Text = Res.destination;
            lbReqMileageTotal.Text = Res.total;
            lbReqMileagePricePerKilometer.Text = Res.pricePerKilometer;

            tbReqMileageMileage.PlaceholderText = Res.kilometers;
            tbReqMileageTitle.PlaceholderText = Res.title;
            tbReqMileageOrigin.PlaceholderText = Res.origin;
            tbReqMileageDestination.PlaceholderText = Res.destination;
            tbReqMileageTotal.PlaceholderText = Res.total;
            tbReqMileagePricePerKilometer.PlaceholderText = Res.pricePerKilometer;

            btnSolDietasSolKilometraje.Text = Res.requestMileage;

        }

        private void translateManageAllowances()
        {
            lbManAllowances.Text = Res.manageAllowances;
            lbManAllowancesOptions.Text = Res.lbReqAllowancesOptions;

            // Allowances
            lbTitleManAllowance.Text = Res.allowances;

            // dgvAllowances
            dgvAllowances.Columns[0].HeaderText = Res.idAllowance;
            dgvAllowances.Columns[1].HeaderText = Res.Email;
            dgvAllowances.Columns[2].HeaderText = Res.title;
            dgvAllowances.Columns[3].HeaderText = Res.observations;
            dgvAllowances.Columns[4].HeaderText = Res.date;
            dgvAllowances.Columns[5].HeaderText = Res.startHour;
            dgvAllowances.Columns[6].HeaderText = Res.endHour;
            dgvAllowances.Columns[7].HeaderText = Res.invoice;
            dgvAllowances.Columns[8].HeaderText = Res.state;

            // label
            lbManAllowancesEmail.Text = Res.Email;
            lbManAllowancesTitle.Text = Res.title;
            lbManAllowancesObservations.Text = Res.observations;
            lbManAllowancesDate.Text = Res.date;
            lbManAllowancesStartHour.Text = Res.startHour;
            lbManAllowancesEndHour.Text = Res.endHour;
            lbManAllowancesState.Text = Res.state;
            lbManAllowancesNewState.Text = Res.newState;
            lbManAllowancesIdAllowance.Text = Res.idAllowance;

            // textbutton
            tbManAllowancesEmail.PlaceholderText = Res.Email;
            tbManAllowancesTitle.PlaceholderText = Res.title;
            tbManAllowancesObservations.PlaceholderText = Res.observations;
            tbManAllowancesDate.PlaceholderText = Res.date;
            tbManAllowancesStartHour.PlaceholderText = Res.startHour;
            tbManAllowancesEndHour.PlaceholderText = Res.endHour;
            tbManAllowancesState.PlaceholderText = Res.state;
            tbManAllowancesIdAllowance.PlaceholderText = Res.idAllowance;

            // button
            btnManAllowancesDietasRefresh.Text = Res.updateTable;
            btnManAllowancesUpdateData.Text = Res.updateAllowance;
            btnManAllowancesAllowanceRemove.Text = Res.removeAllowance;

            // Mileages
            lbTitleManMileage.Text = Res.mileage;

            // dgvMileage
            dgvMileage.Columns[0].HeaderText = Res.idMileage;
            dgvMileage.Columns[1].HeaderText = Res.Email;
            dgvMileage.Columns[2].HeaderText = Res.title;
            dgvMileage.Columns[3].HeaderText = Res.date;
            dgvMileage.Columns[4].HeaderText = Res.subcategory;
            dgvMileage.Columns[5].HeaderText = Res.origin;
            dgvMileage.Columns[6].HeaderText = Res.destination;
            dgvMileage.Columns[7].HeaderText = Res.kilometers;
            dgvMileage.Columns[8].HeaderText = Res.pricePerKilometer;
            dgvMileage.Columns[9].HeaderText = Res.final;
            dgvMileage.Columns[10].HeaderText = Res.state;

            // label
            lbManMileageEmail.Text = Res.Email;
            lbManMileageTitle.Text = Res.title;
            lbManMileageDate.Text = Res.date;
            lbManMileageSubcategory.Text = Res.subcategory;
            lbManMileageIdMileage.Text = Res.idMileage;
            lbManMileageOrigin.Text = Res.origin;
            lbManMileageDestination.Text = Res.destination;
            lbManMileageKilometers.Text = Res.kilometers;
            lbManMileagePricePerKilometer.Text = Res.pricePerKilometer;
            lbManMileageFinal.Text = Res.final;
            lbManMileageState.Text = Res.state;
            lbManMileageNewState.Text = Res.newState;

            // Textbox
            tbManMileageEmail.PlaceholderText = Res.Email;
            tbManMileageTitle.PlaceholderText = Res.title;
            tbManMileageDate.PlaceholderText = Res.date;
            tbManMileageSubcategory.PlaceholderText = Res.subcategory;
            tbManMileageIdMileage.PlaceholderText = Res.idMileage;
            tbManMileageOrigin.PlaceholderText = Res.origin;
            tbManMileageDestination.PlaceholderText = Res.destination;
            tbManMileageKilometers.PlaceholderText = Res.kilometers;
            tbManMileagePricePerKilometer.PlaceholderText = Res.pricePerKilometer;
            tbManMileageFinal.PlaceholderText = Res.final;
            tbManMileageState.PlaceholderText = Res.state;

            // button
            btnManMileageRefreshDgvMileage.Text = Res.updateTable;
            btnManMileageUpdateStateMileage.Text = Res.updateMileage;
            btnManMileageRemoveMileage.Text = Res.removeMileage;

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
            string role, departamento;
            ceUser user = new ceUser(0, tbREmail.Text, tbRPassword.Text);

            Debug.WriteLine(tbREmail.Text);
            Debug.WriteLine(tbRPassword.Text);
            Debug.WriteLine(cbRole.SelectedItem.ToString());
            role = cbRole.SelectedItem.ToString();
            departamento = cbDepartamento.SelectedItem.ToString();

            if (cnUser.ValidarDatos(user) == false || role == null)
            {
                return;
            }
            if (cnUser.CrearUser(user, role, departamento))
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

        private void dgvKilometraje_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /*
        private void btnSolDieta_Click(object sender, EventArgs e)
        {
            ceAllowance allowance = new ceAllowance()


            cnAllowance.insAllowance(allowance);
            
        }
        */

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
            tbManAllowancesIdAllowance.Text = dgvAllowances.CurrentRow.Cells[0].Value.ToString();
            tbManAllowancesEmail.Text = dgvAllowances.CurrentRow.Cells[1].Value.ToString();
            tbManAllowancesTitle.Text = dgvAllowances.CurrentRow.Cells[2].Value.ToString();
            tbManAllowancesObservations.Text = dgvAllowances.CurrentRow.Cells[3].Value.ToString();
            tbManAllowancesDate.Text = dgvAllowances.CurrentRow.Cells[4].Value.ToString();
            tbManAllowancesStartHour.Text = dgvAllowances.CurrentRow.Cells[5].Value.ToString();
            tbManAllowancesEndHour.Text = dgvAllowances.CurrentRow.Cells[6].Value.ToString();
            tbManAllowancesState.Text = dgvAllowances.CurrentRow.Cells[8].Value.ToString();

        }

        private void dgvKilometraje_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbManMileageIdMileage.Text = dgvMileage.CurrentRow.Cells[0].Value.ToString();
            tbManMileageEmail.Text = dgvMileage.CurrentRow.Cells[1].Value.ToString();
            tbManMileageTitle.Text = dgvMileage.CurrentRow.Cells[2].Value.ToString();
            tbManMileageDate.Text = dgvMileage.CurrentRow.Cells[3].Value.ToString();
            tbManMileageSubcategory.Text = dgvMileage.CurrentRow.Cells[4].Value.ToString();
            tbManMileageOrigin.Text = dgvMileage.CurrentRow.Cells[5].Value.ToString();
            tbManMileageDestination.Text = dgvMileage.CurrentRow.Cells[6].Value.ToString();
            tbManMileageKilometers.Text = dgvMileage.CurrentRow.Cells[7].Value.ToString();
            tbManMileagePricePerKilometer.Text = dgvMileage.CurrentRow.Cells[8].Value.ToString();
            tbManMileageFinal.Text = dgvMileage.CurrentRow.Cells[9].Value.ToString();
            tbManMileageState.Text = dgvMileage.CurrentRow.Cells[10].Value.ToString();
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
            if (cbSolicitudDietas.SelectedItem.Equals("Dietas"))
            {
                pSolSolicitudDietas.Visible = true;
                pSolKilometraje.Visible = false;
            }
            else
            {
                pSolSolicitudDietas.Visible = false;
                pSolKilometraje.Visible = true;
            }
        }

        private void mtbStartTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string[] arr = mtbReqAllowancesStartHour.Text.Split(':');
                int hours = int.Parse(arr[0].ToString());
                int mins = int.Parse(arr[1].ToString());
                DateTime time = Convert.ToDateTime(mtbReqAllowancesStartHour.Text).AddHours(hours).AddMinutes(mins);
                tbReqAllowancesTitle.Text = time.ToString("hh:mm");
            }
        }

        private void mtbStartTime_Click(object sender, EventArgs e)
        {
            mtbReqAllowancesStartHour.SelectionStart = 0;
        }

        private void mtbStartTime_Leave(object sender, EventArgs e)
        {
            char[] arr = mtbReqAllowancesStartHour.Text.ToCharArray(0, 5);

            if (int.Parse(arr[0].ToString()) > 2 || int.Parse(arr[1].ToString()) > 4 || int.Parse(arr[3].ToString()) > 5)
            {
                mtbReqAllowancesStartHour.Text = "";
                MessageBox.Show("Fecha no válida");
            }
        }

        private void mtbEndTime_Leave(object sender, EventArgs e)
        {
            char[] arr = mtbReqAllowancesEndHour.Text.ToCharArray(0, 5);

            if (int.Parse(arr[0].ToString()) > 2 || int.Parse(arr[1].ToString()) > 4 || int.Parse(arr[3].ToString()) > 5)
            {
                mtbReqAllowancesStartHour.Text = "";
                MessageBox.Show("Fecha no válida");
            }
        }

        private void btnUpdateDtgUsers_Click(object sender, EventArgs e)
        {
            dgvUser.Update();
            dgvUser.Refresh();
            cnUser.dgvUsers(dgvUser);
            tbDepartment.Text = string.Empty;
            tbOcupacion.Text = string.Empty;
            tbIdUser.Text = string.Empty;
            tbPassword.Text = string.Empty;
            tbEmail.Text = string.Empty;
        }

        private void btnGestDietasDietasRefresh_Click(object sender, EventArgs e)
        {
            dgvAllowances.Update();
            dgvAllowances.Refresh();
            cnDgvAllowance.dgvAllowance(dgvAllowances);
            dgvUser.Update();
            dgvUser.Refresh();
            cnUser.dgvUsers(dgvUser);
            tbManAllowancesEmail.Text = string.Empty;
            tbManAllowancesTitle.Text = string.Empty;
            tbManAllowancesObservations.Text = string.Empty;
            tbManAllowancesDate.Text = string.Empty;
            tbManAllowancesStartHour.Text = string.Empty;
            tbManAllowancesEndHour.Text = string.Empty;
            tbManAllowancesState.Text = string.Empty;
            tbManAllowancesIdAllowance.Text = string.Empty;
            cbStateDietas.Text = string.Empty;
        }

        private void btnEliminarUser_Click(object sender, EventArgs e)
        {
            string idUser = dgvUser.CurrentRow.Cells[0].Value.ToString();
            cnUser.delUser(int.Parse(idUser));
            tbDepartment.Text = string.Empty;
            tbOcupacion.Text = string.Empty;
            tbIdUser.Text = string.Empty;
            tbPassword.Text = string.Empty;
            tbEmail.Text = string.Empty;
        }

        string cadenaConexion = "Server=localhost;User=root;Password=TFG_ERP_C#;Port=3306;database=mydb;";

        public void UploadFile(String file)
        {
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd;
            conn.Open();

            FileStream fileStream = File.OpenRead(file);
            byte[] contents = new byte[fileStream.Length];
            fileStream.Read(contents, 0, (int)fileStream.Length);
            fileStream.Close();

            using (cmd = new MySqlCommand("insert into allowance(User_idUser, Title, Observations, State, StartTime, StartHour, EndHour, Invoice) " +
                "values(@idUser, @title, @observations, @state, @startTime, @startHour, @endHour, @invoice)", conn))
            {
                cmd.Parameters.AddWithValue("@idUser", cnUser.idUser(ceGlobals.email));
                cmd.Parameters.AddWithValue("@title", tbReqAllowancesTitle.Text);
                cmd.Parameters.AddWithValue("@observations", tbReqAllowancesObservations.Text);
                cmd.Parameters.AddWithValue("@state", "Solicitado");
                cmd.Parameters.AddWithValue("@startTime", dtpReqAllowancesStartTime.Text);
                cmd.Parameters.AddWithValue("@startHour", mtbReqAllowancesStartHour.Text);
                cmd.Parameters.AddWithValue("@endHour", mtbReqAllowancesEndHour.Text);
                cmd.Parameters.AddWithValue("@invoice", contents);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Finished uploading files", "Juanjo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }
        private string fileName = "";
        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofdUpload = new OpenFileDialog () { Filter = "Text Documents (*.pdf;) |*.pdf", ValidateNames = true})
            {
                if(ofdUpload.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("Are you sure want to upload this files?", "Juanjo", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    
                    if(dialog == DialogResult.Yes)
                    {
                        fileName = ofdUpload.FileName;                        
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private void btnSolDieta_Click(object sender, EventArgs e)
        {

            if (!tbReqAllowancesTitle.Equals("") && !tbReqAllowancesObservations.Equals("") && !dtpReqAllowancesStartTime.Equals("") 
                && !mtbReqAllowancesStartHour.Equals("") && !mtbReqAllowancesEndHour.Equals("") && !fileName.Equals(""))
            {
                UploadFile(fileName);
            }
            else
            {
                MessageBox.Show("Dieta no subida");
            }
        }

        private void btnSalirHome_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbStateDietas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbManAllowancesState.Text = cbStateDietas.SelectedItem.ToString();
        }

        private void btnGestDietasUpdate_Click(object sender, EventArgs e)
        {
            cnAllowance.updateAllowance(int.Parse(dgvAllowances.CurrentRow.Cells[0].Value.ToString()), tbManAllowancesState.Text);
            tbManAllowancesEmail.Text = string.Empty;
            tbManAllowancesTitle.Text = string.Empty;
            tbManAllowancesObservations.Text = string.Empty;
            tbManAllowancesDate.Text = string.Empty;
            tbManAllowancesStartHour.Text = string.Empty;
            tbManAllowancesEndHour.Text = string.Empty;
            tbManAllowancesState.Text = string.Empty;
            tbManAllowancesIdAllowance.Text = string.Empty;
            cbStateDietas.Text = string.Empty;
        }

        private void cbMileageState_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbManMileageState.Text = cbManMileageNewState.SelectedItem.ToString();
        }

        private void btnUpdateStateMileage_Click(object sender, EventArgs e)
        {
            cnMileage.updateMileage(int.Parse(dgvMileage.CurrentRow.Cells[0].Value.ToString()), tbManMileageState.Text);
        }

        private void btnRefreshDgvMileage_Click(object sender, EventArgs e)
        {
            dgvMileage.Update();
            dgvMileage.Refresh();
            cnDgvMileage.dgvMileage(dgvMileage);

            tbManMileageEmail.Text = string.Empty;
            tbManMileageTitle.Text = string.Empty;
            tbManMileageDate.Text = string.Empty;
            tbManMileageSubcategory.Text = string.Empty;
            tbManMileageIdMileage.Text = string.Empty;
            tbManMileageOrigin.Text = string.Empty;
            tbManMileageDestination.Text = string.Empty;
            tbManMileageKilometers.Text = string.Empty;
            tbManMileagePricePerKilometer.Text = string.Empty;
            tbManMileageFinal.Text = string.Empty;
            tbManMileageState.Text = string.Empty;
            cbManMileageNewState.Text = string.Empty;
        }

        private void btnKilometrajeEliminar_Click(object sender, EventArgs e)
        {
            cnMileage.deleteMileage(int.Parse(dgvMileage.CurrentRow.Cells[0].Value.ToString()));

            tbManMileageEmail.Text = string.Empty;
            tbManMileageTitle.Text = string.Empty;
            tbManMileageDate.Text = string.Empty;
            tbManMileageSubcategory.Text = string.Empty;
            tbManMileageIdMileage.Text = string.Empty;
            tbManMileageOrigin.Text = string.Empty;
            tbManMileageDestination.Text = string.Empty;
            tbManMileageKilometers.Text = string.Empty;
            tbManMileagePricePerKilometer.Text = string.Empty;
            tbManMileageFinal.Text = string.Empty;
            tbManMileageState.Text = string.Empty;
            cbManMileageNewState.Text = string.Empty;
        }

        private void btnAllowanceRemove_Click(object sender, EventArgs e)
        {
            cnAllowance.deleteAllowance(int.Parse(dgvAllowances.CurrentRow.Cells[0].Value.ToString()));
            dgvUser.Update();
            dgvUser.Refresh();
            cnUser.dgvUsers(dgvUser);
            tbManAllowancesEmail.Text = string.Empty;
            tbManAllowancesTitle.Text = string.Empty;
            tbManAllowancesObservations.Text = string.Empty;
            tbManAllowancesDate.Text = string.Empty;
            tbManAllowancesStartHour.Text = string.Empty;
            tbManAllowancesEndHour.Text = string.Empty;
            tbManAllowancesState.Text = string.Empty;
            tbManAllowancesIdAllowance.Text = string.Empty;
            cbStateDietas.Text = string.Empty;
        }

        private void btnSolDietasSolKilometraje_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Id user: " + ceGlobals.id);
            cnMileage.insertMileage(new ceMileage(0, int.Parse(ceGlobals.id), 
                tbReqMileageTitle.Text, dtpReqDietasMileageDate.Text, cbReqMileageSubCategory.SelectedItem.ToString(), 
                tbReqMileageOrigin.Text, tbReqMileageDestination.Text, float.Parse(tbReqMileageMileage.Text), 
                float.Parse(tbReqMileagePricePerKilometer.Text), float.Parse(tbReqMileageTotal.Text), "Solicitado"));
        }

        private void cbMileageSubCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cbReqMileageSubCategory.SelectedItem.ToString() == "Vehículo propio")
            {
                tbReqMileagePricePerKilometer.Text = "0,17";
            }
            else
            {
                tbReqMileagePricePerKilometer.Text = "0,13";
            }
            tbSolMileageMileage_Leave(sender, e);
        }

        private void tbSolMileageMileage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbSolMileageMileage_Leave(object sender, EventArgs e)
        {
            if(tbReqMileageMileage.Text != string.Empty && tbReqMileagePricePerKilometer.Text != string.Empty)
            {
                tbReqMileageTotal.Text = (float.Parse(tbReqMileageMileage.Text) * float.Parse(tbReqMileagePricePerKilometer.Text)).ToString("0.00€");
            }
        }

    }
}