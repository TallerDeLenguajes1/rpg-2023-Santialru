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
        void MostrarCampeones(List<Perso> ListaCampeones)
        {
            var selec = new SeleccionDePersonajes();
            Console.WriteLine("Mostrar Lista de Campeones Pokemon (1:si / 0:no)");
            int mostCamp;
            int.TryParse(Console.ReadLine(), out mostCamp);
            if (mostCamp == 1)
            {
                foreach (Perso Campeon in ListaCampeones)
                {
                    selec.MostrarPersonajes(ListaCampeones);
                }   
            }
            else if (mostCamp != 1 && mostCamp != 0);
            {
                Console.WriteLine("No se ha seleccionado una opcion valida, intentelo nuevamente");
                MostrarCampeones(ListaCampeones);
            }
        }


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
                    PersonajesJson nuevoJson = new PersonajesJson();
                    string nombreArchivo = "personajes.json";

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
                        }
                        persjson.GuardarPersonajes(nombreArchivo, listaPersonajes);
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
                    

                    List<Perso> listaGanadores = new List<Perso>();
                    if(player2.Salud <= 0)
                    {
            
            
                                    Console.WriteLine(@"
                        █▀▀ ▄▀█ █▄░█ ▄▀█ █▄░█ ▄▀█ █▀▄ █▀█ █▀█   █▀█ █░░ ▄▀█ █▄█ █▀▀ █▀█   ▄█
                        █▄█ █▀█ █░▀█ █▀█ █░▀█ █▀█ █▄▀ █▄█ █▀▄   █▀▀ █▄▄ █▀█ ░█░ ██▄ █▀▄   ░█");


                        Console.WriteLine("Datos del ganador:");
                        selec.ReadOnlyOne(player1);
                        string ArchivoGanadores = "ganadores.json";
                        if (nuevoJson.Existe(ArchivoGanadores))
                        {
                            listaGanadores = persjson.LeerPersonajes(ArchivoGanadores);
                            listaGanadores.Add(player1);
                            persjson.GuardarPersonajes(ArchivoGanadores, listaGanadores);
                        }
                        else
                        {
                            listaGanadores.Add(player1);
                            persjson.GuardarPersonajes(ArchivoGanadores, listaGanadores);
                        }
                    }
                    
                    else if(player1.Salud <=0)
                    {


                                    Console.WriteLine(@"
                        █▀▀ ▄▀█ █▄░█ ▄▀█ █▄░█ ▄▀█ █▀▄ █▀█ █▀█   █▀█ █░░ ▄▀█ █▄█ █▀▀ █▀█   ▀█
                        █▄█ █▀█ █░▀█ █▀█ █░▀█ █▀█ █▄▀ █▄█ █▀▄   █▀▀ █▄▄ █▀█ ░█░ ██▄ █▀▄   █▄");
                        
                        
                        
                        Console.WriteLine("---------Datos del ganador---------");
                        selec.ReadOnlyOne(player2);
                        string ArchivoGanadores = "ganadores.json";
                        if (nuevoJson.Existe(ArchivoGanadores))
                        {
                            listaGanadores = persjson.LeerPersonajes(ArchivoGanadores);
                            listaGanadores.Add(player2);
                            persjson.GuardarPersonajes(ArchivoGanadores, listaGanadores);
                        }
                        else
                        {
                            listaGanadores.Add(player2);
                            persjson.GuardarPersonajes(ArchivoGanadores, listaGanadores);
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                    }
                    MostrarCampeones(listaGanadores);
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