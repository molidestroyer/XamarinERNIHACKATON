using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PokemonRecognition.Services
{
    public class PokemonRecognition.Services : ContentPage
	{
		public PokemonRecognition.Services()
		{
			var button = new Button
            {
                Text = "Click Me!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

    int clicked = 0;
    button.Clicked += (s, e) => button.Text = "Clicked: " + clicked++;

			Content = button;
		}
	}
}
