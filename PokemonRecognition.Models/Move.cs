using System.Collections.Generic;

namespace PokemonRecognition.Models
{
    public partial class PokemonService
    {
        public class Move
        {
            public List<VersionGroupDetail> version_group_details { get; set; }
            public Move2 move { get; set; }
        }
    }
}
