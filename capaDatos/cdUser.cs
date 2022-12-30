using capaEntidad;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Mozilla;
using System.Data;
using System.Diagnostics;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
        
        public bool checkRole(string role)
        {
            Debug.WriteLine("Capa datos checkRole");
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "SELECT COUNT(*) FROM role where nameRole='" + role + "';";
            MySqlCommand command = new MySqlCommand(query, conn);

            int count = Convert.ToInt32(command.ExecuteScalar());
            
            conn.Close();

            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CrearUsuario(ceUser user, string role, string departamento) 
        {
            Debug.WriteLine("cdUser -CrearUsuario");

            if (!checkRole(role))
            {
                Debug.WriteLine("CrearUsuario Role NO válido");
                MessageBox.Show("Role NO válido.");
                return false;
            }
            if (LogUsuario(user) == true)
            {
                Debug.WriteLine("CrearUsuario Usuario NO válido");
                MessageBox.Show("Email ya existente.");
                return false;
            }

            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "INSERT INTO user (email, password) VALUES " +
                "('" + user.Email + "', '" + user.Password + "');";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Registro de user creado");

            if (assignRole2User(user.Email, role) == false)
            {
                Debug.WriteLine("CrearUsuario -assignRole2User error");
                return false;
            }

            if (assignRole2Department(user.Email, departamento) == false)
            {
                Debug.WriteLine("CrearUsuario -assignDepartment2User error");
                return false;
            }




            Debug.WriteLine("CrearUsuario Succesfull");

            return true;
        }

        public bool assignRole2Department(string email, string departamento)
        {
            Debug.WriteLine("cdUser -assignRole2User");

            int idUser = obtainIdUser(email);
            int idDepartment = obtainIdDepartment(departamento);

            if (idUser == 0)
            {
                Debug.WriteLine("assignRole2User error: idUser");
                return false;
            }

            if (idDepartment == 0)
            {
                Debug.WriteLine("assignRole2User error: idDepartment");
                return false;
            }

            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "INSERT INTO Department_User (User_idUser, Department_idDepartment) VALUES " +
                "('" + idUser + "', '" + idDepartment + "');";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();

            Debug.WriteLine("assignDepartment2User Succesfull");

            return true;
        }

        public int obtainIdDepartment(string Department)
        {
            int idDepartment = 0;
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "SELECT idDepartment FROM Department where name='" + Department + "';";

            MySqlCommand command = new MySqlCommand(query, conn);

            var dr = command.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();// Get first record.
                idDepartment = int.Parse(dr.GetString(0));// Get value of first column as string.
                MessageBox.Show("Id del usuario: " + idDepartment);
            }

            MessageBox.Show("Registro de user creado");

            dr.Close();// Close reader.
            conn.Close();// Close connection.

            if (idDepartment != 0)
            {
                return idDepartment;
            }
            return idDepartment;
        }



        public bool assignRole2User(string email, string role)
        {
            Debug.WriteLine("cdUser -assignRole2User");

            int idUser = obtainIdUser(email);
            int idRole = obtainIdRole(role);

            if(idUser == 0)
            {
                Debug.WriteLine("assignRole2User error: idUser");
                return false;
            }

            if (idRole == 0)
            {
                Debug.WriteLine("assignRole2User error: idRole");
                return false;
            }

            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "INSERT INTO Role_User (User_idUser, Role_idRole) VALUES " +
                "('" + idUser + "', '" + idRole + "');";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();

            Debug.WriteLine("assignRole2User Succesfull");

            return true;
        }

        public int obtainIdRole(string role)
        {
            int idRole = 0;
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "SELECT idRole FROM Role where nameRole='" + role + "';";

            MySqlCommand command = new MySqlCommand(query, conn);

            var dr = command.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();// Get first record.
                idRole = int.Parse(dr.GetString(0));// Get value of first column as string.
                MessageBox.Show("Id del usuario: " + idRole);
            }

            MessageBox.Show("Registro de user creado");

            dr.Close();// Close reader.
            conn.Close();// Close connection.

            if (idRole != 0)
            {
                return idRole;
            }
            return idRole;
        }

        public int obtainIdUser(string email)
        {
            int idUser = 0;
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "SELECT idUser FROM user where email='" + email + "';";

            MySqlCommand command = new MySqlCommand(query, conn);

            var dr = command.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();// Get first record.
                idUser = int.Parse(dr.GetString(0));// Get value of first column as string.
                MessageBox.Show("Id del usuario: " + idUser);
            }
            
            MessageBox.Show("Registro de user creado");

            dr.Close();// Close reader.
            conn.Close();// Close connection.

            if (idUser != 0)
            {
                return (idUser);
            }
            return idUser;

            /* Para seleccionar un solo valor
            var queryResult = cmd.ExecuteScalar();//Return an object so first check for null
            if (queryResult != null)
                // If we have result, then convert it from object to string.
                roboIp = Convert.ToString(queryResult);
            else
                // Else make id = "" so you can later check it.
                roboIp = "";
            */

        }

        public bool LogUsuario(ceUser user)
        {
            Debug.WriteLine("Capa datos logUser");
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "SELECT COUNT(*) FROM user where email='" + user.Email + "';";
            MySqlCommand command = new MySqlCommand(query, conn);

            int count = Convert.ToInt32(command.ExecuteScalar());

            conn.Close();

            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string obtainNameRole(string email)
        {
            StringBuilder namesRole = new StringBuilder("", 50);
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string query = "select role.nameRole, role.privileges " +
                "FROM((Role_user INNER JOIN user ON Role_user.User_idUser = user.idUser) INNER JOIN role ON Role_user.role_idRole = role.idRole) " +
                "where user.email ='" + email + "';";

            MySqlCommand command = new MySqlCommand(query, conn);

            var dr = command.ExecuteReader();

            while (dr.Read())
            {
                if (dr.HasRows)
                {
                    namesRole.Append(dr[0].ToString() + ", ");// Get value of first column as string.
                    ceGlobals.setPrivileges(dr[1].ToString());
                }
            }

            dr.Close();// Close reader.
            conn.Close();// Close connection.

            if (namesRole.Length == 0)
            {
                return null;
            }
            return namesRole.ToString();
        }






        public bool deteteUser(int idUser)
        {
            try
            {
                if(delDepartment_User(idUser) && delRole_User(idUser))
                {
                    MySqlConnection conn = new MySqlConnection(cadenaConexion);
                    conn.Open();
                    string query = "delete from user where idUser='" + idUser + "';";

                    MySqlCommand command = new MySqlCommand(query, conn);

                    var dr = command.ExecuteReader();

                    dr.Close();// Close reader.
                    conn.Close();// Close connection.

                    return true;
                }
                return false;
            }
            catch { 
                return false;
            }
        }

        public bool delDepartment_User(int idUser)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(cadenaConexion);
                conn.Open();
                string query = "delete from Department_User where User_idUser='" + idUser + "';";

                MySqlCommand command = new MySqlCommand(query, conn);

                var dr = command.ExecuteReader();

                dr.Close();// Close reader.
                conn.Close();// Close connection.

                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool delRole_User(int idUser)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(cadenaConexion);
                conn.Open();
                string query = "delete from Role_User where User_idUser ='" + idUser + "';";

                MySqlCommand command = new MySqlCommand(query, conn);

                var dr = command.ExecuteReader();

                dr.Close();// Close reader.
                conn.Close();// Close connection.

                return true;

            }
            catch
            {
                return false;
            }
        }

    }
}
