using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObligatorioProg
{
    public class GestionReserva
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

