using PokemonRecognition.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Media;
using PokeAPI;
using PokemonRecognition.Services.PokeAPI;
using Xamarin.Forms;

namespace PokemonRecognition.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ICommand _clickCameraCommand;
        private Image _image;
        private string _nameRecognized;

        public Image CameraImage
        {
            get { return _image; }
        }

        public string NameRecognized
        {
            get { return _nameRecognized; }
            set
            {
                _nameRecognized = value;
                OnPropertyChanged("NameRecognized");
            }

        }

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
            var pokemonService = new PokemonService();
            var result = await pokemonService.GetPokemon("365");
            // PokemonSpecies p = DataFetcher.GetNamedApiObject<PokemonSpecies>("lucario").Result;
            PokemonSpecies p = DataFetcher.GetApiObject<PokemonSpecies>(395).Result;

           

        //var imageData = await TakePicture();
        //    var service = new TextRecognitionService();
            
        //    var result = await service.GetHandwrittenTextFromImage(imageData);
            var imageData = await TakePicture();
            var service = new TextRecognitionService();

            var result = await service.GetHandwrittenTextFromImage(imageData);
            this.NameRecognized = result;
        }


        private async Task<Stream> TakePicture()
        {

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                //DisplayAlert("No Camera", ":( No camera available.", "OK");
                return null;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return null;

            // await DisplayAlert("File Location", file.Path, "OK");
            return file.GetStream();
        }


    }
}
