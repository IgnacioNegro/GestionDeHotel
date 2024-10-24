using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{
    public class Usuario : Persona
    {
        private static int contador = 0;
        public int Id { get; private set; }
        public string? Contrasena { get; set; }

        public Usuario(string nombre, string apellido, DateTime fechaNacimiento, string email,
                       string pais, string tipoDocumento, int numeroDocumento, int telefono, string contraseña)
            : base(nombre, apellido, fechaNacimiento, email, pais, tipoDocumento, numeroDocumento, telefono)
        {
            contador++;
            Id = contador;
            Contrasena = contraseña;
        }
    }
}



