using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{
    public class GestionHabitacion
    {

        public List<Habitacion> listaHabitaciones = new List<Habitacion>();

        private List<Reserva> listaReservas;
        public GestionHabitacion()
        {
          PrecargaHabitaciones();            
        }

    

        private void PrecargaHabitaciones()
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

   

        public  void ListarHabitaciones()
        {
            foreach (var habitacion in listaHabitaciones)
            {
                Console.WriteLine($"Número: {habitacion.NumeroHabitacion}, Tipo: {habitacion.Tipo}, Precio: {habitacion.Precio:C}");
            }
        }


        public void ConsultarHabitacionesDisponibles()
        {
            Console.Clear();
            Console.WriteLine("Habitaciones Disponibles:");

            Console.WriteLine($"Habitaciones: {listaHabitaciones.Count}, Reservas: {listaReservas.Count}");
            var habitacionesDisponibles = listaHabitaciones.Where(h => listaReservas.Any(r => r.NumeroHabitacion == h.NumeroHabitacion)).ToList();

            if (habitacionesDisponibles.Count > 0)
            {
                foreach (var habitacion in habitacionesDisponibles)
                {
                    Console.WriteLine($"Número: {habitacion.NumeroHabitacion}, Tipo: {habitacion.Tipo}, Precio: {habitacion.Precio}");
                }
            }
            else
            {
                Console.WriteLine("No hay habitaciones disponibles.");
            }

            Console.ReadLine();
        }
    }

}


