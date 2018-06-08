﻿using RentApp.Models.Entities;
using RentApp.Persistance.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RentApp.Controllers
{
    public class VehicleController : ApiController
    {
        IUnitOfWork uow;

        public VehicleController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [Route("vehicle/add")]
        [HttpPost]
        public IHttpActionResult Add(Vehicle vehicle)
        {
            uow.Vehicles.Add(vehicle);
            uow.Complete();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
