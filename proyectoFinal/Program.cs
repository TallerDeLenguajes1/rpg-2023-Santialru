using Personaje;
using System;
using System.Collections.Generic;

List<Perso> listaPersonajes = new List<Perso>();

Console.Write("Ingrese la cantidad de personajes: ");
int cantidadPersonajes = int.Parse(Console.ReadLine());

for (int i = 0; i < cantidadPersonajes; i++)
{
    Perso nuevoPersonaje = new Perso();
    FabricaDePersonajes fabrica = new FabricaDePersonajes();
    nuevoPersonaje = fabrica.CrearPersonaje();            
    

    listaPersonajes.Add(nuevoPersonaje);
}


foreach (Perso item in listaPersonajes)
{
    
    Console.WriteLine("\n-------Personaje N° -------");
    Console.WriteLine("Nombre: " + item.Nombre);
    Console.WriteLine("Apodo: " + item.Apodo);
    Console.WriteLine("Tipo: " + item.tipo);
    Console.WriteLine("Fecha de nacimiento: " + item.Fecha);
    Console.Write("Edad: " + item.Edad);
    Console.Write("\nVelocidad: " + item.Velocidad);
    Console.Write("\nDestreza: " + item.Destreza);
    Console.Write("\nFuerza:" + item.Fuerza);
    Console.Write("\nNivel: " + item.Nivel);
    Console.Write("\nArmadura: " + item.Armadura);
    Console.Write("\nSalud: " + item.Salud);
    
}
