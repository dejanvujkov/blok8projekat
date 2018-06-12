﻿using System.Collections.Generic;
using RentApp.Models.Entities;

namespace RentApp.Persistance.Repository.Interfaces
{
    public interface IServiceRepository : IRepository<Service, int>
    {
        IEnumerable<Service> GetAllNonApproved();
        bool AddNewVehicle(Vehicle vehicle, Service service);
        bool RemoveVehicle(Vehicle vehicle, Service service);

        Service GetDetails(int id);
        IEnumerable<Service> GetServiceById(int id);
    }
}