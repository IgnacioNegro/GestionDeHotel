using ObligatorioProg;
using System.Reflection.Metadata.Ecma335;

GestionUsuario gestionusuario = new();
GestionReservas gestionreserva = new();
Menu.MenuIniciarSesion();

bool salir = false;
Dictionary<int, Action> keyValuePairs = new()
{
    { 0, () => salir = true },
    { 1, () => Menu.GestionUsuarios() },
    { 2, () => Menu.ReservasyCancelaciones() },
    { 3, () => Menu.MenuPrincipal() },
    { 4, () => Menu.GestionDePagos() },
    { 5, () => Menu.MenuPrincipal() },
    {6, () => gestionusuario.RegistrarUsuario()},
    {7, () => gestionusuario.IniciarSesion()},
    {8,()=> gestionusuario.RecuperarContrasena() },
    {10,()=> gestionreserva.ConsultarHabitacionesDisponibles()},
    {11, () => gestionreserva.RealizarReserva() },
    {12, () => gestionreserva.ModificarReserva() },
    {13, () => gestionreserva.CancelarReserva() },
    {90, () => gestionreserva.ListarReservas() }
};


/*while (!salir)
{
    string? input = Console.ReadLine();

    if (int.TryParse(input, out int opcion))
    {
        if (estaEnMenuPrincipal() && opcion != 6 && opcion != 7 && opcion != 3)
        {
            Console.WriteLine("Opción no válida en el menú de Inicio de Sesión.");
            continue; 
        }

        if (keyValuePairs.ContainsKey(opcion))
        {
            keyValuePairs[opcion]();
        }
        else
        {
            Console.WriteLine("Opción no válida.");
        }
    }
    else
    {
        Console.WriteLine("Por favor ingresa un número válido dentro de las opciones.");
    }

    bool estaEnMenuPrincipal()
    {
        return true;
    }
}*/
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

