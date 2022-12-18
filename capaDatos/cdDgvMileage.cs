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
    public class cdDgvMileage
    {
        string cadenaConexion = "Server=localhost;User=root;Password=TFG_ERP_C#;Port=3306;database=mydb;";

        //arraylist to getter and setter data

        private static ArrayList emailUsers = new ArrayList();
        private static ArrayList titles = new ArrayList();
        private static ArrayList date = new ArrayList();
        private static ArrayList subcategory = new ArrayList();
        private static ArrayList origen = new ArrayList();
        private static ArrayList destino = new ArrayList();
        private static ArrayList final = new ArrayList();
        private static ArrayList pricePerKilometer = new ArrayList();
        private static ArrayList states = new ArrayList();

        public void GetData()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(cadenaConexion);
                conn.Open();
                string query = "select user.email, mileage.title, mileage.fechado, mileage.subcategory, mileage.origen, mileage.destino, mileage.final, mileage.priceperkilometer, mileage.state " +
                    "from user, mileage where user.idUser = mileage.User_idUser";

                MySqlCommand command = new MySqlCommand(query, conn);

                var row = command.ExecuteReader();

                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        emailUsers.Add(row["email"].ToString());
                        titles.Add(row["title"].ToString());
                        date.Add(row["fechado"].ToString());
                        subcategory.Add(row["subcategory"].ToString());
                        origen.Add(row["origen"].ToString());
                        destino.Add(row["destino"].ToString());
                        final.Add(row["final"].ToString());
                        pricePerKilometer.Add(row["priceperkilometer"].ToString());
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

        public void updateDatagrid(DataGridView dgvMileage)
        {
            dgvMileage.Rows.Clear();
            for (int i = 0; i < emailUsers.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dgvMileage);
                newRow.Cells[0].Value = emailUsers[i];
                newRow.Cells[1].Value = titles[i];
                newRow.Cells[2].Value = date[i];
                newRow.Cells[3].Value = subcategory[i];
                newRow.Cells[4].Value = origen[i];
                newRow.Cells[6].Value = destino[i];
                newRow.Cells[7].Value = final[i];
                newRow.Cells[8].Value = pricePerKilometer[i];
                newRow.Cells[5].Value = states[i];
                dgvMileage.Rows.Add(newRow);
            }
        }
    }
}
