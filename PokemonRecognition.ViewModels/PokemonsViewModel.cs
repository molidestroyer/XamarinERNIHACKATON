using PokemonRecognition.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokemonRecognition.ViewModels
{
    using System.Runtime.CompilerServices;

    using PokemonRecognition.Services;

    using Xamarin.Forms;

    public class PokemonsViewModel : BaseViewModel
    {
        public string Logo
        {
            get { return "https://www.pixelslogodesign.com/blog/wp-content/uploads/2016/07/post-pic-1.gif"; }
        }

        Pokemons _items = new Pokemons();

        public Pokemons Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public Command RefreshCommand { get; private set; }

        public PokemonsViewModel()
        {
            this.RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
            this.RefreshCommand.Execute(null);
        }

        private async Task ExecuteRefreshCommand()
        {
            IsBusy = true;
            var pokemonService = new PokemonService();
            var pokemons = await pokemonService.GetAll();

            this.Items = pokemons;
            IsBusy = false;
        }
    }
}
