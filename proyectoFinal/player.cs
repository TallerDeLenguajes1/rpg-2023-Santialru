using System;
using System.Text.Json;
using System.Text.Json.Serialization;
// using Newtonsoft.Json;
using System.IO;

namespace Personaje
{
    public enum tipoPersonajes
    {
        Humano,
        Duende, 
        Hobbit, 
        Brujo, 
        Mago,
        Alien
    }
    public enum nombresPersonajes
    {
        Homero, 
        Bart,
        Lisa, 
        Maggie,
        Marge, 
        Flanders, 
        Abuelo, 
        SrBurns,
        Apu
    }
    public enum apodos
    {
        aaaa,
        bbbb,
        cccc,
        dddd,
        eeee,
        ffff

    }
    public class Perso
    {
        public string tipo;
        public string nombre;
        public string apodo;
        public DateTime fecha;
        public int edad;
        public int velocidad;
        public int destreza;
        public int fuerza;
        public int nivel;
        public int armadura;
        public int salud;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }
    }

    public class FabricaDePersonajes
    {
        public Perso CrearPersonaje()
        {
            Random random = new Random();
            Perso pj = new Perso();

            string[] tip = { "uno", "dos", "tres" };
            string[] nomb = { "santi", "aaa", "bbb" };
            string[] apo = { "sss", "vvvv", "uuu" };

            pj.Tipo = Enum.GetName(typeof(tipoPersonajes), random.Next(1, Enum.GetNames(typeof(tipoPersonajes)).Length));
            pj.Nombre = Enum.GetName(typeof(nombresPersonajes), random.Next(1, Enum.GetNames(typeof(nombresPersonajes)).Length));
            pj.Apodo = Enum.GetName(typeof(apodos), random.Next(1, Enum.GetNames(typeof(apodos)).Length));
            int anio = random.Next(1723, 2023);
            int mes = random.Next(1, 12);
            int dia = random.Next(1, 30);
            pj.Fecha = new DateTime(anio, mes, dia);
            pj.Edad = DateTime.Now.Year - pj.Fecha.Year;
            pj.Velocidad = random.Next(1, 10);
            pj.Destreza = random.Next(1, 5);
            pj.Fuerza = random.Next(1, 10);
            pj.Nivel = random.Next(1, 10);
            pj.Armadura = random.Next(1, 10);
            pj.Salud = random.Next(1, 100);

            return pj;
        }
    }

    public class PersonajesJson
    {
        public string CrearArchivoJson(Perso personaje)
        {
            return JsonSerializer.Serialize(personaje);
            
        }

        public void GuardarPersonajes(string nombreArchivo, string formato, Perso personaje)
        {
            string persStr = CrearArchivoJson(personaje);
            FileStream MiArchivo = new FileStream(nombreArchivo + formato, FileMode.Create);
            using (StreamWriter StrWriter = new StreamWriter(MiArchivo))
            {
                StrWriter.WriteLine("{0}", persStr);

                StrWriter.Close();
            }
        }

        public List<Perso> LeerPersonajes(string nombreArchivo)
        {
            string json = File.ReadAllText(nombreArchivo);
            List<Perso> personajes = JsonSerializer.Deserialize<List<Perso>>(nombreArchivo);
            return personajes;
        }

        
        
    }
}
