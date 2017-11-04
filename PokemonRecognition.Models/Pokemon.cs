namespace PokemonRecognition.Models
{
    using System.Collections.Generic;

    public partial class PokemonService
    {
        public class Pokemon
        {
            public List<Form> forms { get; set; }
            public List<Ability> abilities { get; set; }
            public List<Stat> stats { get; set; }
            public string name { get; set; }
            public int weight { get; set; }
            public List<PokemonService.Move> moves { get; set; }
            public PokemonService.Sprites sprites { get; set; }
            public List<object> held_items { get; set; }
            public string location_area_encounters { get; set; }
            public int height { get; set; }
            public bool is_default { get; set; }
            public PokemonService.Species species { get; set; }
            public int id { get; set; }
            public int order { get; set; }
            public List<PokemonService.GameIndice> game_indices { get; set; }
            public int base_experience { get; set; }
            public List<PokemonService.Type> types { get; set; }
        }
    }
}
