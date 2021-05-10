using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Modul_5_Task_1.Models.DTO;
using Modul_5_Task_1.Services;
using Modul_5_Task_1.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Modul_5_Task_1.Extensions
{
    public static class HttpClientServiceExtensions
    {
        #region get
        public static async Task<Page<IReadOnlyCollection<User>>> GetUserCollectionAsync(this IHttpClientService httpClientService, string request)
        {
            var result = await httpClientService.GetAsync(request);
            if(result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                var page = JsonConvert.DeserializeObject<Page<IReadOnlyCollection<User>>>(content);
                return page;              
            }
            else
            {
                throw new HttpRequestException("Bad StatusCode");
            }
        }
        public static async Task<Page<User>> GetUserAsync(this IHttpClientService httpClientService, string request)
        {
            var result = await httpClientService.GetAsync(request);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                var page = JsonConvert.DeserializeObject<Page<User>>(content);
                return page;
            }
            else
            {
                throw new HttpRequestException("Bad StatusCode");
            }
        }
        public static async Task<Page<Resource>> GetResourceAsync(this IHttpClientService httpClientService, string request)
        {
            var result = await httpClientService.GetAsync(request);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                var page = JsonConvert.DeserializeObject<Page<Resource>>(content);
                return page;
            }
            else
            {
                throw new HttpRequestException("Bad StatusCode");
            }
        }
        public static async Task<Page<IReadOnlyCollection<Resource>>> GetResourceCollectionAsync(this IHttpClientService httpClientService, string request)
        {
            var result = await httpClientService.GetAsync(request);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                var page = JsonConvert.DeserializeObject<Page<IReadOnlyCollection<Resource>>>(content);
                return page;
            }
            else
            {
                throw new HttpRequestException("Bad StatusCode");
            }
        }
        #endregion
        #region POST
        public static async Task<User> CreateUserAsync(this IHttpClientService httpClientService, string uri, User user)
        {
            var serializeUser = JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings 
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var result = await httpClientService.PostAsync(uri,serializeUser);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);
            }
            else
            {
                throw new HttpRequestException("Bad StatusCode");
            }
        }
        public static async Task<User> UserRegistrationAsync(this IHttpClientService httpClientService, string uri, RegistrationInfo registrationInfo)
        {
            var serializeUser = JsonConvert.SerializeObject(registrationInfo, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var result = await httpClientService.PostAsync(uri, serializeUser);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);
            }
            else
            {
                throw new HttpRequestException("Bad StatusCode");
            }
        }
        #endregion
        #region PUT
        public static async Task<User> UpdateUserAsync(this IHttpClientService httpClientService, string uri, User user)
        {
            var serializeUser = JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var result = await httpClientService.PutAsync(uri, serializeUser);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();                
                return JsonConvert.DeserializeObject<User>(content);
            }
            else
            {
                throw new HttpRequestException("Bad StatusCode");
            }
        }
        #endregion
        #region PATCH
        public static async Task<User> Update2UserAsync(this IHttpClientService httpClientService, string uri, User user)
        {
            var serializeUser = JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var result = await httpClientService.PatchAsync(uri, serializeUser);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var content = await result.Content.ReadAsStringAsync();
                var page = JsonConvert.DeserializeObject<User>(content);
                return page;
            }
            else
            {
                throw new HttpRequestException("Bad StatusCode");
            }
        }
        #endregion
        #region DELETE
        public static async Task DeleteUserAsync(this IHttpClientService httpClientService, string request)
        {
            var result = await httpClientService.GetAsync(request);
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException("Bad StatusCode");
            }
        }
        #endregion
    }
}
