using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Modul_5_Task_1.Services.Interfaces;

namespace Modul_5_Task_1.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly string _mediaFormat;
        private readonly Encoding _httpEncoding;

        public HttpClientService(string mediaFormat, string httpEncoding)
        {
            _mediaFormat = mediaFormat;
            _httpEncoding = Encoding.GetEncoding(httpEncoding);
        }

        public async Task<HttpResponseMessage> SendAsync(string request, HttpMethod httpMethod, string serializedСontent = null)
        {
            var httpMessage = new HttpRequestMessage();
            httpMessage.RequestUri = new Uri(request);
            httpMessage.Method = httpMethod;
            if (serializedСontent != null)
            {
                var httpContent = new StringContent(serializedСontent, _httpEncoding, _mediaFormat);
                httpMessage.Content = httpContent;
            }

            using (var httpClient = new HttpClient())
            {
                return await httpClient.SendAsync(httpMessage);
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string request)
        {
            return await SendAsync(request, HttpMethod.Get);
        }

        public async Task<HttpResponseMessage> PostAsync(string request, string serializedСontent)
        {
            return await SendAsync(request, HttpMethod.Post, serializedСontent);
        }

        public async Task<HttpResponseMessage> PutAsync(string request, string serializedСontent)
        {
            return await SendAsync(request, HttpMethod.Put, serializedСontent);
        }

        public async Task<HttpResponseMessage> PatchAsync(string request, string serializedСontent)
        {
            return await SendAsync(request, HttpMethod.Patch, serializedСontent);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string request)
        {
            return await SendAsync(request, HttpMethod.Delete);
        }
    }
}
