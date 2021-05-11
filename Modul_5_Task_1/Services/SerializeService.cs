using Modul_5_Task_1.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Modul_5_Task_1.Services
{
    class SerializeService : ISerializeService
    {
        private readonly SemaphoreSlim _slim;
        private static readonly Task<SerializeService> _instance;
        public static Task<SerializeService> Instance { get { return _instance; } }
        static SerializeService()
        {
            _instance = Init();
        }
        private SerializeService()
        {
            _slim = new SemaphoreSlim(1);
        }
        public async Task<string> Serialize<T>(T dto)
        {
            await _slim.WaitAsync();            
            try
            {
                var t = new Task<string>(() =>
                {
                    return JsonConvert.SerializeObject(dto, Formatting.Indented, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                });
                return await t;
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
                var t = new Task<T>(() =>
                {
                    return JsonConvert.DeserializeObject<T>(content);
                });
                return await t;
            }
            finally
            {
                _slim.Release();
            }           
        }
        private static async Task<SerializeService> Init()
        {
            return await Task.Run(() => new SerializeService());
        }
    }
}
