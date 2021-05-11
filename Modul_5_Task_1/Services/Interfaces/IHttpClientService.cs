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
        public Task<HttpResponseMessage> SendAsync(string request, HttpMethod httpMethod, string serializedСontent = null);

        public Task<HttpResponseMessage> GetAsync(string request);

        public Task<HttpResponseMessage> PostAsync(string request, string serializedСontent);

        public Task<HttpResponseMessage> PutAsync(string request, string serializedСontent);

        public Task<HttpResponseMessage> PatchAsync(string request, string serializedСontent);

        public Task<HttpResponseMessage> DeleteAsync(string request);
    }
}
