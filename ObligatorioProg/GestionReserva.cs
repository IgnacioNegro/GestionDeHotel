using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObligatorioProg;
using System;
using System.Collections.Generic;
using System.Linq;

public class GestionReservas
{
    private List<Habitacion> listaHabitaciones;
    private List<Reserva> listaReservas;
    private DateTime fechaLlegada;
    private DateTime fechaSalida;

    public GestionReservas()
    {
        listaHabitaciones = new List<Habitacion>();
        listaReservas = new List<Reserva>();

        PrecargarHabitaciones();
        PrecargarReservas();
    }

    // Método para precargar las habitaciones
    private void PrecargarHabitaciones()
    {
        listaHabitaciones.Add(new Habitacion(101, "Simple", 1, 75.50m));
        listaHabitaciones.Add(new Habitacion(102, "Doble", 2, 120.00m));
        listaHabitaciones.Add(new Habitacion(103, "Triple", 3, 150.75m));
        listaHabitaciones.Add(new Habitacion(104, "Suite", 2, 300.00m));
        listaHabitaciones.Add(new Habitacion(105, "Doble", 2, 115.00m));
        listaHabitaciones.Add(new Habitacion(201, "Simple", 1, 70.00m));
        listaHabitaciones.Add(new Habitacion(202, "Suite Deluxe", 4, 500.00m));
        listaHabitaciones.Add(new Habitacion(203, "Doble", 2, 125.50m));
        listaHabitaciones.Add(new Habitacion(204, "Triple", 3, 160.00m));
        listaHabitaciones.Add(new Habitacion(301, "Simple", 1, 85.00m));
        listaHabitaciones.Add(new Habitacion(302, "Suite Junior", 2, 280.00m));
        listaHabitaciones.Add(new Habitacion(303, "Doble", 2, 135.00m));
        listaHabitaciones.Add(new Habitacion(304, "Suite Presidencial", 5, 1000.00m));
        listaHabitaciones.Add(new Habitacion(401, "Simple", 1, 90.00m));
        listaHabitaciones.Add(new Habitacion(402, "Doble Superior", 2, 150.00m));
        listaHabitaciones.Add(new Habitacion(403, "Triple Deluxe", 3, 200.00m));
        listaHabitaciones.Add(new Habitacion(404, "Suite Familiar", 4, 450.00m));
        listaHabitaciones.Add(new Habitacion(501, "Penthouse", 6, 1500.00m));
        listaHabitaciones.Add(new Habitacion(502, "Simple Económica", 1, 60.00m));
        listaHabitaciones.Add(new Habitacion(503, "Doble Económica", 2, 100.00m));


    }

    // MétodO para precargar reservas
    public void PrecargarReservas()
    {
        listaReservas.Add(new Reserva(101, new DateTime(2024, 10, 25), new DateTime(2024, 10, 28), "juan.perez@example.com"));
        listaReservas.Add(new Reserva(102, new DateTime(2024, 11, 1), new DateTime(2024, 11, 5), "maria.gonzalez@example.com"));
        listaReservas.Add(new Reserva(103, new DateTime(2024, 10, 30), new DateTime(2024, 11, 2), "carlos.lopez@example.com"));
        listaReservas.Add(new Reserva(104, new DateTime(2024, 12, 15), new DateTime(2024, 12, 20), "ana.rodriguez@example.com"));
        listaReservas.Add(new Reserva(201, new DateTime(2025, 1, 5), new DateTime(2025, 1, 10), "pedro.martinez@example.com"));
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
            Console.WriteLine($"Número: {habitacion.NumeroHabitacion}, Tipo: {habitacion.Tipo}, Precio: {habitacion.Precio:C}");
        }
    }

    //opcion 10 del menu, consultar habitaciones no neresrvadas
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
        return listaHabitaciones
            .Where(h => !listaReservas.Any(r =>
                r.NumeroHabitacion == h.NumeroHabitacion &&
                r.FechaInicio < fechaSalida &&
                r.FechaFin > fechaLlegada))
            .ToList();
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

        // Listar habitaciones disponibles con las fechas capturadas guardadas en variable
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

        Console.Write("\nIngrese el número de la habitación: ");
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
}