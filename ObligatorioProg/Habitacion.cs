using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{
    public class Habitacion
    {
        public int NumeroHabitacion { get; set; }
        public string Tipo { get; set; }

        public int cantidadPersonas { get; set; }
        public decimal Precio { get; set; }

        public bool Disponible { get; set; }
        public List<DateTime> FechasReservadas { get; set; }
        public Habitacion(int numerohabitacion, string tipo, int cantidadpersonas, decimal precio)
        {
            NumeroHabitacion = numerohabitacion;
            Tipo = tipo;
            cantidadPersonas = cantidadpersonas;
            Precio = precio;
            FechasReservadas = new List<DateTime>();
        }
    }


    //el molde para hacer habitaciones. estado reservado o no (booleano) ocupada reservada o libre?? // 
    //reservada si o no, atributo y dejar el booleano libre ocupada.
    //cuando se reserva le pongo true.
    //crear array de habitaciones
    //hacer un array solo con las  habitaciones reservadas es mejor q poner un atributo

}


