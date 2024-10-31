using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{
    internal class Menu
    {
        public static bool SesionIniciada = false;
        public static void MenuIniciarSesion()
        {
            {
                Console.Clear();
                Console.WriteLine("***-----------BIENVENIDO AL HOTEL ESTRELLA DEL MAR-------------***.");
                Console.WriteLine("");
                Console.WriteLine("Selecciona una opción:");
                Console.WriteLine("");
                Console.WriteLine("6. Ingresar un Usuario");
                Console.WriteLine("7. Iniciar Sesion");
                Console.WriteLine("3. Salir");

            }
        }
        public static void MenuPrincipal()
        {
            {
                {
                    Console.Clear();
                    Console.WriteLine("***MENU PRINCIPAL***");
                    Console.WriteLine(" ");
                    Console.WriteLine("Selecciona una opción:");
                    Console.WriteLine("");
                    Console.WriteLine("1. Gestion de Usuarios");
                    Console.WriteLine("2. Reservas y Cancelaciones");
                    Console.WriteLine("3. Gestion de Pagos");
                    Console.WriteLine("4. Estadisticas y Reportes");
                    Console.WriteLine("0. Salir del programa");
                                    }

            }

        }

        public static void GestionUsuarios()
        {
            Console.Clear();
            Console.WriteLine("GESTION DE USUARIOS");
            Console.WriteLine(" ");
            Console.WriteLine("6. Ingresar un usuario");
            Console.WriteLine("7. Iniciar Sesion");
            Console.WriteLine("8. Recuperar Contraseña");
            Console.WriteLine("5. Volver al menu principal");

        }
        public static void ReservasyCancelaciones()
        {
            Console.Clear();
            Console.WriteLine("RESERVAS Y CANCELACIONES");
            Console.WriteLine(" ");
            Console.WriteLine("10. Consultar habitaciones disponibles");
            Console.WriteLine("11. Realizar Reservas");
            Console.WriteLine("12. Modificar Reservas");
            Console.WriteLine("13. Cancelar Reservas");
            Console.WriteLine("5. Volver al menu principal");

        }

        public static void GestionDePagos()
        {
            Console.Clear();
            Console.WriteLine("GESTION DE PAGOS");
            Console.WriteLine(" ");
            Console.WriteLine("14. Realizar Pago");
            Console.WriteLine("5. Volver al menu Principal");

        }

        public static void EstadisticaYReportes()
        {
            Console.Clear();
            Console.WriteLine("ESTADISTICAS Y REPORTES");
            Console.WriteLine(" ");
            Console.WriteLine("17. Listar huespedes");
            Console.WriteLine("18. Listar habitaciones disponibles");
            Console.WriteLine("19. Historial de reservas");
            Console.WriteLine("20. Habitaciones mas reservadas");
            Console.WriteLine("5. Volver al menu Principal");

        }
    }
}












