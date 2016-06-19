using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CycloidContext = CycloidServer.Models.CycloidContext;

namespace CycloidServer.DataAccess
{
    public class Room
    {
        public static void Add(Models.Room room)
        {
            using (CycloidContext context = new CycloidContext())
            {
                context.Room.Add(room);
                context.SaveChanges();
            }
        }

        public static void Update(Models.Room room)
        {
            using (CycloidContext context = new CycloidContext())
            {
                context.Entry(room).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            var room = GetById(id);
            using (CycloidContext context = new CycloidContext())
            {
                var devices = DataAccess.Device.GetByRoom(id);
                foreach (var device in devices)
                {
                    context.Entry(device).State = EntityState.Deleted;
                }
                context.Entry(room).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static Models.Room GetById(int id)
        {
            Models.Room room = new Models.Room();
            using (CycloidContext context = new CycloidContext())
            {
                room = context.Set<Models.Room>().Find(id);
            }
            return room;
        }

        public static List<Models.Room> GetByUser(int id)
        {
            List<Models.Room> res = new List<Models.Room>();
            using (CycloidContext context = new CycloidContext())
            {
                res = context.Set<Models.Room>().Where(x => x.User.Id == id).ToList<Models.Room>();
            }
            return res;
        }
    }
}