using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_5_Task_1.Services.Interfaces
{
    public interface ISerializeService
    {
        Task<string> Serialize<T>(T dto);

        Task<T> Deserialize<T>(string content);
    }
}
