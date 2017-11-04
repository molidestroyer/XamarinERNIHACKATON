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
        private Microsoft.ProjectOxford.Vision.VisionServiceClient _storage;

        public TextRecognitionService() {
            this._visionClient = new Microsoft.ProjectOxford.Vision.VisionServiceClient(this._subscriptionKey, "https://westeurope.api.cognitive.microsoft.com/vision/v1.0");
        }

        public async Task<string> GetHandwrittenTextFromImage(byte[] picture) {
            var operation = new HandwritingRecognitionOperation();
            operation.Url = "";
            var result = await _visionClient.GetHandwritingRecognitionOperationResultAsync(operation);
            return "Bulbasur";
        }


    }
}
