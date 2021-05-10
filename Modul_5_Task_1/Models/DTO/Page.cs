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
        public int PageNum { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public User UserData { get; set; }
        public Resource ResourceData { get; set; }
        public Support Support { get; set; }
    }
}
