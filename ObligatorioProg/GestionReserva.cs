using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{
    public class GestionReserva
    {
        public static List<Reserva> Reservas = new List<Reserva>();

        public static bool CrearReserva(Reserva nuevaReserva)
        {
            Reservas.Add(nuevaReserva);
            Console.WriteLine($"Reserva para la habitación {nuevaReserva.NumeroHabitacion} añadida exitosamente.");
            return true;
        }


        public static void ListarReservas()
        {
            foreach (var reserva in Reservas)
            {
                Console.WriteLine($"Habitación: {reserva.NumeroHabitacion}, Cliente: {reserva.EmailCliente}, " +
                                  $"Desde: {reserva.FechaInicio.ToShortDateString()} Hasta: {reserva.FechaFin.ToShortDateString()}");
            }
        }
    }
}
