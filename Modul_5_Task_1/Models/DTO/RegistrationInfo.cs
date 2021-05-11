using Newtonsoft.Json;

namespace Modul_5_Task_1.Models.DTO
{
    public class RegistrationInfo
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
