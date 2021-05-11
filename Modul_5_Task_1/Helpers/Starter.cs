using System;
using System.Threading.Tasks;
using Modul_5_Task_1.Extensions;
using Modul_5_Task_1.Models.DTO;

namespace Modul_5_Task_1.Helpers
{
    public class Starter
    {
        public async Task Start()
        {
            try
            {
                var client = new HttpClientServiceFactory().Get();
                var t1 = client.GetUserAsync(@"https://reqres.in/api/users/2");
                var t2 = client.GetUserCollectionAsync(@"https://reqres.in/api/users?page=2");
                var t3 = client.GetUserAsync(@"https://reqres.in/api/users/23");
                var t4 = client.GetResourceCollectionAsync(@"https://reqres.in/api/unknown");
                var t5 = client.GetResourceAsync(@"https://reqres.in/api/unknown/2");
                var t6 = client.GetResourceAsync(@"https://reqres.in/api/unknown/23");
                var t7 = client.CreateUserAsync(@"https://reqres.in/api/users", new User() { FirstName = "morpheus", Job = "leader" });
                var t8 = client.UpdateUserAsync(@"https://reqres.in/api/users/2", new User() { FirstName = "morpheus", Job = "zion resident" });
                var t9 = client.UpdateUserViaPatchAsync(@"https://reqres.in/api/users/2", new User() { FirstName = "morpheus", Job = "zion resident" });
                var t10 = client.DeleteUserAsync(@"https://reqres.in/api/users/2");
                var t11 = client.UserRegistrationAsync(@"https://reqres.in/api/register", new RegistrationInfo() { Email = "eve.holt@reqres.in", Password = "pistol" });
                var t12 = client.UserRegistrationAsync(@"https://reqres.in/api/register", new RegistrationInfo() { Email = "sydney@fife" });
                var t13 = client.LoginUserAsync(@"https://reqres.in/api/login", new RegistrationInfo() { Email = "eve.holt@reqres.in", Password = "cityslicka" });
                var t14 = client.LoginUserAsync(@"https://reqres.in/api/register", new RegistrationInfo() { Email = "peter@klaven" });
                var t15 = client.GetUserCollectionAsync(@"https://reqres.in/api/users?delay=3");
                await Task.WhenAll(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t15);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
