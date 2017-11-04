using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonRecognition.ViewModels;
using Xamarin.Forms;

namespace PokemonRecognition.Views
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel ViewModel
        {
            get { return BindingContext as MainPageViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

    }
}
