using System;
using System.Threading;
using System.Threading.Tasks;
using Modul_5_Task_1.Services.Interfaces;
using Newtonsoft.Json;

namespace Modul_5_Task_1.Services
{
    public class SerializeService : ISerializeService
    {
        private readonly SemaphoreSlim _slim;
        private static readonly Lazy<SerializeService> _instance;

        static SerializeService()
        {
            _instance = new Lazy<SerializeService>(() => new SerializeService());
        }

        private SerializeService()
        {
            _slim = new SemaphoreSlim(1);
        }

        public static SerializeService Instance
        {
            get { return _instance.Value; }
        }

        public async Task<string> Serialize<T>(T dto)
        {
            await _slim.WaitAsync();
            try
            {
                return JsonConvert.SerializeObject(dto, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            finally
            {
                _slim.Release();
            }
        }

        public async Task<T> Deserialize<T>(string content)
        {
            await _slim.WaitAsync();
            try
            {
                return JsonConvert.DeserializeObject<T>(content);
            }
            finally
            {
                _slim.Release();
            }
        }
    }
}
