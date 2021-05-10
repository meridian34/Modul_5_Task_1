using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Modul_5_Task_1.Models.DTO
{
    public class Page
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
        public User UserData { get; set; }
        [JsonProperty("data")]
        public Resource ResourceData { get; set; }
        [JsonProperty("support")]
        public Support Support { get; set; }
    }
}
