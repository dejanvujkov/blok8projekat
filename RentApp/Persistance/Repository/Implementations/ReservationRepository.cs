﻿using System;
using System.Data.Entity;
using System.Linq;
using RentApp.Models.Entities;
using RentApp.Persistance.Repository.Interfaces;

namespace RentApp.Persistance.Repository.Implementations
{
    public class ReservationRepository : Repository<Reservation, int>, IReservationRepository
    {
        public ReservationRepository(DbContext context) : base(context)
        {
        }

        public bool IsReserved(Vehicle vehicle, DateTime fromThisTime)
        {
            return !Context.Reservations.Any(r => r.Vehicle == vehicle && r.TimeTo.Date < fromThisTime.Date);
        }
        protected RADBContext Context => context as RADBContext;
    }
}