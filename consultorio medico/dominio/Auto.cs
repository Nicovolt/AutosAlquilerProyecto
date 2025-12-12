using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace dominio
{
    public class Auto
    {
        public int idAuto { get; set; }
        public int idMarca { get; set; }
        public int idCategoria { get; set; }
        public string numPatente { get; set; }
        public string modelo { get; set; }
        public int anio { get; set; }
        public string color { get; set; }
        public decimal precio { get; set; }
        public bool disponible { get; set; }
        public List<Imagen> ListaImagenes { get; set; } = new List<Imagen>(); // ← agregado


    }
}
