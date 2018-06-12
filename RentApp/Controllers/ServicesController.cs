using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RentApp.Models.Entities;
using RentApp.Persistance;
using RentApp.Persistance.UnitOfWork;

namespace RentApp.Controllers
{
    public class ServicesController : ApiController
    {
        private readonly IUnitOfWork uow;

        public ServicesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [Route("service/getAll")]
        [HttpGet]
        public IEnumerable<Service> GetAllServices()
        {
            var x = uow.Services.GetAll();
            return x;
        }

        [Route("service/get")]
        [HttpGet]
        [ResponseType(typeof(Service))]
        public IHttpActionResult GetService(int id)
        {
            Service service = uow.Services.Get(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }
        //TODO izmenuti tako da se povlace sva vozila i filijale
        [Route("service/getDetails")]
        [HttpGet]
        [ResponseType(typeof(Service))]
        public IHttpActionResult GetServiceDetails(int id)
        {
           Service service = uow.Services.GetDetails(id);
            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        [Route("service/find")]
        [HttpGet]
        public IHttpActionResult Find(Expression<Func<Service, bool>> predicate)
        {
            return Ok(uow.Services.Find(predicate).ToList());
        }

        // PUT: api/Services/5
        [Route("service/update")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Update(Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                uow.Services.Update(service);
                uow.Complete();
            }
            catch
            {
                return NotFound();
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("service/add")]
        [HttpPost]
        [ResponseType(typeof(Service))]
        public IHttpActionResult AddService(Service service)
        {
            service.Offices = new List<BranchOffice>();
            service.Vehicles = new List<Vehicle>();

            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            uow.Services.Add(service);
            uow.Complete();

            return CreatedAtRoute("DefaultApi", new { id = service.Id }, service);
        }

        [Route("service/remove")]
        [HttpDelete]
        // DELETE: api/Services/5
        [ResponseType(typeof(Service))]
        public IHttpActionResult DeleteService(int id)
        {
            Service service = uow.Services.Find(i => i.Id == id).FirstOrDefault();
            if (service == null)
            {
                return NotFound();
            }

            uow.Services.Remove(service);
            uow.Complete();

            return Ok(service);
        }
        
        [Route("service/getNonApproved")]
        [HttpGet]
        public IHttpActionResult GetAllNonApproved()
        {
            return Ok(uow.Services.GetAllNonApproved());
        }

        

        //[Route("service/removeVehicle")]
        //[HttpDelete]
        //public IHttpActionResult RemoveVehicle(Vehicle vehicle, Service service)
        //{
        //    if(!uow.Services.RemoveVehicle(vehicle, service))
        //    {
        //        return NotFound();
        //    }
        //    return Ok(vehicle);
        //}

        [HttpGet]
        [Route("service/getbyid")]
        public IHttpActionResult GetById(int id)
        {
            var x = uow.Services.GetServiceById(id);
            return Ok();
        }

        private bool ServiceExists(int id)
        {
            return uow.Services.Find(e => e.Id == id).ToList().Count > 0;
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