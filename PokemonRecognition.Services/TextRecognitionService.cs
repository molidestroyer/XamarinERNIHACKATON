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
        private Microsoft.ProjectOxford.EntityLinking.EntityLinkingServiceClient _entityLinkClient;

        private string _subscriptionKey = "ad8f11a55e6d45d5a2cd5b9f04a4f696";
        //private BlobStorageAsync bs;

        public TextRecognitionService() {
            this._entityLinkClient = new Microsoft.ProjectOxford.EntityLinking.EntityLinkingServiceClient("8ac77dcbac034f239d735088bc51c51c", "https://westus.api.cognitive.microsoft.com/entitylinking/v1.0");
            this._visionClient = new Microsoft.ProjectOxford.Vision.VisionServiceClient(this._subscriptionKey, "https://westeurope.api.cognitive.microsoft.com/vision/v1.0");
            //this.bs = new BlobStorageAsync("XamarinHackaton", "DefaultEndpointsProtocol=https;AccountName=storagetestcognitive;AccountKey=PpjUl52zALHyVIWbLnIOb66shgzT5A9L3XKq7i6OK/xnaR1UFsBE+a8IDJJZGESCuy+mu2Vo5yyE499azRDytw==;EndpointSuffix=core.windows.net");
        }

        public async Task<string> GetHandwrittenTextFromImage(Stream picture) {
            try
            {
                var result = await _visionClient.RecognizeTextAsync(picture, "en");
                //return result.Regions[0].Lines.();
                if(result.Regions.Length > 0)
                        if(result.Regions[0].Lines.Length > 0)
                            if (result.Regions[0].Lines[0].Words.Length > 0)
                                return result.Regions[0].Lines[0].Words[0].Text;

            }
            catch (System.Exception ex)
            {
                
            }
            return "ERROR REcognizing";
        }

        public async Task<string> GetEntityLink(string text)
        {
            try
            {
                var result = await _entityLinkClient.LinkAsync(text);
                return result.Rank.ToString(); ;

            }
            catch (System.Exception ex)
            {

            }
            return "ERROR REcognizing link";
        }

        private async Task<Stream> GetStreamFromUrl(string url)
        {
            Stream imageData;

            using (var wc = new System.Net.Http.HttpClient())
                imageData = await wc.GetStreamAsync(url);

            return imageData;
        }

    }
}
