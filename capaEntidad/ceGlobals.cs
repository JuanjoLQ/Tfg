using System;
using System.Collections.Generic;
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
        public static int[] privileges = new int[5];

        public static void initializeDataUser()
        {
            lang = string.Empty;
            id = string.Empty;
            email = string.Empty;
            password = string.Empty;
            role = string.Empty;
            
        }

        public static void setPrivileges(String privileges)
        {

        }

    }
}
