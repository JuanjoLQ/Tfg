using capaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public class cnMileage
    {
        cdMileage cdMileage = new cdMileage();

        public void updateMileage(int idMileage, string state)
        {
            cdMileage.updateMileage(idMileage, state);
        }

        public void deleteMileage(int idMileage)
        {
            cdMileage.deleteMileage(idMileage);
        }


    }
}
