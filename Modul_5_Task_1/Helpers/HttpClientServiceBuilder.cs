using Microsoft.Extensions.Configuration;
using Modul_5_Task_1.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_5_Task_1.Helpers
{
    class HttpClientServiceBuilder
    {
        public HttpClientService Get()
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
