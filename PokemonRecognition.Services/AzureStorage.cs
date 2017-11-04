using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRecognition.Services
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    public static class AzureStorage
    {
        static CloudBlobContainer GetContainer()
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=storagetestcognitive;AccountKey=PpjUl52zALHyVIWbLnIOb66shgzT5A9L3XKq7i6OK/xnaR1UFsBE+a8IDJJZGESCuy+mu2Vo5yyE499azRDytw==;EndpointSuffix=core.windows.net");
            var client = account.CreateCloudBlobClient();
            return client.GetContainerReference("string");
        }

        public static async Task<IList<string>> GetFilesListAsync()
        {
            var container = GetContainer();

            var allBlobsList = new List<string>();
            BlobContinuationToken token = null;

            do
            {
                var result = await container.ListBlobsSegmentedAsync(token);
                if (result.Results.Count() > 0)
                {
                    var blobs = result.Results.Cast<CloudBlockBlob>().Select(b => b.Name);
                    allBlobsList.AddRange(blobs);
                }
                token = result.ContinuationToken;
            } while (token != null);

            return allBlobsList;
        }

        public static async Task<byte[]> GetFileAsync(string name)
        {
            var container = GetContainer();

            var blob = container.GetBlobReference(name);
            if (await blob.ExistsAsync())
            {
                await blob.FetchAttributesAsync();
                byte[] blobBytes = new byte[blob.Properties.Length];

                await blob.DownloadToByteArrayAsync(blobBytes, 0);
                return blobBytes;
            }
            return null;
        }

        public static async Task<string> UploadFileAsync(Stream stream)
        {
            var container = GetContainer();
            await container.CreateIfNotExistsAsync();

            var name = Guid.NewGuid().ToString();
            var fileBlob = container.GetBlockBlobReference(name);
            await fileBlob.UploadFromStreamAsync(stream);

            return name;
        }

        public static async Task<bool> DeleteFileAsync(string name)
        {
            var container = GetContainer();
            var blob = container.GetBlobReference(name);
            return await blob.DeleteIfExistsAsync();
        }

        public static async Task<bool> DeleteContainerAsync()
        {
            var container = GetContainer();
            return await container.DeleteIfExistsAsync();
        }
    }
}
