using capaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public class cnDgvMileage
    {
        cdDgvMileage cdDgvMileage = new cdDgvMileage();
        public void dgvUsers(DataGridView dgvMileage)
        {
            cdDgvMileage.GetData();
            cdDgvMileage.updateDatagrid(dgvMileage);
        }
    }
}
