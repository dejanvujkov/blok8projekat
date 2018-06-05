using System;
using RentApp.Models.Entities;

namespace RentApp.Persistance.Repository.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation, int>
    {
        bool IsReserved(Vehicle vehicle, DateTime fromThisTime);
    }
}