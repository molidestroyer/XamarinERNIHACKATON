namespace PokemonRecognition.Models
{
    public class VersionGroupDetail
    {
        public MoveLearnMethod move_learn_method { get; set; }
        public int level_learned_at { get; set; }
        public VersionGroup version_group { get; set; }
    }
}
