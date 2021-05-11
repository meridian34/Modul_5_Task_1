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
        public static async Task<R> GenHttpMethodAsync<P, R>(this IHttpClientService httpClientService, string uri, HttpMethod httpMethod, P dto = null)
            where P: class
        {
            
            HttpResponseMessage result;
            
            if(dto is null)
            {
                result = await httpClientService.SendAsync(uri, httpMethod);
            }
            else
            {
                var serializeDTO = SerializeService.Serialize<P>(dto);
                result = await httpClientService.SendAsync(uri, httpMethod, serializeDTO);
            }                
             
            if (result.StatusCode == HttpStatusCode.OK || result.StatusCode == HttpStatusCode.Created)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<R>(content);
            }
            else if(result.StatusCode == HttpStatusCode.NoContent)
            {
                return default(R);
            }
            else
            {
                throw new HttpRequestException("Bad StatusCode");
            }
        }

        #region GET
        public static async Task<T> GetDTOAsync<T>(this IHttpClientService httpClientService, string request)
            where T: class
        {
            return await GenHttpMethodAsync<T, T>(httpClientService, request, HttpMethod.Get);
        }
        public static async Task<Page<IReadOnlyCollection<User>>> GetUserCollectionAsync(this IHttpClientService httpClientService, string request)
        {
            return await GetDTOAsync<Page<IReadOnlyCollection<User>>>(httpClientService, request);            
        }
        public static async Task<Page<User>> GetUserAsync(this IHttpClientService httpClientService, string request)
        {
            return await GetDTOAsync<Page<User>>(httpClientService, request);
        }
        public static async Task<Page<Resource>> GetResourceAsync(this IHttpClientService httpClientService, string request)
        {
            return await GetDTOAsync<Page<Resource>>(httpClientService, request);
        }
        public static async Task<Page<IReadOnlyCollection<Resource>>> GetResourceCollectionAsync(this IHttpClientService httpClientService, string request)
        {
            return await GetDTOAsync<Page<IReadOnlyCollection<Resource>>>(httpClientService, request);
        }
        #endregion
        #region POST
        public static async Task<R> PostDTOAsync<P,R>(this IHttpClientService httpClientService, string uri, P dto)
            where P:class
        {
            return await GenHttpMethodAsync<P,R>(httpClientService, uri, HttpMethod.Post, dto);
        }
        public static async Task<User> CreateUserAsync(this IHttpClientService httpClientService, string uri, User user)
        {
            return await PostDTOAsync<User, User>(httpClientService, uri, user);
        }
        public static async Task<RegisterResponse> UserRegistrationAsync(this IHttpClientService httpClientService, string uri, RegistrationInfo registrationInfo)
        {
            return await PostDTOAsync<RegistrationInfo, RegisterResponse>(httpClientService, uri, registrationInfo);
        }
        public static async Task<RegisterResponse> LoginUserAsync(this IHttpClientService httpClientService, string uri, RegistrationInfo registrationInfo)
        {
            return await PostDTOAsync<RegistrationInfo, RegisterResponse>(httpClientService, uri, registrationInfo);
        }
        #endregion
        #region PUT
        public static async Task<User> UpdateUserAsync(this IHttpClientService httpClientService, string uri, User user)
        {
            return await GenHttpMethodAsync<User, User>(httpClientService, uri, HttpMethod.Put, user);
        }
        #endregion
        #region PATCH
        public static async Task<User> UpdateUserViaPatchAsync(this IHttpClientService httpClientService, string uri, User user)
        {
            return await GenHttpMethodAsync<User, User>(httpClientService, uri, HttpMethod.Patch, user);
        }
        #endregion
        #region DELETE
        public static async Task DeleteUserAsync(this IHttpClientService httpClientService, string request)
        {
            await GenHttpMethodAsync<object, object>(httpClientService, request, HttpMethod.Delete);
        }
        #endregion
    }
}
