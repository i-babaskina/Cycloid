using CycloidServerNew.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CycloidServerNew.DataAccess
{
    public class User
    {
        public static Models.User Login(string login, string pass)
        {
            var res = new Models.User();
            using (CycloidContext context = new CycloidContext())
            {
                res = context.Set<Models.User>().Where(x => x.Login == login && x.Password == pass).FirstOrDefault();
            }
            return res;
        }


        public static void Registration(Models.User user)
        {
            using (CycloidContext context = new CycloidContext())
            {
                context.User.Add(user);
                context.SaveChanges();
            }
        }

        public static void UpdateUser(Models.User user)
        {
            using (CycloidContext context = new CycloidContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static Models.User GetById(int id)
        {
            using (CycloidContext context = new CycloidContext())
            {
                var user = context.Set<Models.User>().Find(id);
                return user;
            }
        }
    }
}