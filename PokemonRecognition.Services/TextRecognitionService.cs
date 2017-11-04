using Azure.Storage;
using Microsoft.ProjectOxford.Vision.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRecognition.Services
{
    public class TextRecognitionService
    {
        private Microsoft.ProjectOxford.Vision.VisionServiceClient _visionClient;
        private string _subscriptionKey = "ad8f11a55e6d45d5a2cd5b9f04a4f696";
        private BlobStorageAsync bs;

        public TextRecognitionService() {
            this._visionClient = new Microsoft.ProjectOxford.Vision.VisionServiceClient(this._subscriptionKey, "https://westeurope.api.cognitive.microsoft.com/vision/v1.0");
            this.bs = new BlobStorageAsync("XamarinHackaton", "DefaultEndpointsProtocol=https;AccountName=storagetestcognitive;AccountKey=PpjUl52zALHyVIWbLnIOb66shgzT5A9L3XKq7i6OK/xnaR1UFsBE+a8IDJJZGESCuy+mu2Vo5yyE499azRDytw==;EndpointSuffix=core.windows.net");
        }

        public async Task<string> GetHandwrittenTextFromImage(byte[] picture) {
            var imageUrl = await bs.CreateBlockBlobAsync(Guid.NewGuid().ToString(), "image/jpg", picture);
            var operation = new HandwritingRecognitionOperation();
            operation.Url = imageUrl;
            var result = await _visionClient.GetHandwritingRecognitionOperationResultAsync(operation);
            return result.RecognitionResult.ToString();
        }


    }
}
