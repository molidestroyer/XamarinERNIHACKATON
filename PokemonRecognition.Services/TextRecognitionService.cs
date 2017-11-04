using Microsoft.ProjectOxford.Vision.Contract;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.Net.Http;

namespace PokemonRecognition.Services
{
    public class TextRecognitionService
    {
        private Microsoft.ProjectOxford.Vision.VisionServiceClient _visionClient;
        private string _subscriptionKey = "ad8f11a55e6d45d5a2cd5b9f04a4f696";
        //private BlobStorageAsync bs;

        public TextRecognitionService() {
            this._visionClient = new Microsoft.ProjectOxford.Vision.VisionServiceClient(this._subscriptionKey, "https://westeurope.api.cognitive.microsoft.com/vision/v1.0");
            //this.bs = new BlobStorageAsync("XamarinHackaton", "DefaultEndpointsProtocol=https;AccountName=storagetestcognitive;AccountKey=PpjUl52zALHyVIWbLnIOb66shgzT5A9L3XKq7i6OK/xnaR1UFsBE+a8IDJJZGESCuy+mu2Vo5yyE499azRDytw==;EndpointSuffix=core.windows.net");
        }

        public async Task<string> GetHandwrittenTextFromImage(Stream picture) {
            // TODO Uncomment var imageUrl = await AzureStorage.UploadFileAsync(picture);

            var image = this.GetStreamFromUrl("https://www.nayuki.io/res/overwriting-confidential-handwritten-text/overwriting-handwriting.jpg");
            var result = await _visionClient.RecognizeTextAsync(image);
            return result.ToString();
        }

        private Stream GetStreamFromUrl(string url)
        {
            Stream imageData;

            using (var wc = new System.Net.Http.HttpClient())
                imageData = wc.GetStreamAsync(url).Result;

            return imageData;
        }

    }
}
