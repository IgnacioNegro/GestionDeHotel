﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{
    public class GestionUsuario
    {
        public List<Usuario> listaUsuarios = new List<Usuario>();
        public static Usuario? usuarioActual;

        public GestionUsuario()
        {
            
                Precarga precarga = new Precarga();
                listaUsuarios = precarga.PrecargarUsuarios();
            
        }
        public void RegistrarUsuario()
        {
            Console.Clear();
            Console.WriteLine("Por favor, ingrese los datos del nuevo usuario:");

            string? nombreCompleto;
            do
            {
                Console.Write("¿Cuál es su nombre completo?: ");
                nombreCompleto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombreCompleto))
                {
                    Console.WriteLine("El nombre no puede estar vacío ni contener solo espacios. Intente nuevamente.");
                }
            } while (string.IsNullOrWhiteSpace(nombreCompleto));

            string? apellidoCompleto;
            do
            {
                Console.Write("Ingrese su apellido completo: ");
                apellidoCompleto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(apellidoCompleto))
                {
                    Console.WriteLine("El apellido no puede estar vacío. Por favor, inténtelo de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(apellidoCompleto));

            DateTime fechaNac;
            string? fechaInput;
            do
            {
                Console.Write("Proporcione su fecha de nacimiento (dd/mm/yyyy): ");
                fechaInput = Console.ReadLine();
                if (!DateTime.TryParse(fechaInput, out fechaNac))
                {
                    Console.WriteLine("Introduzca una fecha válida en el formato indicado.");
                }
            } while (!DateTime.TryParse(fechaInput, out fechaNac));

            string? correoElectronico;
            do
            {
                Console.Write("¿Cuál es su correo electrónico?: ");
                correoElectronico = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(correoElectronico))
                {
                    Console.WriteLine("El correo no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(correoElectronico));
            
        

            string? claveAcceso;
            do
            {
                Console.Write("Ingrese una contraseña: ");
                claveAcceso = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(claveAcceso))
                {
                    Console.WriteLine("La contraseña no puede estar vacía. Por favor, inténtelo de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(claveAcceso));

            string? paisResidencia;
            do
            {
                Console.Write("Indique su país de residencia: ");
                paisResidencia = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(paisResidencia))
                {
                    Console.WriteLine("El país no puede estar vacío. Intente nuevamente.");
                }
            } while (string.IsNullOrWhiteSpace(paisResidencia));

            string? tipoDoc;
            do
            {
                Console.Write("Especifique el tipo de documento: ");
                tipoDoc = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(tipoDoc))
                {
                    Console.WriteLine("El tipo de documento no puede estar vacío.");
                }
            } while (string.IsNullOrWhiteSpace(tipoDoc));

            int numDoc;
            string? docInput;
            do
            {
                Console.Write("Proporcione su número de documento: ");
                docInput = Console.ReadLine();
                if (!int.TryParse(docInput, out numDoc))
                {
                    Console.WriteLine("Asegúrese de ingresar un número de documento válido.");
                }
            } while (!int.TryParse(docInput, out numDoc));

            int telefonoUsuario;
            string? telInput;
            do
            {
                Console.Write("Ingrese su número de teléfono: ");
                telInput = Console.ReadLine();
                if (!int.TryParse(telInput, out telefonoUsuario))
                {
                    Console.WriteLine("Introduzca un número de teléfono válido.");
                }
            } while (!int.TryParse(telInput, out telefonoUsuario));

            Usuario nuevoUsuario = new Usuario(nombreCompleto, apellidoCompleto, fechaNac, correoElectronico, paisResidencia, tipoDoc, numDoc, telefonoUsuario, claveAcceso);
            IngresarUsuario(nuevoUsuario);

            Console.WriteLine("El usuario ha sido registrado exitosamente.");
            Console.ReadLine();
            Menu.MenuIniciarSesion();
        }


        public void IniciarSesion()
        {
            Console.Clear();
            Console.WriteLine("INICIAR SESION");
            bool sesionIniciada = false;

            while (!sesionIniciada)
            {
                Console.WriteLine("Ingrese su email:");
                string? nomUs = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("Ingrese su contraseña:");
                string? contrasena = Console.ReadLine();

                var usuario = listaUsuarios.FirstOrDefault(u => u.Email == nomUs && u.Contrasena == contrasena);
                usuarioActual = usuario;

                if (usuario != null)
                {
                    Console.WriteLine("Sesión iniciada.");
                    Menu.SesionIniciada = true;
                    Menu.MenuPrincipal();
                    sesionIniciada = true; 
                }
                else
                {
                    Console.WriteLine("Usuario o contraseña incorrectos. Intente de nuevo.");
                    Console.WriteLine(""); 
                }
            }
        }


        public void IngresarUsuario(Usuario usuario)
        {
            listaUsuarios.Add(usuario);
        }


    



        public void RecuperarContrasena()
        {
            Console.Clear();
            Console.WriteLine("Recuperar Contraseña");

            try
            {
                Console.Write("Ingrese su email: ");
                string? email = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(email))
                {
                    throw new ArgumentException("El email no puede estar vacío o contener solo espacios en blanco.");
                }

                bool usuarioEncontrado = false;

                foreach (var usuario in listaUsuarios)
                {
                    if (email == usuario.Email)
                    {
                        Console.WriteLine($"{usuario.Contrasena}");
                        usuarioEncontrado = true;
                        break;
                    }
                }

                if (!usuarioEncontrado)
                {
                    Console.WriteLine("No se encontró un usuario con ese email.");
                }

                Console.WriteLine("Presione una tecla para continuar:");
                Console.ReadLine();
                Menu.MenuPrincipal();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Presione una tecla para continuar:");
                Console.ReadLine();
                Menu.MenuPrincipal();
            }
        }

    }
}





   

