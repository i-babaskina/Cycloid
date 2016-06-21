using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace CycloidServerNew.Controllers
{
    public class WebApiController : Controller
    {
        public string Test()
        {
            string login = Request.Params.Get("login");
            string pass = Request.Params.Get("pass");
            return "1: " + login + "; 2: " + pass;
        }
    }
}
