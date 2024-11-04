using ObligatorioProg;
using System;

public class Precarga
{
    public List<Habitacion> PrecargarHabitaciones()
    {
        List<Habitacion> listaHabitaciones = new List<Habitacion>
        {
            new Habitacion(101, "Simple", 1, 75.50m),
            new Habitacion(102, "Doble", 2, 120.00m),
            new Habitacion(103, "Triple", 3, 150.75m),
            new Habitacion(104, "Suite", 2, 300.00m),
            new Habitacion(105, "Doble", 2, 115.00m),
            new Habitacion(201, "Simple", 1, 70.00m),
            new Habitacion(202, "Suite Deluxe", 4, 500.00m),
            new Habitacion(203, "Doble", 2, 125.50m),
            new Habitacion(204, "Triple", 3, 160.00m),
            new Habitacion(301, "Simple", 1, 85.00m),
            new Habitacion(302, "Suite Junior", 2, 280.00m),
            new Habitacion(303, "Doble", 2, 135.00m),
            new Habitacion(304, "Suite Presidencial", 5, 1000.00m),
            new Habitacion(401, "Simple", 1, 90.00m),
            new Habitacion(402, "Doble Superior", 2, 150.00m),
            new Habitacion(403, "Triple Deluxe", 3, 200.00m),
            new Habitacion(404, "Suite Familiar", 4, 450.00m),
            new Habitacion(501, "Penthouse", 6, 1500.00m),
            new Habitacion(502, "Simple Económica", 1, 60.00m),
            new Habitacion(503, "Doble Económica", 2, 100.00m)
        };

        return listaHabitaciones;
    }

    public List<Reserva> PrecargarReservas()
    {
        List<Reserva> listaReservas = new List<Reserva>
        {
            new Reserva(101, new DateTime(2024, 10, 25), new DateTime(2024, 10, 28), "juan.perez@example.com"),
            new Reserva(102, new DateTime(2024, 11, 1), new DateTime(2024, 11, 5), "maria.gonzalez@example.com"),
            new Reserva(103, new DateTime(2024, 10, 30), new DateTime(2024, 11, 2), "carlos.lopez@example.com"),
            new Reserva(104, new DateTime(2024, 12, 15), new DateTime(2024, 12, 20), "ana.rodriguez@example.com"),
            new Reserva(104, new DateTime(2024, 12, 22), new DateTime(2024, 12, 28), "ana.rodriguez@example.com"),
            new Reserva(201, new DateTime(2025, 1, 5), new DateTime(2025, 1, 10), "pedro.martinez@example.com"),
            new Reserva(204, new DateTime(2025, 2, 5), new DateTime(2025, 2, 10), "pedro.martinez@example.com"),
            new Reserva(204, new DateTime(2025, 2, 20), new DateTime(2025, 2, 25), "admin"),
            new Reserva(204, new DateTime(2025, 2, 1), new DateTime(2025, 2, 5), "maria.gonzalez@example.com"),
            new Reserva(204, new DateTime(2025, 1, 25), new DateTime(2025, 1, 30), "admin")
        };

        return listaReservas;
    }

    public List<Usuario> PrecargarUsuarios()
    {
        List<Usuario> listaUsuarios = new List<Usuario>
        {
            new Usuario("Juan", "Pérez", new DateTime(1990, 1, 10), "juan.perez@example.com", "Uruguay", "CI", 12345678, 987654321, "password123"),
            new Usuario("María", "González", new DateTime(1995, 2, 20), "maria.gonzalez@example.com", "Argentina", "DNI", 87654321, 987123456, "mariaPass!"),
            new Usuario("Carlos", "López", new DateTime(1988, 3, 15), "carlos.lopez@example.com", "Chile", "RUT", 11223344, 987654123, "carlosSecure"),
            new Usuario("Ana", "Rodríguez", new DateTime(1992, 4, 25), "ana.rodriguez@example.com", "Perú", "DNI", 44332211, 985632147, "ana456"),
            new Usuario("Pedro", "Martínez", new DateTime(1985, 5, 5), "pedro.martinez@example.com", "Brasil", "CPF", 99887766, 984563214, "pedro@mart"),
            new Usuario("Admin", "Admin", new DateTime(1985, 5, 5), "admin", "Brasil", "CPF", 99887766, 984563214, "admin")
        };

        return listaUsuarios;
    }
}
