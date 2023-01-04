using MySql.Data.MySqlClient;
using capaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;

namespace capaDatos
{
    public class cdAllowance
    {
        
        string cadenaConexion = "Server=localhost;User=root;Password=TFG_ERP_C#;Port=3306;database=mydb;";

        public bool insertAllowance(ceAllowance allowance)
        {
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "INSERT INTO allowance (User_idUser, Title, Observations, State, StartTime, StartHour, EndHour) VALUES " +
                "('" + allowance.idUser + "', '" + allowance.title + "', '" + allowance.observations + "', '" + allowance.state + "', '" + allowance.startTime + "', '" + allowance.startHour + "', '" + allowance.endHour + "');";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();

            return true;
        }

        public void updateAllowance(int idAllowance, string state)
        {
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd;
            conn.Open();

            using (cmd = new MySqlCommand("update allowance set state = @state where idAllowance = @idAllowance;", conn))
            {
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@idAllowance", idAllowance);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Dieta modificada", "Juanjo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            conn.Close();
        }

        public void deleteAllowance(int idAllowance)
        {
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd;
            conn.Open();

            using (cmd = new MySqlCommand("delete from allowance where idAllowance = @idAllowance;", conn))
            {
                cmd.Parameters.AddWithValue("@idAllowance", idAllowance);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Dieta eliminada", "Juanjo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            conn.Close();
        }

    }
}