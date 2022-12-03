using capaEntidad;
using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using System.Diagnostics;

namespace capaDatos{

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

        public void CrearUsuario(ceUser user) {
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "INSERT INTO user (isAdmin, email, password) VALUES ('" + user.isAdmin + "','" + user.Email + "', '" + user.Password + "');";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Registro de user creado");

        }

        public void LogUsuario(ceUser user)
        {
            Debug.WriteLine("Capa datos logUser");
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "SELECT COUNT(*) FROM user where email='" + user.Email + "';";
            MySqlCommand command = new MySqlCommand(query, conn);

            int count = Convert.ToInt32(command.ExecuteScalar());
            
            if (count == 1)
            {
                MessageBox.Show("El email existe.");
            }
            else
            {
                MessageBox.Show("Error login.");
            }

        }

    }

}