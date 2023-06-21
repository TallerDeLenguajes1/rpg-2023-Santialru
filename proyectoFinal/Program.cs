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
    Console.WriteLine(item.Nombre);
    Console.WriteLine(item.Apodo);
    Console.WriteLine(item.tipo);
    Console.WriteLine(item.Fecha);
    Console.Write(item.Edad);
    Console.Write(item.Velocidad);
    Console.Write(item.Destreza);
    Console.Write(item.Fuerza);
    Console.Write(item.Nivel);
    Console.Write(item.Armadura);
    Console.Write(item.Salud);

    
}
