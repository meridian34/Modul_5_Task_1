using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_5_Task_1.Services
{
    class SerializeService
    {
        public static string Serialize<T>(T dto)
        {
            var serializeDTO = JsonConvert.SerializeObject(dto, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            return serializeDTO;
        }
        public static T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
