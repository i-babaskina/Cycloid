using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CycloidServer.Controllers
{
    public class Lgn {
        public string Login;
        public string Password;
    }
    public class LoginController : ApiController
    {
        // GET api/login
        public string Get(string result)
        {
            var usr = new Models.User();
            usr.Login = "testuser";
            usr.Password = "123456";
            usr.Email = "test@mail.com";
            usr.PhoneNumber = "+388005553535";
            DataAccess.User.Registration(usr);
            string user = Logic.Users.Login(result);
            return "resp";//user;
        }

        // GET api/login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/login
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string data)
        {
            var usr = new Models.User();
            usr.Login = "testuser";
            usr.Password = "123456";
            usr.Email = "test@mail.com";
            usr.PhoneNumber = "+388005553535";
            DataAccess.User.Registration(usr);
            string user = Logic.Users.Login("");
            return Request.CreateResponse(HttpStatusCode.OK ,"resp");//user;
        }

        // PUT api/login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/login/5
        public void Delete(int id)
        {
        }
    }
}
