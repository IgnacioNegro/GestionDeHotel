using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObligatorioProg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

    public class GestionReservas
    {
        public List<Habitacion> listaHabitaciones;
        public List<Reserva> listaReservas;
        private DateTime fechaLlegada;
        private DateTime fechaSalida;

    public GestionReservas()
    {
        Precarga precarga = new Precarga();
        listaHabitaciones = precarga.PrecargarHabitaciones();
        listaReservas = precarga.PrecargarReservas();
    
        }


        // Listar las reservas actuales
        public void ListarReservas()
        {
            Console.WriteLine("Reservas precargadas:");
            foreach (var reserva in listaReservas)
            {
                Console.WriteLine($"ID: {reserva.IDReserva}, Habitación: {reserva.NumeroHabitacion}, Cliente: {reserva.EmailCliente}, " +
                                  $"Desde: {reserva.FechaInicio.ToShortDateString()} Hasta: {reserva.FechaFin.ToShortDateString()}");
            }
        }

        public void ListarHabitaciones() // Listar todas las habitaciones
        {
            foreach (var habitacion in listaHabitaciones)
            {
                Console.WriteLine($"Número: {habitacion.NumeroHabitacion}, Tipo: {habitacion.Tipo}, Precio: {habitacion.Precio}");
            }
        }

        //opcion 10 del menu y se repite en estadisticas , consultar habitaciones no neresrvadas
        public void ConsultarHabitacionesDisponibles()
        {
            Console.Clear();
            Console.WriteLine("Habitaciones disponibles:");

            // Filtrar habitaciones que no están reservadas
            var habitacionesDisponibles = listaHabitaciones
                .Where(h => !listaReservas.Any(r => r.NumeroHabitacion == h.NumeroHabitacion))
                .ToList();

            if (habitacionesDisponibles.Count > 0)
            {
                foreach (var habitacion in habitacionesDisponibles)
                {
                    Console.WriteLine($"Número: {habitacion.NumeroHabitacion}, " +
                                      $"Tipo: {habitacion.Tipo}, " +
                                      $"Capacidad: {habitacion.cantidadPersonas}, " +
                                      $"Precio Diario: {habitacion.Precio}");
                }
            }
            else
            {
                Console.WriteLine("No hay habitaciones disponibles.");
            }

            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadLine();
            Menu.MenuPrincipal();
        }
        // Listar habitaciones disponibles fechas  determinadas  para el metodo realizar reserva, por eso es privada.
        private List<Habitacion> BuscarHabitacionesDisponiblesParaReserva(DateTime fechaLlegada, DateTime fechaSalida)
        {
            return listaHabitaciones.Where(h => !listaReservas.Any(r => r.NumeroHabitacion == h.NumeroHabitacion && r.FechaInicio < fechaSalida && r.FechaFin > fechaLlegada)).ToList();
        }

        //ReaLizar Reservas
        public void RealizarReserva()
        {
            Console.Clear();

            // Captura de las fechas de llegada y salida
            Console.Write("Ingrese su fecha de llegada (dd/mm/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out fechaLlegada))
            {
                Console.WriteLine("Fecha inválida.");
                return;
            }

            Console.Write("Ingrese su fecha de salida (dd/mm/yyyy): ");
            if (!DateTime.TryParse(Console.ReadLine(), out fechaSalida))
            {
                Console.WriteLine("Fecha inválida.");
                return;
            }

            // Validación del límite de 30 días
            if ((fechaSalida - fechaLlegada).TotalDays > 30)
            {
                Console.WriteLine("No se puede realizar una reserva por más de 30 días.");
                return;
            }


            var habitacionesDisponibles = BuscarHabitacionesDisponiblesParaReserva(fechaLlegada, fechaSalida);

            if (habitacionesDisponibles.Count == 0)
            {
                Console.WriteLine("No hay habitaciones disponibles para las fechas seleccionadas.");
                return;
            }
            Console.WriteLine("Seleccione el número de habitación de las disponibles:");
            foreach (var habitacion in habitacionesDisponibles)
            {
                Console.WriteLine($"Número: {habitacion.NumeroHabitacion}, Tipo: {habitacion.Tipo}, Precio: {habitacion.Precio:C}");
            }

            Console.Write("Ingrese el número de la habitación: ");
            if (!int.TryParse(Console.ReadLine(), out int numeroHabitacion))
            {
                Console.WriteLine("Número de habitación inválido.");
                return;
            }


            // verra si la habitación elegida está dentro de las disponibles
            var habitacionSeleccionada = habitacionesDisponibles.FirstOrDefault(h => h.NumeroHabitacion == numeroHabitacion);

            if (habitacionSeleccionada == null)
            {
                Console.WriteLine("La habitación seleccionada no está disponible.");
                return;
            }

            //requisito de no tener reserva duplicada

            string emailCliente = GestionUsuario.usuarioActual.Email;
            bool reservaDuplicada = listaReservas.Any(r =>
                r.EmailCliente == emailCliente &&
                ((fechaLlegada >= r.FechaInicio && fechaLlegada < r.FechaFin) ||
                 (fechaSalida > r.FechaInicio && fechaSalida <= r.FechaFin))
            );

            if (reservaDuplicada)
            {
                Console.WriteLine("Ya tiene una reserva activa para estas fechas.");
                Console.ReadLine();
                return;
            }

            // Crear la reserva y agregarla a la lista
            var nuevaReserva = new Reserva(numeroHabitacion, fechaLlegada, fechaSalida, GestionUsuario.usuarioActual.Email);
            listaReservas.Add(nuevaReserva);

            Console.WriteLine("Reserva creada con los siguientes detalles:");
            Console.WriteLine($"ID Reserva: {nuevaReserva.IDReserva}");
            Console.WriteLine($"Número de Habitación: {nuevaReserva.NumeroHabitacion}");
            Console.WriteLine($"Fecha de Llegada: {nuevaReserva.FechaInicio.ToShortDateString()}");
            Console.WriteLine($"Fecha de Salida: {nuevaReserva.FechaFin.ToShortDateString()}");
            Console.WriteLine($"Fecha de Reserva: {nuevaReserva.FechaReserva.ToShortDateString()}");
            Console.WriteLine($"Email del Cliente: {nuevaReserva.EmailCliente}");

            Console.WriteLine("Presione una tecla para continuar.");
            Console.ReadLine();

        }


        public void CancelarReserva()
        {
            Console.Clear();
            Console.WriteLine("Ingrese su email:");
            string? email = Console.ReadLine();
            var reservasCliente = listaReservas.Where(r => r.EmailCliente == email).ToList();

            if (reservasCliente.Count == 0)
            {
                Console.WriteLine("No se encontraron reservas para este email.");
                return;
            }


            Console.WriteLine("Reservas encontradas:");
            foreach (var reserva in reservasCliente)
            {
                Console.WriteLine($"ID: {reserva.IDReserva}, Habitación: {reserva.NumeroHabitacion}, Cliente: {reserva.EmailCliente}, " +
                                  $"Desde: {reserva.FechaInicio.ToShortDateString()} Hasta: {reserva.FechaFin.ToShortDateString()}");
            }

            Console.WriteLine("Ingrese el ID de la reserva que desea eliminar:");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int idReserva))
            {

                var reservaAEliminar = reservasCliente.FirstOrDefault(r => r.IDReserva == idReserva);

                if (reservaAEliminar != null)
                {
                    listaReservas.Remove(reservaAEliminar);
                    Console.WriteLine("La reserva ha sido eliminada exitosamente.");
                    Console.WriteLine("Ingrese una tecla para continuar");
                    Console.ReadLine();
                    Menu.MenuPrincipal();
                }
                else
                {
                    Console.WriteLine("ID de reserva no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número válido.");
            }

            Console.ReadLine();
            Menu.MenuPrincipal();
        }

        public void ModificarReserva()
        {
            Console.Clear();
            Console.WriteLine("Ingrese su email:");
            string? email = Console.ReadLine();
            var reservasCliente = listaReservas.Where(r => r.EmailCliente == email).ToList();

            if (reservasCliente.Count == 0)
            {
                Console.WriteLine("No se encontraron reservas para este email.");
                return;
            }


            Console.WriteLine("Reservas encontradas:");
            foreach (var reserva in reservasCliente)
            {
                Console.WriteLine($"ID: {reserva.IDReserva}, Habitación: {reserva.NumeroHabitacion}, Cliente: {reserva.EmailCliente}, " +
                                  $"Desde: {reserva.FechaInicio.ToShortDateString()} Hasta: {reserva.FechaFin.ToShortDateString()}");
            }

            Console.WriteLine("Ingrese el ID de la reserva que desea modificar:");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int idReserva))
            {

                var reserva = reservasCliente.FirstOrDefault(r => r.IDReserva == idReserva);

                if (reserva != null)
                {
                    Console.WriteLine($"Reserva encontrada: ID {reserva.IDReserva}, Habitación {reserva.NumeroHabitacion}, " +
                               $"Desde {reserva.FechaInicio.ToShortDateString()} Hasta {reserva.FechaFin.ToShortDateString()}");
                }

                Console.WriteLine("Ingrese el NUEVO número de habitación");
                string? numhab = Console.ReadLine();
                if (int.TryParse(numhab, out int numHabitacion))
                {
                    reserva.NumeroHabitacion = numHabitacion;

                }

                Console.WriteLine("Ingrese la nueva fecha de inicio dd/mm/yyyy");
                string? nuevaFechaInicio = Console.ReadLine();
                if (DateTime.TryParse(nuevaFechaInicio, out DateTime fechanuevainicio))
                {
                    reserva.FechaInicio = fechanuevainicio;
                }

                Console.WriteLine("Ingrese la nueva fecha de fin dd/mm/yyyy");
                string? nuevaFechaFin = Console.ReadLine();
                if (DateTime.TryParse(nuevaFechaFin, out DateTime fechanuevafin
                    ))
                {
                    reserva.FechaFin = fechanuevafin;
                }

                Console.WriteLine("Reserva modificada exitosamente.");
            }


            Console.ReadLine();
            Menu.MenuPrincipal();
        }

        public void ListarHuespedes()
        {
            Console.Clear();
            DateTime fechaHoy = DateTime.Today;

            foreach (var reserva in listaReservas)
            {
                if (reserva.FechaInicio <= fechaHoy && reserva.FechaFin >= fechaHoy && reserva.EstaPagada)
                {

                    Console.WriteLine($"El usuario {reserva.EmailCliente} tiene una reserva {reserva.IDReserva}");
                }
            }
        }

        public List<Reserva> ObtenerHistorialReservasPorEmail(string email)
        {
            return listaReservas.Where(reserva => reserva.EmailCliente == email).ToList();
        }

        public void MostrarHistorialReservas()
        {


            Console.Clear();
            if (GestionUsuario.usuarioActual == null)
            {
                Console.WriteLine("No hay un usuario logueado.");
                return;
            }

            string email = GestionUsuario.usuarioActual.Email;
            var historial = ObtenerHistorialReservasPorEmail(email);

            if (historial.Count == 0)
            {
                Console.WriteLine("No hay reservas registradas para este usuario.");
                return;
            }

            Console.WriteLine("Historial de Reservas:");
            foreach (var reserva in historial)
            {
                Console.WriteLine($"ID Reserva: {reserva.IDReserva}, Número de Habitación: {reserva.NumeroHabitacion}, " +
                                  $"Fecha de Inicio: {reserva.FechaInicio.ToShortDateString()}, " +
                                  $"Fecha de Fin: {reserva.FechaFin.ToShortDateString()}, " +
                                  $"Email del Cliente: {reserva.EmailCliente}");

            }
            Console.WriteLine("Digite una tecla para continuar");
            Console.ReadLine();
            Menu.MenuPrincipal();
        }


        public void EjecutarPago()
        {
            Console.Write("Ingrese el número de reserva que desea pagar: ");
            string? numeror = Console.ReadLine();
            if (int.TryParse(numeror, out int numeroReserva))
            {
                var reserva = listaReservas.FirstOrDefault(r => r.IDReserva == numeroReserva);
                if (reserva == null)
                {
                    Console.WriteLine("Reserva no encontrada");
                    return;
                }

                Console.WriteLine("Ingrese su numero de tarjeta de crédito, o cuenta bancaria para confirmar el pagamento");
                string numerotarjeta = Console.ReadLine();
                reserva.EstaPagada = true;
                Console.WriteLine($"Pago realizado para la reserva {numeroReserva}. La reserva se encuentra confirmada y pagada.");
                GenerarComprobanteDePago(reserva);
            }
            else
            {
                Console.WriteLine("Número de reserva inválido. Por favor, ingrese un número válido.");
            }



            Console.WriteLine("Ingrese una letra para continuar");
            Console.ReadLine();
            Menu.MenuPrincipal();
        }



        public void GenerarComprobanteDePago(Reserva reserva)
        {

            Console.Clear();
            string comprobante = "Comprobante de Pago\n" +
                             "-------------------------------\n" +
                             "Número de Reserva: " + reserva.IDReserva + "\n" +
                             "Fechas: Desde " + reserva.FechaInicio.ToShortDateString() +
                             " Hasta " + reserva.FechaFin.ToShortDateString() + "\n" +
                             "Email: " + reserva.EmailCliente + "\n" +
                             "Estado: " + (reserva.EstaPagada ? "Pagada" : "Pendiente") + "\n" +
                             "-------------------------------\n";

            Console.WriteLine(comprobante);
            Console.WriteLine("Ingrese una letra para continuar");
            Console.ReadLine();
            Menu.MenuPrincipal();

        }

        public void MostrarHabitacionesMasReservadas()
        {
            Console.Clear();
            List<Habitacion> habitacionesMasReservadas = new List<Habitacion>();
            Console.WriteLine("Las habitaciones mas reservadas son:");
            foreach (var habitacion in listaHabitaciones)
            {

                int conteoReservas = listaReservas.Where(r => r.NumeroHabitacion == habitacion.NumeroHabitacion).Count();

                if (conteoReservas > 1)
                {

                    Console.WriteLine($"Habitación {habitacion.NumeroHabitacion}: {conteoReservas} reservas");
                }
            }
        }
    }

    