using System;

namespace RentApp.Models.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int ReturnBranchOfficeId { get; set; }
        public BranchOffice ReturnBranchOffice { get; set; }
        public int TakeAwayBranchOfficeId { get; set; }
        public BranchOffice TakeAwayBranchOffice { get; set; }

        public Reservation(AppUser user, DateTime from, DateTime to, Vehicle vehicle, Service service, BranchOffice take, BranchOffice ret)
        {
            User = user;
            TimeFrom = from;
            TimeTo = to;
            Vehicle = vehicle;
            Service = service;
            ReturnBranchOffice = ret;
            TakeAwayBranchOffice = take;
        }
    }
}