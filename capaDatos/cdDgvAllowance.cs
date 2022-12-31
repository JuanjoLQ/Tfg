using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class cdDgvAllowance
    {
        string cadenaConexion = "Server=localhost;User=root;Password=TFG_ERP_C#;Port=3306;database=mydb;";

        //arraylist to getter and setter data  

        private static ArrayList idAllowance = new ArrayList();
        private static ArrayList emailUsers = new ArrayList();
        private static ArrayList titles = new ArrayList();
        private static ArrayList observations = new ArrayList();
        private static ArrayList date = new ArrayList();
        private static ArrayList startHours = new ArrayList();
        private static ArrayList endHours = new ArrayList();
        private static ArrayList invoices = new ArrayList();
        private static ArrayList states = new ArrayList();

        public void resetData()
        {
            emailUsers.Clear();
            titles.Clear();
            observations.Clear();
            date.Clear();
            startHours.Clear();
            endHours.Clear();
            invoices.Clear();
            states.Clear();
        }

        public void GetData()
        {
            try
            {
                resetData();
                MySqlConnection conn = new MySqlConnection(cadenaConexion);
                conn.Open();
                string query = "select allowance.idAllowance, user.email, allowance.title, allowance.observations, allowance.starttime, allowance.starthour, allowance.endhour, allowance.invoice, allowance.state " +
                    "from user, allowance where user.idUser = allowance.User_idUser";

                MySqlCommand command = new MySqlCommand(query, conn);

                var row = command.ExecuteReader();

                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        idAllowance.Add(row["idAllowance"].ToString());
                        emailUsers.Add(row["email"].ToString());
                        titles.Add(row["title"].ToString());
                        observations.Add(row["observations"].ToString());
                        date.Add(row["starttime"].ToString());
                        startHours.Add(row["starthour"].ToString());
                        endHours.Add(row["endhour"].ToString());
                        invoices.Add(row["invoice"].ToString());
                        states.Add(row["state"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Data not found");
                }

                row.Close();// Close reader.
                conn.Close();// Close connection.
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        public void updateDatagrid(DataGridView dgvAllowance)
        {
            dgvAllowance.RowCount = 0;
            for (int i = 0; i < emailUsers.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                
                newRow.CreateCells(dgvAllowance);
                newRow.Cells[0].Value = idAllowance[i];
                newRow.Cells[1].Value = emailUsers[i];
                newRow.Cells[2].Value = titles[i];
                newRow.Cells[3].Value = observations[i];
                newRow.Cells[4].Value = date[i];
                newRow.Cells[5].Value = startHours[i];
                newRow.Cells[6].Value = endHours[i];
                //newRow.Cells[7].Value = invoices[i];
                newRow.Cells[8].Value = states[i];
                dgvAllowance.Rows.Add(newRow);
            }
        }

    }
}
