using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CycloidServer.Logic
{
    public class Rooms
    {
        public static void AddRoom(string jsonRoom)
        {
            var room = JsonConvert.DeserializeObject<Models.Room>(jsonRoom);
            DataAccess.Room.Add(room);
        }
        public static Models.Room UpdateRoom(string jsonRoom)
        {
            var room = JsonConvert.DeserializeObject<Models.Room>(jsonRoom);
            DataAccess.Room.Update(room);
            return room;
        }
        public static void DeleteRoom(int id)
        {
            DataAccess.Room.Delete(id);
        }

        public static string GetRoom(int id)
        {
            var room = Rooms.GetRoom(id);
            if (room == null) return "not found";
            return JsonConvert.SerializeObject(room);
        }

        public static string GetRoomsByUser(int id)
        {
            var rooms = DataAccess.Room.GetByUser(id);
            return JsonConvert.SerializeObject(rooms);
        }

        public static string GetRoomsByUser(string token)
        {
            int id = DataAccess.Token.GetUserId(token);
            var rooms = DataAccess.Room.GetByUser(id);
            return JsonConvert.SerializeObject(rooms);
        }

        public static void SetMetrics(string data)
        {
            string[] temp = data.Split('|');
            int id = Convert.ToInt32(temp[0]);
            double temperature = Convert.ToDouble(temp[1]);
            double humdity = Convert.ToDouble(temp[2]);
            var room = DataAccess.Room.GetById(id);
            room.Temperature = temperature;
            room.Humidity = humdity;
            DataAccess.Room.Update(room);
        }
    }
}