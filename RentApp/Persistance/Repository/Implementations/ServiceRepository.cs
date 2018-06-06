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

        public IEnumerable<Service> GetAllNonApproved()
        {
            return Context.Services.Where(s => !s.Approved);
        }

        public IEnumerable<Service> GetAllNonApproveda()
        {
            return Context.Services.Include(s => s.Manager).Where(s => !s.Approved);
        }

        public void AddNewVehicle(Vehicle vehicle, Service service)
        {
            var s = Context.Services.FirstOrDefault(x => x.Id == service.Id);
            s?.Vehicles.Add(vehicle);
        }

        public void RemoveVehicle(Vehicle vehicle, Service service)
        {
            var s = Context.Services.FirstOrDefault(x => x.Id == service.Id);
            s?.Vehicles.Remove(vehicle);
        }
    }
}