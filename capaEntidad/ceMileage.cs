using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class ceMileage
    {
        public int idMileage { get; set; }
        public int idUser { get; set; }
        public string title { get; set; }
        public string fechado { get; set; }
        public string subcategory { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public float kilometers { get; set; }
        public float priceperkilometer { get; set; }
        public float final { get; set; }
        public string state { get; set; }

        public ceMileage(int idMileage, int idUser, string title, string fechado, string subcategory, string origen, string destino, float kilometers, float priceperkilometer, float final, string state)
        {
            this.idMileage = idMileage;
            this.idUser = idUser;
            this.title = title;
            this.fechado = fechado;
            this.subcategory = subcategory;
            this.origen = origen;
            this.destino = destino;
            this.kilometers = kilometers;
            this.priceperkilometer = priceperkilometer;            
            this.final = priceperkilometer * kilometers;
            this.state = state;
        }
    }
}
