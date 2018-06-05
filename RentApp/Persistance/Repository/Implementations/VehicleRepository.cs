using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RentApp.Models.Entities;
using RentApp.Persistance.Repository.Interfaces;

namespace RentApp.Persistance.Repository.Implementations
{
    public class VehicleRepository : Repository<Vehicle, int>, IVehicleRepository
    {
        protected RADBContext Context => context as RADBContext;

        public VehicleRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Vehicle> GetRange(int pageIndex, int pageSize)
        {
            return Context.Vehicles.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}