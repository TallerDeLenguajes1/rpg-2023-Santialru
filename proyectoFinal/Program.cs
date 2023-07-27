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
        void MostrarCampeones(List<Perso> ListaCampeones, int mostCamp)
        {
            var selec = new SeleccionDePersonajes();
            selec.MostrarPersonajes(ListaCampeones);
             
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

                    var listaPersonajes = new List<Perso>();
                    var persjson = new PersonajesJson();
                    var selec = new SeleccionDePersonajes();
                    var player1 = new Perso();
                    var player2 = new Perso();
                    var pelea = new caractPelea();
                    string nombreArchivo = "personajes.json";

                    if (persjson.Existe(nombreArchivo))
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


                    void EleccionDePj()
                    {
                                Console.WriteLine(@"
                        █▀▀ █░░ █ ░░█ ▄▀█   █▀█ █░░ ▄▀█ █▄█ █▀▀ █▀█   ▄█
                        ██▄ █▄▄ █ █▄█ █▀█   █▀▀ █▄▄ █▀█ ░█░ ██▄ █▀▄   ░█ ");
                                player1 = selec.Eleccion(listaPersonajes);
                                Console.WriteLine(@"
                        █▀▀ █░░ █ ░░█ ▄▀█   █▀█ █░░ ▄▀█ █▄█ █▀▀ █▀█   ▀█
                        ██▄ █▄▄ █ █▄█ █▀█   █▀▀ █▄▄ █▀█ ░█░ ██▄ █▀▄   █▄");
                                player2 = selec.Eleccion(listaPersonajes);

                        if (player1 == player2)
                        {
                            Console.WriteLine("¡¡¡ERROR!!!-Intentelo nuevamente...");
                            EleccionDePj();
                        }
                    }
                    EleccionDePj();
                    
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
                        if (persjson.Existe(ArchivoGanadores))
                        {
                            listaGanadores.Add(player1);
                            persjson.GuardarPersonajes(ArchivoGanadores, listaGanadores);
                            listaGanadores = persjson.LeerPersonajes(ArchivoGanadores);
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
                        if (persjson.Existe(ArchivoGanadores))
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


                    Console.WriteLine("\nMostrar Lista de Campeones Pokemon (1:si / 2:no)");
                    int mostCamp;
                    int.TryParse(Console.ReadLine(), out mostCamp);
                    
                    if (mostCamp == 1)
                    {
                         MostrarCampeones(listaGanadores, mostCamp);
                    }
                    else if (mostCamp != 1 && mostCamp != 2)
                    {
                        Console.WriteLine("No se ha seleccionado una opcion valida, intentelo nuevamente");
                        int.TryParse(Console.ReadLine(), out mostCamp);
                        MostrarCampeones(listaGanadores, mostCamp);
                    }
                    JugarDeNuevoMultiplayer();

        }
        void JugarDeNuevoMultiplayer()
        {
            Console.WriteLine("\nJUGAR DE NUEVO? (1:SI / 2:NO)");
            int deNuevo;
            int.TryParse(Console.ReadLine(), out deNuevo);
            if (deNuevo == 1)
            {
                JugarMultiplayer();
            }else if (deNuevo == 2)
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
    }
}