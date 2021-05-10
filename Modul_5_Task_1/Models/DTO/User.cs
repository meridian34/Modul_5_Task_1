using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_5_Task_1.Models.DTO
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarLink { get; set; }
        public string Job { get; set; }
        public TimeSpan UpdatedAt { get; set; }
        public TimeSpan CreatedAt { get; set; }
    }
}
