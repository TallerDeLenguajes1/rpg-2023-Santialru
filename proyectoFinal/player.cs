using System;

namespace Personaje
{
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

            pj.Tipo = tip[random.Next(0, 3)];
            pj.Nombre = nomb[random.Next(0, 3)];
            pj.Apodo = apo[random.Next(0, 3)];
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
}