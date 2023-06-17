using Personaje;
using System;
using System.Collections.Generic;

LinkedList<Perso> listaPersonajes = new LinkedList<Perso>();

            Console.Write("Ingrese la cantidad de personajes: ");
            int cantidadPersonajes = int.Parse(Console.ReadLine());

            for (int i = 0; i < cantidadPersonajes; i++)
            {
                Console.WriteLine($"Ingrese los datos del personaje #{i+1}");

                Perso nuevoPersonaje = new Perso();
                nuevoPersonaje.CrearPersonaje();

                // Agregar el personaje a la lista enlazada
                listaPersonajes.AddLast(nuevoPersonaje);
            }

