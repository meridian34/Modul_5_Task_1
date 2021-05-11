using System.IO;
using Microsoft.Extensions.Configuration;
using Modul_5_Task_1.Services;
using Modul_5_Task_1.Services.Interfaces;

namespace Modul_5_Task_1.Helpers
{
    public class HttpClientServiceFactory
    {
        public IHttpClientService Get()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("AppConfig.json");
            var config = builder.Build();
            var media = config.GetSection("MediaFormat");
            var encoding = config.GetSection("HttpEncoding");
            return new HttpClientService(media.Value, encoding.Value);
        }
    }
}
