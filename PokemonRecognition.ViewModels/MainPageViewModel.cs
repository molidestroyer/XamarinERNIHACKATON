using Plugin.Media;
using PokemonRecognition.Services;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using PokemonRecognition.Models;
using Xamarin.Forms;

namespace PokemonRecognition.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ICommand _clickCameraCommand;
        private Image _image;
        private string _nameRecognized;
        private bool _showResult = false;
        private Pokemon _pokemon = new Pokemon();

        public bool ShowResult
        {
            get { return _showResult; }
            set
            {
                _showResult = value;
                OnPropertyChanged("ShowResult");
            }
        }

        public Pokemon PokemonItem
        {
            get { return _pokemon; }
            set
            {
                _pokemon = value;
                OnPropertyChanged("PokemonItem");
            }
        }

        public string Logo
        {
            get { return "https://www.pixelslogodesign.com/blog/wp-content/uploads/2016/07/post-pic-1.gif"; }
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
            ShowResult = false;
            var pokemonService = new PokemonService();
            var service = new TextRecognitionService();
            var imageData = await TakePicture();

            var handWritingResult = await service.GetHandwrittenTextFromImage(imageData);
            this.NameRecognized = handWritingResult;
            if (NameRecognized != "ERROR Recognizing")
            {
                //var result = await pokemonService.GetPokemon(NameRecognized);
                var result = await pokemonService.GetPokemon(NameRecognized);
                if (result != null)
                {
                    PokemonItem = result;
                    ShowResult = true;
                    var wikiURL = await service.GetEntityLink(this.NameRecognized);
                    DependencyService.Get<ITextToSpeech>().Speak(PokemonItem.name);
                }
            }

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
