﻿using capaDatos;
using capaEntidad;
using System.Text.RegularExpressions;

namespace capaNegocio
{
    public class cnUser
    {
        cdUser cdUser = new cdUser();

        public bool CheckUser(ceUser user)
        {
            if (regexEmail(user) && cdUser.LogUsuario(user))
            {
                return true;
            }
            return false;

        }

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

        public bool regexEmail(ceUser user) {
            bool test;
            Regex validateEmailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]" +
                "+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*" +
                "[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
            test = validateEmailRegex.IsMatch(user.Email);

            return test;

        }

        public string nameRole(string role)
        {
            return cdUser.obtainNameRole(role);
        }

        public string idUser(string email)
        {
            return cdUser.obtainIdUser(email).ToString();
        }


        public void PruebaMySql()
        {
            cdUser.PruebaConexion();
        }

        public bool CrearUser(ceUser user, string role)
        {
            return cdUser.CrearUsuario(user, role);
        }

    }
}