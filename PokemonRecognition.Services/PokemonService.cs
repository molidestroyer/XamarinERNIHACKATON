using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using PokemonRecognition.Models;

namespace PokemonRecognition.Services
{
    public class PokemonService
    {
        private string apiUrl = "https://pokeapi.co/api/v2/";
        public async Task<Pokemon> GetPokemon(string pokemonItem)
        {
            string url = $"{apiUrl}pokemon/{pokemonItem.ToLowerInvariant()}/";
            return await GetItems<Pokemon>(url);
        }

        public async Task<Pokemons> GetAll()
        {
            string url = $"{apiUrl}pokemon/?limit=1000";
            return await GetItems<Pokemons>(url);
        }

        public static async Task<T> GetItems<T>(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var json = await client.GetStringAsync(url);

                    if (string.IsNullOrWhiteSpace(json))
                        return default(T);
                    //return json;
                    var pokemonEntity = JsonConvert.DeserializeObject<T>(json);
                    return pokemonEntity;
                }
                catch (System.Exception ex)
                {
                }
            }
            return default(T);
        }
    }
}
