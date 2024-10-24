﻿using System;
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
    }

    // Método para precargar reservas
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

    // Listar habitaciones disponibles en un rango de fechas
    public List<Habitacion> ConsultarHabitacionesDisponibles()
    {
        return listaHabitaciones
            .Where(h => !listaReservas.Any(r =>
                r.NumeroHabitacion == h.NumeroHabitacion &&
                r.FechaInicio < fechaSalida &&
                r.FechaFin > fechaLlegada))
            .ToList();


        Console.WriteLine("Ingrese una tecla para continuar");
        Console.ReadLine();
        Menu.MenuPrincipal();
    }

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

        // Listar habitaciones disponibles utilizando las fechas capturadas
        var habitacionesDisponibles = ConsultarHabitacionesDisponibles();

        if (habitacionesDisponibles.Count == 0)
        {
            Console.WriteLine("No hay habitaciones disponibles para las fechas seleccionadas.");
            return;
        }

        Console.WriteLine("\nSeleccione el número de habitación de las disponibles:");
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

        // Validar si la habitación elegida está dentro de las disponibles
        var habitacionSeleccionada = habitacionesDisponibles.FirstOrDefault(h => h.NumeroHabitacion == numeroHabitacion);

        if (habitacionSeleccionada == null)
        {
            Console.WriteLine("La habitación seleccionada no está disponible.");
            return;
        }

        // Crear la reserva y agregarla a la lista
        var nuevaReserva = new Reserva(numeroHabitacion, fechaLlegada, fechaSalida, GestionUsuario.usuarioActual.Email);
        listaReservas.Add(nuevaReserva);

        Console.WriteLine("\nReserva realizada con éxito:");
        Console.WriteLine($"ID Reserva: {nuevaReserva.IDReserva}, Habitación: {nuevaReserva.NumeroHabitacion}, " +
                          $"Desde: {nuevaReserva.FechaInicio.ToShortDateString()} Hasta: {nuevaReserva.FechaFin.ToShortDateString()}");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private bool EsHabitacionDisponible(int numeroHabitacion, DateTime inicio, DateTime fin)
    {
        return !listaReservas.Any(r =>
            r.NumeroHabitacion == numeroHabitacion &&
            r.FechaInicio < fin &&
            r.FechaFin > inicio);
    }

    // Listar todas las habitaciones
    public void ListarHabitaciones()
    {
        foreach (var habitacion in listaHabitaciones)
        {
            Console.WriteLine($"Número: {habitacion.NumeroHabitacion}, Tipo: {habitacion.Tipo}, Precio: {habitacion.Precio:C}");
        }
    }
}




    // Método para realizar una nueva reserva
    /*public void RealizarReserva()
    {
        Console.Clear();

        // Captura de las fechas de llegada y salida
        Console.Write("Ingrese su fecha de llegada (dd/mm/yyyy): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaLlegada))
        {
            Console.WriteLine("Fecha inválida.");
            return;
        }

        Console.Write("Ingrese su fecha de salida (dd/mm/yyyy): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime fechaSalida))
        {
            Console.WriteLine("Fecha inválida.");
            return;
        }

        // Listar habitaciones disponibles para las fechas ingresadas
        var habitacionesDisponibles = ConsultarHabitacionesDisponibles(fechaLlegada, fechaSalida);

        if (habitacionesDisponibles.Count == 0)
        {
            Console.WriteLine("No hay habitaciones disponibles para las fechas seleccionadas.");
            return;
        }

        Console.WriteLine("\nSeleccione el número de habitación de las disponibles:");
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

        // Validar si la habitación elegida está dentro de las disponibles
        var habitacionSeleccionada = habitacionesDisponibles.FirstOrDefault(h => h.NumeroHabitacion == numeroHabitacion);

        if (habitacionSeleccionada == null)
        {
            Console.WriteLine("La habitación seleccionada no está disponible.");
            return;
        }

        // Crear la reserva y agregarla a la lista
        var nuevaReserva = new Reserva(numeroHabitacion, fechaLlegada, fechaSalida, GestionUsuario.usuarioActual.Email);
        listaReservas.Add(nuevaReserva);

        Console.WriteLine("\nReserva realizada con éxito:");
        Console.WriteLine($"ID Reserva: {nuevaReserva.IDReserva}, Habitación: {nuevaReserva.NumeroHabitacion}, " +
                          $"Desde: {nuevaReserva.FechaInicio.ToShortDateString()} Hasta: {nuevaReserva.FechaFin.ToShortDateString()}");
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }*/


   /* // Verificar si una habitación está disponible en un rango de fechas/*  public class GestionReserva
    {

            public List<Reserva> listaReservas { get; set; }

            public GestionReserva()
            {

                listaReservas=new List<Reserva>();
                PrecargarReservas();
            }
            public void PrecargarReservas()
        {
        
            listaReservas.Add(new Reserva(101, new DateTime(2024, 10, 25), new DateTime(2024, 10, 28), "juan.perez@example.com"));
            listaReservas.Add(new Reserva(102, new DateTime(2024, 11, 1), new DateTime(2024, 11, 5), "maria.gonzalez@example.com"));
            listaReservas.Add(new Reserva(103, new DateTime(2024, 10, 30), new DateTime(2024, 11, 2), "carlos.lopez@example.com"));
            listaReservas.Add(new Reserva(104, new DateTime(2024, 12, 15), new DateTime(2024, 12, 20), "ana.rodriguez@example.com"));
            listaReservas.Add(new Reserva(201, new DateTime(2025, 1, 5), new DateTime(2025, 1, 10), "pedro.martinez@example.com"));
        }

            public void ListarReservas()
        {
            Console.WriteLine("Reservas precargadas:");
            foreach (var reserva in listaReservas)
            {
                Console.WriteLine($"ID: {reserva.IDReserva}, Habitación: {reserva.NumeroHabitacion}, Cliente: {reserva.EmailCliente}, " +
                                  $"Desde: {reserva.FechaInicio.ToShortDateString()} Hasta: {reserva.FechaFin.ToShortDateString()}");
            }
        }
            public void RealizarReserva()
            {


            Console.Clear();
            Console.Write("Ingrese su fecha de llegada;");
            string? fechallegada = Console.ReadLine();
            DateTime fechafecha;
            if (!DateTime.TryParse(fechallegada, out fechafecha))
            {
                Console.WriteLine("Digite su fecha de llegada en formato dd/mm/yyyy");
            }

            while (!DateTime.TryParse(fechallegada, out fechafecha)) ;

            Console.Write("Ingrese su fecha de salida;");
            string? fechasalida = Console.ReadLine();
            DateTime fsalida;
            if (!DateTime.TryParse(fechallegada, out fsalida))
            {
                Console.WriteLine("Digite su fecha de salida en formato dd/mm/yyyy");
            }

            while (!DateTime.TryParse(fechallegada, out fsalida)) ;

            Console.Write("Ingrese su numero de habitacion;");
            int numeroHabitacion = int.Parse(Console.ReadLine());
            //chequear num habitacion q sea int, validacion.

            DateTime fechaReserva = DateTime.Now;

            Reserva nuevaReserva = new(numeroHabitacion, fechafecha, fsalida,fechaReserva,GestionUsuario.usuarioActual.Email );
            listaReservas.Add(nuevaReserva);
            Console.WriteLine($"Reserva creada con los siguientes detalles:");
            Console.WriteLine($"ID Reserva: {nuevaReserva.IDReserva}");
            Console.WriteLine($"Número de Habitación: {nuevaReserva.NumeroHabitacion}");
            Console.WriteLine($"Fecha de Llegada: {nuevaReserva.FechaInicio.ToShortDateString()}");
            Console.WriteLine($"Fecha de Salida: {nuevaReserva.FechaFin.ToShortDateString()}");
            Console.WriteLine($"Fecha de Reserva: {nuevaReserva.FechaReserva.ToShortDateString()}");
            Console.WriteLine($"Email del Cliente: {nuevaReserva.EmailCliente}");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadLine();
            Menu.MenuPrincipal();
        }


    }
}

*/