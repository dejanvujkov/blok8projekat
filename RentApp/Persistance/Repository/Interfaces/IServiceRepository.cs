using System.Collections.Generic;
using RentApp.Models.Entities;

namespace RentApp.Persistance.Repository.Interfaces
{
    public interface IServiceRepository : IRepository<Service, int>
    {
        IEnumerable<Service> GetAllNonApproved();
        void AddNewVehicle(Vehicle vehicle, Service service);
        void RemoveVehicle(Vehicle vehicle, Service service);
        
    }
}