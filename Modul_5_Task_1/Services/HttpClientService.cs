using Microsoft.Extensions.Configuration;
using Modul_5_Task_1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Modul_5_Task_1.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly string _mediaFormat;
        private readonly Encoding _httpEncoding;
        public HttpClientService(string mediaFormat, Encoding httpEncoding)
        {
            _mediaFormat = mediaFormat;
            _httpEncoding = httpEncoding;
        }
        public HttpClientService(string mediaFormat, string httpEncoding)
        {   
            _mediaFormat = mediaFormat;
            _httpEncoding = Encoding.GetEncoding(httpEncoding);
        }
        public async Task<HttpResponseMessage> SendAsync(string uri, HttpMethod httpMethod, string httpContentText = null)
        {
            var httpMessage = new HttpRequestMessage();
            httpMessage.RequestUri = new Uri(uri);
            httpMessage.Method = httpMethod;
            if (httpContentText != null)
            {
                var httpContent = new StringContent(httpContentText, _httpEncoding, _mediaFormat);
                httpMessage.Content = httpContent;
            }
            using(var httpClient = new HttpClient())
            {
                return await httpClient.SendAsync(httpMessage);
            }            
        }
       
        public async Task<HttpResponseMessage> GetAsync(string uri)
        {
            return await SendAsync(uri, HttpMethod.Get);
        }
        public async Task<HttpResponseMessage> PostAsync(string uri, string httpContent)
        {
            return await SendAsync(uri, HttpMethod.Post, httpContent);
        }
        public async Task<HttpResponseMessage> PutAsync(string uri, string httpContent)
        {
            return await SendAsync(uri, HttpMethod.Put, httpContent);
        }
        public async Task<HttpResponseMessage> PatchAsync(string uri, string httpContent)
        {
            return await SendAsync(uri, HttpMethod.Patch, httpContent);
        }
        public async Task<HttpResponseMessage> DeleteAsync(string uri)
        {
            return await SendAsync(uri, HttpMethod.Delete);
        }
    }
}
