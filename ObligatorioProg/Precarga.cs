using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioProg
{
    public class Precarga
    {

        public GestionHabitacion gestionHabitacion = new();
        public GestionUsuario gestionUsuario = new();
        public Precarga(GestionUsuario gestionUsuario, GestionHabitacion gestionHabitacion)
        {
            this.gestionUsuario = gestionUsuario;
            PrecargaUser(); 
            this.gestionHabitacion = gestionHabitacion;          
            PrecargaHabitaciones();
        }


          

        public void PrecargaUser()
        {

            gestionUsuario.IngresarUsuario(new Usuario("Juan", "Pérez", new DateTime(1990, 1, 10), "juan.perez@example.com", "Uruguay", "CI", 12345678, 987654321, "password123"));
            gestionUsuario.IngresarUsuario(new Usuario("María", "González", new DateTime(1995, 2, 20), "maria.gonzalez@example.com", "Argentina", "DNI", 87654321, 987123456, "mariaPass!"));
            gestionUsuario.IngresarUsuario(new Usuario("Carlos", "López", new DateTime(1988, 3, 15), "carlos.lopez@example.com", "Chile", "RUT", 11223344, 987654123, "carlosSecure"));
            gestionUsuario.IngresarUsuario(new Usuario("Ana", "Rodríguez", new DateTime(1992, 4, 25), "ana.rodriguez@example.com", "Perú", "DNI", 44332211, 985632147, "ana456"));
            gestionUsuario.IngresarUsuario(new Usuario("Pedro", "Martínez", new DateTime(1985, 5, 5), "pedro.martinez@example.com", "Brasil", "CPF", 99887766, 984563214, "pedro@mart"));

        

        }



        public void PrecargaHabitaciones()
        {
            gestionHabitacion.IngresarHabitacion(new Habitacion(101, "Simple", 1, 75.50m));
            gestionHabitacion.IngresarHabitacion(new Habitacion(102, "Doble", 2, 120.00m));
            gestionHabitacion.IngresarHabitacion(new Habitacion(103, "Triple", 3, 150.75m));
            gestionHabitacion.IngresarHabitacion(new Habitacion(104, "Suite", 2, 300.00m));
            gestionHabitacion.IngresarHabitacion(new Habitacion(105, "Doble", 2, 115.00m));
            gestionHabitacion.IngresarHabitacion(new Habitacion(201, "Simple", 1, 70.00m));
            gestionHabitacion.IngresarHabitacion(new Habitacion(202, "Suite Deluxe", 4, 500.00m));
            gestionHabitacion.IngresarHabitacion(new Habitacion(203, "Doble", 2, 125.50m));
            gestionHabitacion.IngresarHabitacion(new Habitacion(204, "Triple", 3, 160.00m));

        }
    }
}
