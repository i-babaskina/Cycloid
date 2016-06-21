using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CycloidServerNew.Logic
{
    public class Devices
    {
        public static void AddDevice(string jsonDevice)
        {
            var device = JsonConvert.DeserializeObject<Models.Device>(jsonDevice);
            DataAccess.Device.Add(device);
        }
        public static Models.Device UpdateDevice(string jsonDevice)
        {
            var device = JsonConvert.DeserializeObject<Models.Device>(jsonDevice);
            DataAccess.Device.Update(device);
            return device;
        }
        public static void DeleteDevice(int id)
        {
            DataAccess.Device.Delete(id);
        }

        public static string GetDevice(int id)
        {
            var device = Devices.GetDevice(id);
            return JsonConvert.SerializeObject(device);
        }

        public static string GetDevicesByRoom(int id)
        {
            var devices = DataAccess.Device.GetByRoom(id);
            return JsonConvert.SerializeObject(devices);
        }

        public static void OnDevice(int id)
        {
            var device = DataAccess.Device.GetById(id);
            device.State = true;
            DataAccess.Device.Update(device);
        }

        public static void OffDevice(int id)
        {
            var device = DataAccess.Device.GetById(id);
            device.State = false;
            DataAccess.Device.Update(device);
        }

    }
}