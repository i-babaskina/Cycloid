using CycloidClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CycloidClient.DataAccess
{
    public class Requests
    {
        static ServerConnection connection = new ServerConnection();
        static ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public static async Task<string> Login(string login, string password)
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("login", login));
            data.Add(new KeyValuePair<string, string>("pass", password));
            string res = await connection.PostAsync("home/login", data);
            return res;
        }

        internal static async Task<ObservableCollection<Room>> LoadRooms()
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("result", localSettings.Values["token"].ToString()));
            string res = await connection.PostAsync("home/rooms", data);
            ObservableCollection<Room> rooms = JsonConvert.DeserializeObject<ObservableCollection<Room>>(res);
            return rooms;
        }

        internal static async Task UpdateDevice(Device device)
        {
            string json = JsonConvert.SerializeObject(device);
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("result", json));
            await connection.PostAsync("home/updatedevice", data);
        }

        internal static async Task<Room> GetRoom(int id)
        {
            List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
            data.Add(new KeyValuePair<string, string>("result", id.ToString()));
            string res = await connection.PostAsync("home/getroom", data);
            Room room = JsonConvert.DeserializeObject<Room>(res);
            return room;
        }
    }
}
