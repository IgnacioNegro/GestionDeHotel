using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{
    public class GestionUsuario
    {
        public List<Usuario> listaUsuarios = new List<Usuario>();

        public void IngresarUsuario()
        {
            Console.Clear();
            Console.WriteLine("Ingresar Datos del Usuario");
            Console.WriteLine("");

            string? nombre;
            do
            {
                Console.Write("Ingrese su nombre completo; ");
                nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("No puede estar vacía o contener espacios en blanco. Intente de nuevo.");
                }

            } while (string.IsNullOrWhiteSpace(nombre));

            string? apellido;
            do
            {
                Console.Write("Ingrese su apellido completo; ");
                apellido = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(apellido))
                {
                    Console.WriteLine("No puede estar vacía o contener espacios en blanco. Intente de nuevo.");
                }

            } while (string.IsNullOrWhiteSpace(apellido));

            string? aniostring;
            DateTime anio;

            do
            {
                Console.Write("Ingrese su fecha de nacimiento;");
                aniostring = Console.ReadLine();
                if (!DateTime.TryParse(aniostring, out anio))
                {
                    Console.WriteLine("Digite su fecha de nacimiento en formato dd/mm/yyyy");
                }

            } while (!DateTime.TryParse(aniostring, out anio));

            Console.WriteLine("Ingrese su email");
            string? email = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña");
            string? contrasena = Console.ReadLine();
            Console.WriteLine("Ingrese su pais");
            string? pais = Console.ReadLine();
            Console.WriteLine("Ingrese su Tipo de documento");
            string? TipoDocumento = Console.ReadLine();
            Console.WriteLine("Ingrese su numero de documento");
            string? stringdocumento;
            int intdocumento;
            {
                Console.Write("Ingrese su  numero de documento;");
                stringdocumento = Console.ReadLine();
                if (!int.TryParse(stringdocumento, out intdocumento))
                {
                    Console.WriteLine("Digite su documento en numero , tipo 47887308");
                }

            } while (!int.TryParse(stringdocumento, out intdocumento)) ;

            Console.WriteLine("Ingrese su telefono");
            string? telefono;
            int telefonoint;
            {
                Console.Write("Ingrese su  telefono;");
                telefono = Console.ReadLine();
                if (!int.TryParse(telefono, out telefonoint))
                {
                    Console.WriteLine("Digite su telefono en numero , tipo 47887308");
                }

            } while (!int.TryParse(stringdocumento, out intdocumento)) ;
            Usuario nuevoUsuario = new Usuario(nombre, apellido, anio, contrasena, pais, TipoDocumento, intdocumento, telefonoint, contrasena);
            /* listaUsuarios.Add(nuevoUsuario);*/
            IngresarUsuario(nuevoUsuario);

            Console.WriteLine("El usuario ha sido agregado con exito");
            Console.ReadLine();
            Menu.MenuIniciarSesion();
        }

        public void IniciarSesion()
        {
            Console.Clear();
            Console.WriteLine("Ingrese su email");
            string? nomUs = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Ingrese su contrasena");
            string? contrasena = Console.ReadLine();

            foreach (var usuario in listaUsuarios)
            {
                if (nomUs == usuario.Email && contrasena == usuario.Contrasena)
                {
                    Console.WriteLine("Sesión iniciada");
                    Menu.SesionIniciada = true;
                    Menu.MenuPrincipal();
                }
                else
                {
                    Console.WriteLine("El usuario no ha sido encontrado");
                }

            }

            Console.ReadLine();
            Menu.MenuPrincipal();

        }


        public void IngresarUsuario(Usuario usuario)
        {
            listaUsuarios.Add(usuario);
        }

        public List<Usuario> ObtenerListaUsuarios()
        {
            return listaUsuarios;
        }
    }
}
