using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{
    public class GestionHabitacion
    {

        public List<Habitacion> ListaHabitaciones = new List<Habitacion>();

        public  void AgregarHabitacion(Habitacion habitacion)
        {
            ListaHabitaciones.Add(habitacion);
            Console.WriteLine($"Habitación {habitacion.NumeroHabitacion} de tipo {habitacion.Tipo} añadida.");
        }

        public  void ListarHabitaciones()
        {
            foreach (var habitacion in ListaHabitaciones)
            {
                Console.WriteLine($"Número: {habitacion.NumeroHabitacion}, Tipo: {habitacion.Tipo}, Precio: {habitacion.Precio:C}");
            }
        }

        public  Habitacion BuscarHabitacion(int numero)
        {
            return ListaHabitaciones.FirstOrDefault(h => h.NumeroHabitacion == numero);
        }

        public void IngresarHabitacion(Habitacion habitacion)
        {
            ListaHabitaciones.Add(habitacion);
        }



    }


}
