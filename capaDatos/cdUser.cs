using capaEntidad;
using MySql.Data.MySqlClient;

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
            MySqlConnection mySqlConnection = new MySqlConnection(cadenaConexion);
            mySqlConnection.Open();
            string query = "INSERT INTO user (isAdmin, email, password) VALUES ('" + user.isAdmin + "','" + user.Email + "', '" + user.Password + "');";
            MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection); 
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro de user creado");

        }


    }

    


}