using CycloidServerNew.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CycloidServerNew.DataAccess
{
    public class Token
    {
        public static void SetToken(Models.Token token)
        {
            using (CycloidContext context = new CycloidContext())
            {
                context.Token.Add(token);
                context.SaveChanges();
            }
        }

        public static int GetUserId(string token)
        {
            using (CycloidContext context = new CycloidContext())
            {
                var tkn = context.Set<Models.Token>().Where(x => x.Tkn == token).FirstOrDefault();
                return tkn.UserId;
            }
        }

        public static void Delete(string token)
        {
            using (CycloidContext context = new CycloidContext())
            {
                var tkn = context.Set<Models.Token>().Where(x => x.Tkn == token).FirstOrDefault();
                context.Entry(tkn).State = EntityState.Deleted;
            }
        }
    }
}