using Personaje;
using usaJson;
using combate;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        void JugarMultiplayer()
        {
                        Console.WriteLine(@"
            ██████╗  ██████╗ ██╗  ██╗███████╗███╗   ███╗ ██████╗ ███╗   ██╗
            ██╔═══██╗██╔═══██╗██║ ██╔╝██╔════╝████╗ ████║██╔═══██╗████╗  ██║
            ██║   ██║██║   ██║█████╔╝ █████╗  ██╔████╔██║██║   ██║██╔██╗ ██║
            ██║   ██║██║   ██║██╔═██╗ ██╔══╝  ██║╚██╔╝██║██║   ██║██║╚██╗██║
            ██████╔╝ ╚██████╔╝██║  ██╗███████╗██║ ╚═╝ ██║╚██████╔╝██║ ╚████║
            ██╔════╝  ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═══╝
            ██║               

                            █▀▄▀█ █ █▄░█ █   █▀▀ ▄▀█ █▀▄▀█ █▀▀
                            █░▀░█ █ █░▀█ █   █▄█ █▀█ █░▀░█ ██▄

            ");

            Console.WriteLine("Presiona cualquier boton para comenzar");
            Console.ReadLine();

            Console.WriteLine(@"
            █▀█ █▀▀ █▀█ █▀ █▀█ █▄░█ ▄▀█ ░░█ █▀▀ █▀ ▀
            █▀▀ ██▄ █▀▄ ▄█ █▄█ █░▀█ █▀█ █▄█ ██▄ ▄█ ▄
            ");

                    List<Perso> listaPersonajes = new List<Perso>();
                    var persjson = new PersonajesJson();
                    var selec = new SeleccionDePersonajes();

                    string nombreArchivo = "personajes";
                    PersonajesJson nuevoJson = new PersonajesJson();
                    if (nuevoJson.Existe(nombreArchivo))
                    {
                        listaPersonajes = persjson.LeerPersonajes(nombreArchivo);
                        selec.MostrarPersonajes(listaPersonajes);
                    }
                    else
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            var nuevoPersonaje = new Perso();
                            var fabrica = new FabricaDePersonajes();
                            nuevoPersonaje = fabrica.CrearPersonaje();
                            listaPersonajes.Add(nuevoPersonaje);
                            persjson.GuardarPersonajes(nombreArchivo, ".json", nuevoPersonaje);
                        }
                        selec.MostrarPersonajes(listaPersonajes);
                        
                    }
                    

                    var player1 = new Perso();
                    var player2 = new Perso();
                    var pelea = new caractPelea();
                    
                    Console.WriteLine(@"
            █▀▀ █░░ █ ░░█ ▄▀█   █▀█ █░░ ▄▀█ █▄█ █▀▀ █▀█   ▄█
            ██▄ █▄▄ █ █▄█ █▀█   █▀▀ █▄▄ █▀█ ░█░ ██▄ █▀▄   ░█ ");
                    player1 = selec.Eleccion(listaPersonajes);
                    Console.WriteLine(@"
            █▀▀ █░░ █ ░░█ ▄▀█   █▀█ █░░ ▄▀█ █▄█ █▀▀ █▀█   ▀█
            ██▄ █▄▄ █ █▄█ █▀█   █▀▀ █▄▄ █▀█ ░█░ ██▄ █▀▄   █▄");
                    player2 = selec.Eleccion(listaPersonajes);

                

                    do 
                    {
                        Console.WriteLine("-------NUEVO TURNO-------");
                        if (player1.Salud > 0 && player2.Salud >0)
                        {
                            Console.WriteLine("---¡Es Turno de "+player1.Nombre+"!---");
                            Console.WriteLine(player1.Nombre);
                            Console.WriteLine("SALUD:" + player1.Salud);
                            pelea.combate(player1, player2);
                        }
                        if (player1.Salud > 0 && player2.Salud >0)
                        {
                            Console.WriteLine("---¡Es Turno de "+player2.Nombre+"!---");
                            Console.WriteLine(player2.Nombre);
                            Console.WriteLine("SALUD:" + player2.Salud);
                            pelea.combate(player2, player1);
                        }
                            
                    }while (player1.Salud > 0 && player2.Salud > 0);
                    if(player2.Salud <= 0)
                    {
                        Console.WriteLine(@"
            █▀▀ ▄▀█ █▄░█ ▄▀█ █▄░█ ▄▀█ █▀▄ █▀█ █▀█   █▀█ █░░ ▄▀█ █▄█ █▀▀ █▀█   ▄█
            █▄█ █▀█ █░▀█ █▀█ █░▀█ █▀█ █▄▀ █▄█ █▀▄   █▀▀ █▄▄ █▀█ ░█░ ██▄ █▀▄   ░█");
                        Console.WriteLine("Datos del ganador:");
                        selec.ReadOnlyOne(player1);
                        List<Perso> listaGanadores = new List<Perso>();
                        string ArchivoGanadores = "ganadores";
                        if (nuevoJson.Existe(ArchivoGanadores))
                        {
                            listaGanadores = persjson.LeerPersonajes(ArchivoGanadores);
                            listaGanadores.Add(player1);
                            persjson.GuardarPersonajes(ArchivoGanadores, "json", player1);
                        }
                        else
                        {
                            listaGanadores.Add(player1);
                            persjson.GuardarPersonajes(ArchivoGanadores, "json", player1);
                        }
                    }
                    else if(player1.Salud <=0)
                    {
                        Console.WriteLine(@"
            █▀▀ ▄▀█ █▄░█ ▄▀█ █▄░█ ▄▀█ █▀▄ █▀█ █▀█   █▀█ █░░ ▄▀█ █▄█ █▀▀ █▀█   ▀█
            █▄█ █▀█ █░▀█ █▀█ █░▀█ █▀█ █▄▀ █▄█ █▀▄   █▀▀ █▄▄ █▀█ ░█░ ██▄ █▀▄   █▄");
                        Console.WriteLine("---------Datos del ganador---------");
                        selec.ReadOnlyOne(player2);
                        List<Perso> listaGanadores = new List<Perso>();
                        string ArchivoGanadores = "ganadores";
                        if (nuevoJson.Existe(ArchivoGanadores))
                        {
                            listaGanadores = persjson.LeerPersonajes(ArchivoGanadores);
                            listaGanadores.Add(player1);
                            persjson.GuardarPersonajes(ArchivoGanadores, "json", player1);
                        }
                        else
                        {
                            listaGanadores.Add(player1);
                            persjson.GuardarPersonajes(ArchivoGanadores, "json", player1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                    }        
        }
        void JugarDeNuevoMultiplayer()
        {
            Console.WriteLine("\nJUGAR DE NUEVO? (1:SI / 0:NO)");
            int deNuevo = int.Parse(Console.ReadLine());
            if (deNuevo == 1)
            {
                JugarMultiplayer();
            }else if (deNuevo == 0)
            {
                Console.WriteLine(@"
                        █▀▀ █ █▄░█
                        █▀░ █ █░▀█
                ");
            }else
            {
                Console.WriteLine("ERROR, OPCION NO VALIDA. INTENTELO NUEVAMENTE");
                JugarDeNuevoMultiplayer();
            }
        }

        JugarMultiplayer();
        JugarDeNuevoMultiplayer();
    }
}