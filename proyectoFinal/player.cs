using System;
using System.Text.Json.Serialization;
using System.Net;
using System.Text.Json;

namespace Personaje
{
    public class Result
    {
        [JsonPropertyName("name")]
        public required string Nombre { get; set; }
        public string url { get; set; }
    }

    public class Pokemones
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }

    }


    public enum tipoPersonajes
    {
        Fire,
        Ice, 
        Dragon, 
        Electric, 
        Steel,
        Water
    }
    
    public class Perso
    {
        private string tipo;
        private string nombre;
        // private string apodo;
        private DateTime fecha;
        private int edad;
        public int velocidad;
        public int destreza;
        public int fuerza;
        public int nivel;
        public int armadura;
        public int salud;
        private int saludInicial;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        // public string Apodo { get => apodo; set => apodo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }
        public int SaludInicial { get => saludInicial; set => saludInicial = value; }
    }

    public class FabricaDePersonajes
    {
        public Perso CrearPersonaje()
        {
            Random random = new Random();
            Perso pj = new Perso();
            // Pokemones poke = new Pokemones();
            
            Pokemones Get()
            {
                var url =$"https://pokeapi.co/api/v2/pokemon?limit=50&offset=0";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null){
                                Console.WriteLine("error de lectura stream reader");
                                return null;
                            }
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                
                                Pokemones poke = JsonSerializer.Deserialize<Pokemones>(responseBody);
                                    return poke;
                            }
                        }
                    }
                }
                catch (System.Exception)
                {
                    
                    throw;
                } 
            }

            int z = 0;
            string[] nombresPersonajes = new string[50];
            foreach (Result pokemones in Get().results)
            {
                nombresPersonajes[z] = pokemones.Nombre;
                z++;
            }

            pj.Tipo = Enum.GetName(typeof(tipoPersonajes), random.Next(1, Enum.GetNames(typeof(tipoPersonajes)).Length));
            pj.Nombre = nombresPersonajes[random.Next(0,49)];
            int anio = random.Next(1723, 2023);
            int mes = random.Next(1, 12);
            int dia = random.Next(1, 30);
            pj.Fecha = new DateTime(anio, mes, dia);
            pj.Edad = DateTime.Now.Year - pj.Fecha.Year;
            pj.Nivel = random.Next(1, 10);
            pj.Velocidad = random.Next(1, 10);
            pj.Destreza = random.Next(1, 5);
            pj.Fuerza = random.Next(1, 10);
            pj.Armadura = random.Next(1, 10);
            pj.Salud = random.Next(20, 100);
            pj.SaludInicial = pj.Salud;
            return pj;
        }
    }

    
    public class SeleccionDePersonajes
    {
        public void MostrarPersonajes(List<Perso> ListaDePersonajes)
        {
            int indi = 0;
            foreach (Perso item in ListaDePersonajes)
            {

                Console.WriteLine("\n-------Personaje N°"+ indi +"-------");
                Console.WriteLine("Nombre: " + item.Nombre);
                Console.WriteLine("Tipo: " + item.Tipo);
                Console.WriteLine("Fecha de nacimiento: " + item.Fecha);
                Console.Write("Edad: " + item.Edad);
                Console.Write("\nVelocidad: " + item.Velocidad);
                Console.Write("\nDestreza: " + item.Destreza);
                Console.Write("\nFuerza:" + item.Fuerza);
                Console.Write("\nNivel: " + item.Nivel);
                Console.Write("\nArmadura: " + item.Armadura);
                Console.Write("\nSalud: " + item.Salud);
                indi++;
            }
        }

        public void ReadOnlyOne(Perso pj){
                Console.WriteLine("Nombre: " + pj.Nombre);
                // Console.WriteLine("Apodo: " + item.Apodo);
                Console.WriteLine("Tipo: " + pj.Tipo);
                Console.WriteLine("Fecha de nacimiento: " + pj.Fecha);
                Console.Write("Edad: " + pj.Edad);
                Console.Write("\nVelocidad: " + pj.Velocidad);
                Console.Write("\nDestreza: " + pj.Destreza);
                Console.Write("\nFuerza:" + pj.Fuerza);
                Console.Write("\nNivel: " + pj.Nivel);
                Console.Write("\nArmadura: " + pj.Armadura);
                Console.Write("\nSalud: " + pj.Salud);
        }
        public Perso Eleccion(List<Perso> ListaDePersonajes)
        {
            int seleccionado;
            int.TryParse(Console.ReadLine(), out seleccionado);
            switch (seleccionado)
            {
                case 0:
                    return ListaDePersonajes[0];

                case 1:
                    return ListaDePersonajes[1];

                case 2:
                    return ListaDePersonajes[2];

                case 3:
                    return ListaDePersonajes[3];

                case 4:
                    return ListaDePersonajes[4];

                case 5:
                    return ListaDePersonajes[5];

                case 6:
                    return ListaDePersonajes[6];

                case 7:
                    return ListaDePersonajes[7];

                case 8:
                    return ListaDePersonajes[8];

                case 9:
                    return ListaDePersonajes[9];

                default:
                    Console.WriteLine("No se ha seleccionado un personaje valido, intentelo nuevamente");
                    return Eleccion(ListaDePersonajes);
            }
        }
    }

   
}
