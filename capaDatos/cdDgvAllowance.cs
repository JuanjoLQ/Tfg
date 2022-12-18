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
        
        private static ArrayList emailUsers = new ArrayList();
        private static ArrayList titles = new ArrayList();
        private static ArrayList observations = new ArrayList();
        private static ArrayList date = new ArrayList();
        private static ArrayList startHours = new ArrayList();
        private static ArrayList endHours = new ArrayList();
        private static ArrayList invoices = new ArrayList();
        private static ArrayList states = new ArrayList();

        public void GetData()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(cadenaConexion);
                conn.Open();
                string query = "select user.email, allowance.title, allowance.observations, allowance.starttime, allowance.starthour, allowance.endhour, allowance.invoice, allowance.state " +
                    "from user, allowance where user.idUser = allowance.User_idUser";

                MySqlCommand command = new MySqlCommand(query, conn);

                var row = command.ExecuteReader();

                if (row.HasRows)
                {
                    while (row.Read())
                    {
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
            dgvAllowance.Rows.Clear();
            for (int i = 0; i < emailUsers.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dgvAllowance);
                newRow.Cells[0].Value = emailUsers[i];
                newRow.Cells[1].Value = titles[i];
                newRow.Cells[2].Value = observations[i];
                newRow.Cells[3].Value = date[i];
                newRow.Cells[4].Value = startHours[i];
                newRow.Cells[2].Value = endHours[i];
                newRow.Cells[3].Value = invoices[i];
                newRow.Cells[4].Value = states[i];
                dgvAllowance.Rows.Add(newRow);
            }
        }



    }
}
