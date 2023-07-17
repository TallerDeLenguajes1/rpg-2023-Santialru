using Personaje;
using usaJson;
using System;
using System.Collections.Generic;

List<Perso> listaPersonajes = new List<Perso>();
var persjson = new PersonajesJson();
// Console.Write("Ingrese la cantidad de personajes: ");
// int cantidadPersonajes = int.Parse(Console.ReadLine());

// for (int i = 0; i < cantidadPersonajes; i++)
// {
//     Perso nuevoPersonaje = new Perso();
//     FabricaDePersonajes fabrica = new FabricaDePersonajes();
//     nuevoPersonaje = fabrica.CrearPersonaje();            
//     listaPersonajes.Add(nuevoPersonaje);
// }

string nombreArchivo = "personajes";
PersonajesJson nuevoJson = new PersonajesJson();
if (nuevoJson.Existe(nombreArchivo))
{
    
    listaPersonajes=persjson.LeerPersonajes(nombreArchivo);

    foreach (Perso item in listaPersonajes)
    {
        
        Console.WriteLine("\n-------Personaje N° -------");
        Console.WriteLine("Nombre: " + item.Nombre);
        Console.WriteLine("Apodo: " + item.Apodo);
        Console.WriteLine("Tipo: " + item.Tipo);
        Console.WriteLine("Fecha de nacimiento: " + item.Fecha);
        Console.Write("Edad: " + item.Edad);
        Console.Write("\nVelocidad: " + item.Velocidad);
        Console.Write("\nDestreza: " + item.Destreza);
        Console.Write("\nFuerza:" + item.Fuerza);
        Console.Write("\nNivel: " + item.Nivel);
        Console.Write("\nArmadura: " + item.Armadura);
        Console.Write("\nSalud: " + item.Salud);
        
    }
}else
{
    for (int i = 0; i < 9; i++)
    {
        var nuevoPersonaje = new Perso();
        var fabrica = new FabricaDePersonajes();
        nuevoPersonaje = fabrica.CrearPersonaje();           
        listaPersonajes.Add(nuevoPersonaje);
        persjson.GuardarPersonajes(nombreArchivo,".json",nuevoPersonaje);
    }
    foreach (Perso item in listaPersonajes)
    {
        
        Console.WriteLine("\n-------Personaje N° -------");
        Console.WriteLine("Nombre: " + item.Nombre);
        Console.WriteLine("Apodo: " + item.Apodo);
        Console.WriteLine("Tipo: " + item.Tipo);
        Console.WriteLine("Fecha de nacimiento: " + item.Fecha);
        Console.Write("Edad: " + item.Edad);
        Console.Write("\nVelocidad: " + item.Velocidad);
        Console.Write("\nDestreza: " + item.Destreza);
        Console.Write("\nFuerza:" + item.Fuerza);
        Console.Write("\nNivel: " + item.Nivel);
        Console.Write("\nArmadura: " + item.Armadura);
        Console.Write("\nSalud: " + item.Salud);
        
    }
}

Console.WriteLine("\nElija Player 1: ");
int eleccion1 = int.Parse(Console.ReadLine());
switch (eleccion1)
{
    
    default:
}

Console.WriteLine("\nElija Player 2: ");
int eleccion2 = int.Parse(Console.ReadLine());



while ()
{
    
}


