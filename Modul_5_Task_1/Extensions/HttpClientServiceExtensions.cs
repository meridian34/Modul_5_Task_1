using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Modul_5_Task_1.Models.DTO;
using Modul_5_Task_1.Services;
using Modul_5_Task_1.Services.Interfaces;

namespace Modul_5_Task_1.Extensions
{
    public static class HttpClientServiceExtensions
    {
        public static async Task<TResult> GenHttpMethodAsync<TParam, TResult>(this IHttpClientService httpClientService, string uri, HttpMethod httpMethod, TParam dto = null)
            where TParam : class
        {
            HttpResponseMessage result;
            var serializer = LocatorService.SerializerService;

            if (dto is null)
            {
                result = await httpClientService.SendAsync(uri, httpMethod);
            }
            else
            {
                var serializeDTO = await serializer.Serialize<TParam>(dto);
                result = await httpClientService.SendAsync(uri, httpMethod, serializeDTO);
            }

            if (result.StatusCode == HttpStatusCode.OK || result.StatusCode == HttpStatusCode.Created)
            {
                var content = await result.Content.ReadAsStringAsync();
                return await serializer.Deserialize<TResult>(content);
            }
            else if (result.StatusCode == HttpStatusCode.NoContent)
            {
                return default(TResult);
            }
            else
            {
                throw new HttpRequestException("Bad StatusCode");
            }
        }

        public static async Task<T> GetDTOAsync<T>(this IHttpClientService httpClientService, string request)
            where T : class
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

        public static async Task<TResult> PostDTOAsync<TParam, TResult>(this IHttpClientService httpClientService, string uri, TParam dto)
            where TParam : class
        {
            return await GenHttpMethodAsync<TParam, TResult>(httpClientService, uri, HttpMethod.Post, dto);
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

        public static async Task<User> UpdateUserAsync(this IHttpClientService httpClientService, string uri, User user)
        {
            return await GenHttpMethodAsync<User, User>(httpClientService, uri, HttpMethod.Put, user);
        }

        public static async Task<User> UpdateUserViaPatchAsync(this IHttpClientService httpClientService, string uri, User user)
        {
            return await GenHttpMethodAsync<User, User>(httpClientService, uri, HttpMethod.Patch, user);
        }

        public static async Task DeleteUserAsync(this IHttpClientService httpClientService, string request)
        {
            await GenHttpMethodAsync<object, object>(httpClientService, request, HttpMethod.Delete);
        }
    }
}
