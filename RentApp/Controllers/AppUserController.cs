﻿using RentApp.Models.Entities;
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

        [Route("user/get")]
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            var retVal = uow.AppUsers.Get(id);
            return Ok(retVal);
        }

        [Route("user/remove")]
        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            try
            {
                uow.AppUsers.Remove(uow.AppUsers.Get(id));
                uow.Complete();
            }
            catch
            {
                return NotFound();
            }

            return Ok();
        }

        [Route("user/update")]
        [HttpPut]
        public IHttpActionResult Update(AppUser user)
        {
            uow.AppUsers.Update(user);
            uow.Complete();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            uow.Dispose();
            base.Dispose(disposing);
        }

    }
}
