using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CycloidServerNew.Logic
{
    public class Users
    {
        public static string Login(string login, string pass)
        {
            string token = "";
            var user = DataAccess.User.Login(login, pass);
            if (user == null) token = "Invalid login or password";
            else
            {
                token = Guid.NewGuid().ToString();
                Models.Token tkn = new Models.Token() { UserId = user.Id, Tkn = token } ;
                DataAccess.Token.SetToken(tkn);
            }
            return token;
        }

        public static string Login(string data)
        {
            string[] tmp = data.Split('|');
            string login = tmp[0];
            string pass = tmp[1];
            string token = "";
            var user = DataAccess.User.Login(login, pass);
            if (user == null) token = "Invalid login or password";
            else
            {
                token = Guid.NewGuid().ToString();
                Models.Token tkn = new Models.Token() { UserId = user.Id, Tkn = token };
                DataAccess.Token.SetToken(tkn);
            }
            return token;
        }

        public static string Registration(string jsonUser)
        {
            Models.User user = JsonConvert.DeserializeObject<Models.User>(jsonUser);
            DataAccess.User.Registration(user);
            string token = Guid.NewGuid().ToString();
            Models.Token tkn = new Models.Token() { UserId = user.Id, Tkn = token };
            DataAccess.Token.SetToken(tkn);
            return token;
        }

        public static void UpdateUser(string jsonUser)
        {
            var user = JsonConvert.DeserializeObject<Models.User>(jsonUser);
            DataAccess.User.UpdateUser(user);
        }

        public static string GetUser(int id)
        {
            var user = DataAccess.User.GetById(id);
            if (user == null) return "not found";
            return JsonConvert.SerializeObject(user);
        }
    }
}