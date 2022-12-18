using capaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public class cnDgvAllowance
    {
        cdDgvAllowance cdDgvAllowance = new cdDgvAllowance();
        public void dgvAllowance(DataGridView dgvAllowance)
        {
            cdDgvAllowance.GetData();
            cdDgvAllowance.updateDatagrid(dgvAllowance);
        }
    }
}
