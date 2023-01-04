using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public static class ceGlobals
    {
        
        public static string lang { get; set; }
        public static string id { get; set; }
        public static string email { get; set; }
        public static string password { get; set; }
        public static string role { get; set;}
        public static int[] privileges = new int[4];

        public static void initializeDataUser()
        {
            lang = string.Empty;
            id = string.Empty;
            email = string.Empty;
            password = string.Empty;
            role = string.Empty;
        }

        public static void setPrivileges(String stringPrivileges)
        {
            int aux = 0;
            char[] chars = stringPrivileges.ToCharArray();

            foreach (var module in chars)
            {
                int bar = int.Parse(module.ToString());

                if (bar == 1 && privileges[aux] == 0)
                {
                    privileges[aux] = 1;
                }
                aux++;
            }
        }

    }
}
