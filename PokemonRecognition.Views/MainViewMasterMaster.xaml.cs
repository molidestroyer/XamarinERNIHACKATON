using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokemonRecognition.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainViewMasterMaster : ContentPage
    {
        public ListView ListView;

        public MainViewMasterMaster()
        {
            InitializeComponent();

            BindingContext = new MainViewMasterMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainViewMasterMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainViewMasterMenuItem> MenuItems { get; set; }

            public MainViewMasterMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainViewMasterMenuItem>(new[]
                {
                    new MainViewMasterMenuItem { Id = 0, Title = "Capture & Recognize Text", TargetType = typeof(MainPage) },
                    new MainViewMasterMenuItem { Id = 1, Title = "All Pokemons", TargetType = typeof(Pokemons) }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}