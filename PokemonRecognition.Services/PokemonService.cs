using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokeAPI;

namespace PokemonRecognition.Services
{
    using PokemonRecognition.Models;

    public partial class PokemonService
    {
        private string apiUrl = "https://pokeapi.co/api/v2/";
        public async Task<Models.PokemonService.Pokemon> GetPokemon(string pokemon)
        {
            string url = $"{apiUrl}pokemon/{pokemon}/";
            return await GetItems<Models.PokemonService.Pokemon>(url);
        }

        public async Task<Pokemons> GetAll()
        {
            string url = $"{apiUrl}pokemon/pokemon/?limit=1000";
            return await GetItems<Pokemons>(url);
        }

        private async Task<T> GetItems<T>(string url)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);

                if (string.IsNullOrWhiteSpace(json))
                    return default(T);
                //return json;
                var pokemonEntity = JsonConvert.DeserializeObject<T>(json);
                return pokemonEntity;
            }
        }
    }
}
