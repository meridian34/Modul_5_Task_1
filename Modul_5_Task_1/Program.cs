using System.Threading.Tasks;
using Modul_5_Task_1.Helpers;

namespace Modul_5_Task_1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var s = new Starter();
            await s.Start();
        }
    }
}
