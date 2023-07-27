using System.Text.Json;
using Personaje;
namespace usaJson
{
     public class PersonajesJson
    {
        public string CrearArchivoJson(List <Perso> ListaDepersonajes)
        {
            return JsonSerializer.Serialize(ListaDepersonajes);
        }

        public void GuardarPersonajes(string nombreArchivo, List <Perso> ListaDepersonajes)
        {
            string persStr = CrearArchivoJson(ListaDepersonajes);
            FileStream MiArchivo = new FileStream(nombreArchivo, FileMode.OpenOrCreate);
            using (StreamWriter StrWriter = new StreamWriter(MiArchivo))
            {
                StrWriter.WriteLine("{0}", persStr);

                StrWriter.Close();
            }
        }

        public List<Perso> LeerPersonajes(string nombreArchivo)
        {
            string json = File.ReadAllText(nombreArchivo);
            var personajes = JsonSerializer.Deserialize<List<Perso>>(json);
            return personajes;
        }

        public bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                return (new FileInfo(nombreArchivo).Length > 0);
            }else
            {
            return false;
            }
        }

        public List<Perso> guardadoGanador(Perso player, List<Perso> listaGanadores)
        {
            string ArchivoGanadores = "ganadores.json";
            if (Existe(ArchivoGanadores))
            {
                listaGanadores=LeerPersonajes(ArchivoGanadores);
                listaGanadores.Add(player);
                GuardarPersonajes(ArchivoGanadores, listaGanadores);
            }
            else
            {
                listaGanadores.Add(player);
                GuardarPersonajes(ArchivoGanadores, listaGanadores);
            }
            return listaGanadores;
        }
        
    }
}