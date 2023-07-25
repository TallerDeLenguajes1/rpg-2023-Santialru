using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Personaje;
namespace usaJson
{
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
            var personajes = JsonSerializer.Deserialize<List<Perso>>(json);
            return personajes;
        }

        public bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo+".json"))
            {
                return (new FileInfo(nombreArchivo).Length > 0);
            }else
            {
            return false;
            }
        }
        
    }
}