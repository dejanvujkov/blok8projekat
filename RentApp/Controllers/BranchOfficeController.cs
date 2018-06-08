using System.Web.Http;
using RentApp.Models.Entities;
using RentApp.Persistance.UnitOfWork;

namespace RentApp.Controllers
{
    public class BranchOfficeController : ApiController
    {
        private IUnitOfWork _uow;

        public BranchOfficeController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [Route("office/add")]
        [HttpPost]
        public IHttpActionResult Add(BranchOffice office)
        {
            _uow.BranchOffice.Add(office);
            _uow.Complete();
            return Ok();
        }

        [Route("office/remove")]
        [HttpDelete]
        public IHttpActionResult Remove(BranchOffice office)
        {
            _uow.BranchOffice.Remove(office);
            _uow.Complete();
            return Ok();
        }

        [Route("office/removeId")]
        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            _uow.BranchOffice.Remove(_uow.BranchOffice.Get(id));
            _uow.Complete();
            return Ok();
        }

        [Route("office/all")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            _uow.BranchOffice.GetAll();
            return Ok();
        }

        [Route("offce/getrange")]
        [HttpGet]
        public IHttpActionResult GetRange(int pageSize, int pageIndex)
        {
            _uow.BranchOffice.GetRange(pageIndex, pageSize);
            return Ok();
        }

        [Route("office/update")]
        [HttpPut]
        public IHttpActionResult Update(BranchOffice office)
        {
            _uow.BranchOffice.Update(office);
            _uow.Complete();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}