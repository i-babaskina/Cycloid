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
    public class DeviceController : ApiController
    {
        private CycloidContext db = new CycloidContext();

        // GET api/Device
        public IEnumerable<Device> GetDevices()
        {
            var device = db.Device.Include(d => d.Room);
            return device.AsEnumerable();
        }

        // GET api/Device/5
        public string GetDevice(int id)
        {
            var device = Logic.Devices.GetDevice(id);
            return device;
        }

        // PUT api/Device/5
        public HttpResponseMessage PutDevice(int id, string device)
        {
            Logic.Devices.UpdateDevice(device);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Device
        public HttpResponseMessage PostDevice(string device)
        {
            if (ModelState.IsValid)
            {
                Logic.Devices.AddDevice(device);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Device/5
        public HttpResponseMessage DeleteDevice(int id)
        {
            Logic.Devices.DeleteDevice(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}