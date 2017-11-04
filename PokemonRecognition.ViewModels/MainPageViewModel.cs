using PokemonRecognition.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PokemonRecognition.ViewModels
{
    public class MainPageViewModel:BaseViewModel
    {
        private ICommand _clickCameraCommand;
        public ICommand ClickCameraCommand
        {
            get { return _clickCameraCommand = _clickCameraCommand ?? new Command(onClickCameraCommand); }
        }

        public MainPageViewModel()
        {
            Title = "The Pokemon Searcher";

        }

        private async void onClickCameraCommand(object obj)
        {
            var service = new TextRecognitionService();
            var result = await service.GetHandwrittenTextFromImage(Stream.Null);
        }



    }
}
