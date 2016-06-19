using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CycloidServer.Controllers
{
    public class UserController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/user/5 (login)
        public string Get(int id)
        {
            return Logic.Users.GetUser(id);
        }

        // POST api/user (registration)
        public string PostRegistration([FromBody]string value)
        {
            var user = Logic.Users.Registration(value);
            return user;
        }

        // PUT api/user/5 (update user info)
        public void Put(int id, [FromBody]string value)
        {
            Logic.Users.UpdateUser(value);
        }

        // DELETE api/user/5 (mb add logout here????????)
        public void Delete(int id)
        {
        }

        [ActionName("login")]
        [HttpPost]
        public static string Login([FromBody]string value)
        {
            string token = Logic.Users.Login(value);
            return token;
        }
    }
}
