using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRecognition.Models
{
    public class Ability
    {
        public int slot { get; set; }
        public bool is_hidden { get; set; }
        public Ability2 ability { get; set; }
    }
}
