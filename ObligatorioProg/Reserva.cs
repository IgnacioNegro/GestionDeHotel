using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{
    public class Reserva
    {
        private static int IDgenerador = 5000;
        public int IDReserva { get; private set; }

        public int NumeroHabitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string EmailCliente { get; private set; }
        public DateTime FechaReserva { get; set; }
        private int UsuarioId { get; }
        public bool EstaPagada { get; set; }

        public Reserva(int numerohabitacion, DateTime fechainicio, DateTime fechafin, DateTime Fechareserva, string emailCliente)
        {
            IDReserva = IDgenerador++;
            NumeroHabitacion = numerohabitacion;
            FechaInicio = fechainicio;
            FechaFin = fechafin;
            FechaReserva = Fechareserva;
            EmailCliente = emailCliente;
            EstaPagada = false;
        }

        public Reserva(int numerohabitacion, DateTime fechainicio, DateTime fechafin, string emailCliente)
        {
            IDReserva = IDgenerador++;
            NumeroHabitacion = numerohabitacion;
            FechaInicio = fechainicio;
            FechaFin = fechafin;
            EmailCliente = emailCliente;
            EstaPagada = false;

        }
    }
}

