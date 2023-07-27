using Personaje;
namespace combate
{
    public class caractPelea
    {
        private int ataque;
        private int efectividad;
        private int defensa;
        private int danioProvocado;
        

        public int Ataque { get => ataque; set => ataque = value; }
        public int Efectividad { get => efectividad; set => efectividad = value; }
        public int Defensa { get => defensa; set => defensa = value; }
        public int DanioProvocado { get => danioProvocado; set => danioProvocado = value; }
        

       

        public void combate(Perso p1, Perso p2)
        {
            var random = new Random();
        
            Ataque = p1.Destreza * p1.Fuerza * p1.Nivel*2;
            Efectividad = random.Next(1,100);
            Defensa = p2.Armadura * p2.Velocidad;
            DanioProvocado = (((Ataque * Efectividad)-Defensa)/500);
            Console.WriteLine("Elija el sieguiente movimiento");
            Console.WriteLine("\"A\": Atacar");
            Console.WriteLine("\"C\": Curarse");
            Console.WriteLine("\"R\": Rendirse");
            char movi = char.Parse(Console.ReadLine());

            switch (movi)
            {
                case 'A' or 'a':
                p2.Salud -= DanioProvocado;
                Console.WriteLine(p1.Nombre+" ha ATACADO");
                Console.WriteLine("DAÑO PROVOCADO:"+DanioProvocado);
                break;

                case 'C' or 'c':
                Console.WriteLine(p1.Nombre+"Se ha CURADO");
                if (p1.Salud + p1.Destreza*random.Next(1,5) > p1.SaludInicial) 
                {
                    p1.Salud = p1.SaludInicial;
                    Console.WriteLine("SALUD RECUPERADA AL MAXIMO");
                }
                else
                {
                    int recu = p1.Destreza*random.Next(1,5);
                    Console.WriteLine("SALUD RECUPERADA:"+recu);
                    p1.Salud += recu;

                }
                Console.WriteLine("SALUD++: "+p1.Salud);
                break;

                case 'R' or 'r':
                Console.WriteLine(p1.Nombre+" Se ha RENDIDO");
                p1.Salud = 0;
                break;
                default:
                Console.WriteLine("(ERROR!!!) No ha seleccionado una opcion valida");
                combate(p1,p2);
                break;
            }
            
        }

    
    }
}