using System.Threading;
using System.Threading.Tasks;
using Modul_5_Task_1.Services.Interfaces;
using Newtonsoft.Json;

namespace Modul_5_Task_1.Services
{
    public class SerializeService : ISerializeService
    {
        private readonly SemaphoreSlim _slim;
        private static readonly Task<SerializeService> _instance;

        static SerializeService()
        {
            _instance = Initialization();
        }

        private SerializeService()
        {
            _slim = new SemaphoreSlim(1);
        }

        public static Task<SerializeService> Instance
        {
            get { return _instance; }
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

        private static async Task<SerializeService> Initialization()
        {
            return await Task.Run(() => new SerializeService());
        }
    }
}
