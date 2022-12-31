using capaDatos;
using capaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public class cnAllowance
    {
        cdAllowance cdAllowance = new cdAllowance();
        
        public bool insAllowance (ceAllowance allowance)
        {
            return cdAllowance.insertAllowance(allowance);
        }

        public void updateAllowance(ceAllowance allowance)
        {
            cdAllowance.updateAllowance(allowance);
        }

        public void deleteAllowance(ceAllowance allowance)
        {
            cdAllowance.deleteAllowance(allowance);
        }

    }
}
