using Modul_5_Task_1.Helpers;
using Modul_5_Task_1.Services.Interfaces;

namespace Modul_5_Task_1.Services
{
    public class LocatorService
    {
        public static IHttpClientService HttpClientService => new HttpClientServiceFactory().Get();

        public static ISerializeService SerializerService => SerializeService.Instance;
    }
}
