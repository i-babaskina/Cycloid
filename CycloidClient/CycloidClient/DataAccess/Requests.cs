using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycloidClient.DataAccess
{
    public class Requests
    {
        static ServerConnection connection = new ServerConnection();

        public static async Task<string> Login(string login, string password)
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("login", login));
            data.Add(new KeyValuePair<string, string>("pass", password));
            string res = await connection.PostAsync("home/login", data);
            return res;
        }
    }
}
