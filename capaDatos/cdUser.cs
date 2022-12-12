using capaEntidad;
using MySql.Data.MySqlClient;
using System.Diagnostics;

/*
string cuote = "0110";
char[] chars = cuote.ToCharArray();

foreach (var word in chars)
{
    System.Console.WriteLine($"{word}");
}

0
1
1
0

 */

namespace capaDatos
{

    public class cdUser
    {

        string cadenaConexion = "Server=localhost;User=root;Password=TFG_ERP_C#;Port=3306;database=mydb;";

        public void PruebaConexion() {
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);

            try
            {
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conectarse BBDD" + ex.Message);
                return;
            }
            MessageBox.Show("Conectado a la BBDD");

        }

        public bool CrearUsuario(ceUser user) {

            if (LogUsuario(user) == false)
            {
                MySqlConnection conn = new MySqlConnection(cadenaConexion);
                conn.Open();
                string query = "INSERT INTO user (isAdmin, email, password) VALUES " +
                    "('" + user.isAdmin + "','" + user.Email + "', '" + user.Password + "');";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registro de user creado");
                return true;
            } else
            {
                MessageBox.Show("Email ya existente.");
                return false;
            }

        }

        public bool LogUsuario(ceUser user)
        {
            Debug.WriteLine("Capa datos logUser");
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "SELECT COUNT(*) FROM user where email='" + user.Email + "';";
            MySqlCommand command = new MySqlCommand(query, conn);

            int count = Convert.ToInt32(command.ExecuteScalar());
            
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }

}