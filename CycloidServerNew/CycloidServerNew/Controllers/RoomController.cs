using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CycloidServerNew.Models;

namespace CycloidServerNew.Controllers
{
    public class RoomController : ApiController
    {
        private CycloidContext db = new CycloidContext();

        // GET api/Room
        public string GetRooms()
        {
            return "";
        }

        // GET api/Room/5
        public string GetRoom(int id)
        {
            string res = Logic.Rooms.GetRoom(id);
            return res;
        }

        // PUT api/Room/5
        public HttpResponseMessage PutRoom(int id, string room)
        {
            Logic.Rooms.UpdateRoom(room);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Room
        public HttpResponseMessage PostRoom(string room)
        {
            if (ModelState.IsValid)
            {
                Logic.Rooms.AddRoom(room);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, room);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Room/5
        public HttpResponseMessage DeleteRoom(int id)
        {
            if (ModelState.IsValid)
            {
                Logic.Rooms.DeleteRoom(id);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, id);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}