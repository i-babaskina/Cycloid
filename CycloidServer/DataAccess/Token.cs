﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CycloidContext = CycloidServer.Models.CycloidContext;

namespace CycloidServer.DataAccess
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
                var tkn = context.Set<Models.Token>().Where(x => x.token == token).FirstOrDefault();
                return tkn.UserId;
            }
        }

        public static void Delete(string token)
        {
            using (CycloidContext context = new CycloidContext())
            {
                var tkn = context.Set<Models.Token>().Where(x => x.token == token).FirstOrDefault();
                context.Entry(tkn).State = System.Data.EntityState.Deleted;
            }
        }
    }
}