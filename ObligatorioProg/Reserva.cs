using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{
    public class Reserva
    {
        public int NumeroHabitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public DateTime FechaReserva { get; set; }
        public string EmailCliente { get; set; }

        public Reserva(int numerohabitacion, DateTime fechainicio, DateTime fechafin, string email)
        {
            NumeroHabitacion = numerohabitacion;
            FechaInicio = fechainicio;
            FechaFin = fechafin;
            EmailCliente = email;
        }
    }
}
