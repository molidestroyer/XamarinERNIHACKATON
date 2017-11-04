using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PokemonRecognition.Models
{
    public class Pokemons
    {
        public int count { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
        public object next { get; set; }
    }
}
