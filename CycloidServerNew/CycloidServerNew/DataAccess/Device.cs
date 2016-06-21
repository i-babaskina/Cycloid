using CycloidServerNew.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CycloidServerNew.DataAccess
{
    public class Device
    {
        public static List<Models.Device> GetByRoom(int id)
        {
            List<Models.Device> res = new List<Models.Device>();
            using (CycloidContext context = new CycloidContext())
            {
                res = context.Set<Models.Device>().Where(x => x.Room.Id == id).ToList<Models.Device>();
            }
            return res;
        }

        public static void Add(Models.Device device)
        {
            using (CycloidContext context = new CycloidContext())
            {
                context.Device.Add(device);
                context.SaveChanges();
            }
        }

        public static void Update(Models.Device device)
        {
            using (CycloidContext context = new CycloidContext())
            {
                context.Entry(device).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            var device = GetById(id);
            using (CycloidContext context = new CycloidContext())
            {
                context.Entry(device).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static Models.Device GetById(int id)
        {
            Models.Device room = new Models.Device();
            using (CycloidContext context = new CycloidContext())
            {
                room = context.Set<Models.Device>().Find(id);
            }
            return room;
        }
        
    }
}