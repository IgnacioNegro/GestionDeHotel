using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{
    public class Hotel
    {
        public int IdHotel { get; set; }
        public string NombreHotel { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Direccion { get; set; }
        public int Estrellas { get; set; }
        public List<string> Servicios { get; set; } 
        public List<string> ServiciosAdicionales { get; set; } 
    }
}
