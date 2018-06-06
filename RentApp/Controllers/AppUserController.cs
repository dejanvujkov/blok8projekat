using RentApp.Models.Entities;
using RentApp.Persistance.Repository.Implementations;
using RentApp.Persistance.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RentApp.Controllers
{
    public class AppUserController : ApiController
    {
        private readonly IUnitOfWork uow;

        public AppUserController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [Route("user/getAll")]
        [HttpGet]
        public IHttpActionResult GetAllUsers()  
        {
            var retVal = uow.AppUsers.GetAll();
            return Ok(retVal);
        }
    }
}
