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
    public class PokemonsViewModel : BaseViewModel
    {
        ObservableCollection<Pokemons> _items = new ObservableCollection<Pokemons>();
        
        public ObservableCollection<Pokemons> Items
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
    }
}
