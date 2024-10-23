using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{

    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        public string TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public int Telefono { get; set; }


        public Persona(string nombre, string apellido, DateTime fechaNacimiento, string email,
                       string pais, string tipoDocumento, int numeroDocumento, int telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Pais = pais;
            TipoDocumento = tipoDocumento;
            NumeroDocumento = numeroDocumento;
            Telefono = telefono;
        }

    }

}



