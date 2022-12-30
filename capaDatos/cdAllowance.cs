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

        

    }

}
