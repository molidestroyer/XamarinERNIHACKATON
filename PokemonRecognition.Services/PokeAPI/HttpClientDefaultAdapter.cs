using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokeAPI
{
    public class HttpClientDefaultAdapter : IHttpClientAdapter
    {
        readonly HttpClient client = new HttpClient();

        public HttpClientDefaultAdapter()
        {
            client.DefaultRequestHeaders.UserAgent.ParseAdd("PokeAPI.NET (https://gitlab.com/PoroCYon/PokeApi.NET or a fork of it)");
        }

        public Task<Stream> GetStreamAsync(Uri requestUri) => client.GetStreamAsync(requestUri);
        public Task<string> GetStringAsync(string requestUri) => client.GetStringAsync(requestUri);
    }
}
