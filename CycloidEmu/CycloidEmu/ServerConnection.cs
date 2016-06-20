using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CycloidEmu
{
    class ServerConnection
    {
        const string serverUrl = "http://localhost:57180/";
        public string Post(string url, List<KeyValuePair<string, string>> postData)
        {
            try
            {
                var client = new HttpClient();
                var content = new FormUrlEncodedContent(postData);
                var response = client.PostAsync(serverUrl + url, content);
                var responseText = response.Result.Content.ReadAsStringAsync().Result;
                return responseText;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
