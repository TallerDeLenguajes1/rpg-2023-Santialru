using System.Text.Json.Serialization;
using System.Net;
using System.Text.Json;

namespace apis{
    string nombrePokemon;
    Pokemones Get(){
            var url =$"https://pokeapi.co/api/v2/pokemon/name?={nombrePokemon}";
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

                            foreach (Result pokemones in poke.results)
                            {
                                Console.WriteLine("name:"+pokemones.Nombre);
                            }
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
}