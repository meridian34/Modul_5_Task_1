using Newtonsoft.Json;

namespace Modul_5_Task_1.Models.DTO
{
    public class Page<T>
    {
        [JsonProperty("page")]
        public int PageNum { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("support")]
        public Support Support { get; set; }
    }
}
