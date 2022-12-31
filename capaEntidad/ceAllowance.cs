using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class ceAllowance
    {
        public int idAllowance { get; set; }
        public int idUser { get; set; }
        public string title { get; set; }
        public string observations { get; set; }
        public string state { get; set; }
        public string startHour { get; set; }
        public string endHour { get; set; }
        public string startTime { get; set; }

        public ceAllowance(int idAllowance, int idUser, string title, string observations, string state, string startHour, string endHour, string startTime)
        {
            this.idAllowance = idAllowance;
            this.idUser = idUser;
            this.title = title;
            this.observations = observations;
            this.state = state;
            this.startHour = startHour;
            this.endHour = endHour;
            this.startTime = startTime;
        }

    }
}
