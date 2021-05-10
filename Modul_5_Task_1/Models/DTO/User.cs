﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_5_Task_1.Models.DTO
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("avatar")]
        public string AvatarLink { get; set; }
        [JsonProperty("job")]
        public string Job { get; set; }
        [JsonProperty("updatedAt")]
        public TimeSpan UpdatedAt { get; set; }
        [JsonProperty("createdAt")]
        public TimeSpan CreatedAt { get; set; }
    }
}
