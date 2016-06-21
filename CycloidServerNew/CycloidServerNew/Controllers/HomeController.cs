using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace CycloidServerNew.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string login(string login, string pass)
        {
            string user = Logic.Users.Login(login, pass);
            return user;
        }

        public string registr(string result)
        {
            var user = Logic.Users.Registration(result);
            return user;
        }

        public void UpdateUser(string result)
        {
            Logic.Users.UpdateUser(result);
        }

        public string GetRoom(string result)
        {
            int id = Convert.ToInt32(result);
            string res = Logic.Rooms.GetRoom(id);
            return res;
        }

        public string UpdateRoom(string result)
        {
            return JsonConvert.SerializeObject(Logic.Rooms.UpdateRoom(result));
        }

        public void DeleteRoom(string result)
        {
            int id = Convert.ToInt32(result);
            Logic.Rooms.DeleteRoom(id);
        }

        public void AddRoom(string result)
        {
            Logic.Rooms.AddRoom(result);
        }

        public string Rooms(string result)
        {
            return Logic.Rooms.GetRoomsByUser(result);
        }

        public string GetDevice(string result)
        {
            int id = Convert.ToInt32(result);
            string res = Logic.Devices.GetDevice(id);
            return res;
        }

        public string UpdateDevice(string result)
        {
            return JsonConvert.SerializeObject(Logic.Devices.UpdateDevice(result));
        }

        public void DeleteDevice(string result)
        {
            int id = Convert.ToInt32(result);
            Logic.Devices.DeleteDevice(id);
        }

        public void AddDevice(string result)
        {
            Logic.Devices.AddDevice(result);
        }

        public string Devices(string result)
        {
            int id = Convert.ToInt32(result);
            return Logic.Devices.GetDevicesByRoom(id);
        }

        public string Emu(string id, string temperature, string humidity)
        {
            Random rnd = new Random();
            return rnd.Next(0,1)==0?"true":"false";
        }
    }
}
