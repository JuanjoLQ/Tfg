using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class cnUser
    {
        cdUser cdUser = new cdUser();

        public bool ValidarDatos(ceUser user)
        {
            bool result = true;
            if (user.Email == string.Empty || user.Email == "Email")
            {
                result = false;
                MessageBox.Show("El email es obligatorio");
            }

            if (user.Password == string.Empty || user.Password == "Password")
            {
                result = false;
                MessageBox.Show("La contraseña es obligatorio");
            }

            return result;

        }

        public void PruebaMySql()
        {
            cdUser.PruebaConexion();
        }

        public void CrearUser(ceUser user)
        {
            cdUser.CrearUsuario(user);
        }

        public void CheckUser(ceUser user)
        {
            cdUser.LogUsuario(user);
        }

    }
}