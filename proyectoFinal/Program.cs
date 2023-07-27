using Personaje;
using usaJson;
using combate;


internal class Program
{
    
    private static void Main(string[] args)
    {
        // Funcion Principal del juego
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
                    var listaGanadores = new List<Perso>();

                    // lectura y/o creacion del archivo json de personajes
                    string nombreArchivo = "personajes.json";
                    if (persjson.Existe(nombreArchivo))
                    {
                        listaPersonajes = persjson.LeerPersonajes(nombreArchivo);
                        selec.MostrarPersonajes(listaPersonajes);
                    }
                    else
                    {
                        for (int i = 1; i < 10; i++)
                        {
                            var nuevoPersonaje = new Perso();
                            var fabrica = new FabricaDePersonajes();
                            nuevoPersonaje = fabrica.CrearPersonaje();
                            listaPersonajes.Add(nuevoPersonaje);
                        }
                        persjson.GuardarPersonajes(nombreArchivo, listaPersonajes);
                        selec.MostrarPersonajes(listaPersonajes);
                        
                    }

                    // menu de ejeccion de personaje para cada jugador
                    EleccionDePj();
                    
                    // turnos de combate 
                    do 
                    {
                        
                        if (player1.Salud > 0 && player2.Salud >0)
                        {
                            pelea.combate(player1, player2);
                        }
                        if (player1.Salud > 0 && player2.Salud >0)
                        {
                            pelea.combate(player2, player1);
                        }
                            
                    }while (player1.Salud > 0 && player2.Salud > 0);
                    
                    // menu ganadores
                    
                    if(player2.Salud <= 0)
                    {
                                    Console.WriteLine(@"
                        █▀▀ ▄▀█ █▄░█ ▄▀█ █▄░█ ▄▀█ █▀▄ █▀█ █▀█   █▀█ █░░ ▄▀█ █▄█ █▀▀ █▀█   ▄█
                        █▄█ █▀█ █░▀█ █▀█ █░▀█ █▀█ █▄▀ █▄█ █▀▄   █▀▀ █▄▄ █▀█ ░█░ ██▄ █▀▄   ░█");


                        Console.WriteLine("---------Datos del ganador---------");
                        selec.ReadOnlyOne(player1);
                        // actualizacion o creacion de json de ganadores
                        listaGanadores = persjson.guardadoGanador(player1, listaGanadores);
                    }
                    
                    else if(player1.Salud <=0)
                    {
                                    Console.WriteLine(@"
                        █▀▀ ▄▀█ █▄░█ ▄▀█ █▄░█ ▄▀█ █▀▄ █▀█ █▀█   █▀█ █░░ ▄▀█ █▄█ █▀▀ █▀█   ▀█
                        █▄█ █▀█ █░▀█ █▀█ █░▀█ █▀█ █▄▀ █▄█ █▀▄   █▀▀ █▄▄ █▀█ ░█░ ██▄ █▀▄   █▄");
            
                        Console.WriteLine("---------Datos del ganador---------");
                        selec.ReadOnlyOne(player2);
                        // actualizacion o creacion de json de ganadores
                        listaGanadores = persjson.guardadoGanador(player2, listaGanadores);
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                    }

                    // menu mostrar ganadores
                    selec.MostrarCampeones(listaGanadores);
                    // menu jugar de nuevo
                    JugarDeNuevoMultiplayer();

                    // funcion de eleccion de personajes
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