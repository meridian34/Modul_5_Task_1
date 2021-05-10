using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_5_Task_1.Models.DTO
{
    public class Support
    {
        [JsonProperty("url")]
        public string URL { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
