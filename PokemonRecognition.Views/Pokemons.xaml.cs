using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonRecognition.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Pokemons : ContentPage
	{
		public Pokemons ()
		{
			InitializeComponent ();
		}
	}
}