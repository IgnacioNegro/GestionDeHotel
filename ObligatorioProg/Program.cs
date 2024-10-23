using ObligatorioProg;

GestionUsuario gestionusuario = new();
GestionHabitacion gestionhabitacion = new();
Menu.MenuIniciarSesion();
new Precarga(gestionusuario, gestionhabitacion);


bool salir = false;
Dictionary<int, Action> keyValuePairs = new()
{
    { 0, () => salir = true },
    { 1, () => Menu.GestionUsuarios() },
    { 2, () => Menu.ReservasyCancelaciones() },
    { 3, () => Menu.MenuPrincipal() },
    { 4, () => Menu.GestionDePagos() },
    { 5, () => Menu.MenuPrincipal() },
    {6, () => gestionusuario.IngresarUsuario()},
    {7, () => gestionusuario.IniciarSesion()},
    {10, () => gestionhabitacion.ListarHabitaciones() }
};



while (!salir)
{
    string? input = Console.ReadLine();

    if (int.TryParse(input, out int opcion))
    {
        if (keyValuePairs.ContainsKey(opcion))
        {
            keyValuePairs[opcion]();
        }
        else
        {
            Console.WriteLine("Opción no válida");
        }
    }
    else
    {
        Console.WriteLine("Por favor ingresa un número válido.");
    }


}

Habitacion habitacion1 = new Habitacion(129, "suite", 4, 10m);
Reserva nuevareserva = new Reserva(102,new DateTime(2024, 11, 20),new DateTime(2024, 11, 22),"pedro.martinez@example.com");


