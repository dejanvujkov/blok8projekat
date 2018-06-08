using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RentApp.Models.Entities;
using RentApp.Persistance.Repository.Interfaces;

namespace RentApp.Persistance.Repository.Implementations
{
    public class ServiceRepository : Repository<Service, int>, IServiceRepository
    {
        protected RADBContext Context => context as RADBContext;

        public ServiceRepository(DbContext context) : base(context)
        {
        }

        public override Service Get(int id)
        {
            return Context.Services.Include(s => s.Manager).Include(w => w.Vehicles).Where(i => i.Id == id).FirstOrDefault();
        }

        public IEnumerable<Service> GetAllNonApproved()
        {
            return Context.Services.Include(s => s.Manager).Where(s => !s.Approved).ToList();
        }

        public bool AddNewVehicle(Vehicle vehicle, Service service)
        {
            var s = Context.Services.FirstOrDefault(x => x.Id == service.Id);
            if(s == null)
            {
                return false;
            }
            s.Vehicles.Add(vehicle);
            return true;
        }

        public bool RemoveVehicle(Vehicle vehicle, Service service)
        {

            var s = Context.Services.FirstOrDefault(x => x.Id == service.Id);
            if(s == null)
            {
                return false;
            }
            s.Vehicles.Remove(vehicle);
            return true;
        }

        //public override void Add(Service entity)
        //{
            
        //}
    }
}