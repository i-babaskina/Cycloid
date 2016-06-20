using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace CycloidEmu
{
    class Program
    {
        static Timer timer;
        static ServerConnection connection = new ServerConnection();
        static void Main(string[] args)
        {

            timer = new Timer(3000);
            timer.Elapsed += TimerOnElapsed;
            timer.Start();
            Console.ReadKey();
        }

        private static void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Random rnd = new Random();
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("id", "1"));
            data.Add(new KeyValuePair<string, string>("temperature", rnd.Next(-15, 40).ToString()));
            data.Add(new KeyValuePair<string, string>("humidity", rnd.Next(0, 100).ToString()));
            string res = connection.Post("home/emu", data);
            Console.WriteLine("Send data:");
            foreach(var a in data)
            {
                Console.WriteLine(a.Key + " - " + a.Value);
            }
            Console.WriteLine("--------------------");
            Console.WriteLine("Recived data:");
            Console.WriteLine(res=="true"?"Device - ON":"Device  - OFF");
            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine();
        }


    }
}
