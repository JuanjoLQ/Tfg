using capaEntidad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class cdMileage
    {
        string cadenaConexion = "Server=localhost;User=root;Password=TFG_ERP_C#;Port=3306;database=mydb;";

        public void insertMileage(ceMileage mileage)
        {
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd;
            conn.Open();

            using (cmd = new MySqlCommand("insert into allowance (User_idUser, title, fechado, " +
                "subcategory, origen, destino, kilometers, priceperkilometer, final, state) values(@User_idUser, " +
                "@title, @fechado, @subcategory, @origen, @destino, @kilometers, @priceperkilometer, @final, @state);", conn))
            {
                cmd.Parameters.AddWithValue("@User_idUser", ceGlobals.id);
                cmd.Parameters.AddWithValue("@title", mileage.title);
                cmd.Parameters.AddWithValue("@fechado", mileage.fechado);
                cmd.Parameters.AddWithValue("@subcategory", mileage.subcategory);
                cmd.Parameters.AddWithValue("@origen", mileage.origen);
                cmd.Parameters.AddWithValue("@destino", mileage.destino);
                cmd.Parameters.AddWithValue("@kilometers", mileage.kilometers);
                cmd.Parameters.AddWithValue("@priceperkilometer", mileage.priceperkilometer);
                cmd.Parameters.AddWithValue("@final", mileage.final);
                cmd.Parameters.AddWithValue("@state", "Solicitado");
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Kilometraje añadido", "Juanjo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            conn.Close();
        }

        public void updateMileage(int idMileage, string state)
        {
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd;
            conn.Open();

            using (cmd = new MySqlCommand("update mileage set state = @state where idMileage = @idMileage;", conn))
            {
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@idMileage", idMileage);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Kilometraje modificado", "Juanjo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            conn.Close();
        }

        public void deleteMileage(int idMileage)
        {
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            MySqlCommand cmd;
            conn.Open();

            using (cmd = new MySqlCommand("delete from mileage where idMileage = @idMileage;", conn))
            {
                cmd.Parameters.AddWithValue("@idMileage", idMileage);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Kilometraje eliminado", "Juanjo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            conn.Close();
        }
    }
}