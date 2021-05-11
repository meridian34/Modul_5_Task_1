using Newtonsoft.Json;

namespace Modul_5_Task_1.Models.DTO
{
    public class RegisterResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
