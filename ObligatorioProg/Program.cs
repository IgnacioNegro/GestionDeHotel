﻿using ObligatorioProg;

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
    {90, () => gestionreserva.ListarReservas() }
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


