using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Modul_5_Task_1.Services.Interfaces
{
    public interface IHttpClientService
    {
        public Task<HttpResponseMessage> SendAsync(string uri, HttpMethod httpMethod, string httpContentText = null);
        public Task<HttpResponseMessage> GetAsync(string uri);
        public Task<HttpResponseMessage> PostAsync(string uri, string httpContent);
        public Task<HttpResponseMessage> PutAsync(string uri, string httpContent);
        public Task<HttpResponseMessage> PatchAsync(string uri, string httpContent);
        public Task<HttpResponseMessage> DeleteAsync(string uri);
    }
}
