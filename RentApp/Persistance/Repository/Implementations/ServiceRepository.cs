using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RentApp.Models.Entities;
using RentApp.Persistance.Repository.Interfaces;
using RentApp.Services;

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
            return Context.Services.Include(s => s.Manager).Include(w => w.Vehicles).FirstOrDefault(i => i.Id == id);
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

        public IEnumerable<Service> GetServiceById(int id)
        {
            return Context.Services.Include(s => s.Manager).Include(v => v.Vehicles).Where(x => x.Id == id).ToList();
        }

        public IEnumerable<Service> GetAllApprovedServices()
        {
            return Context.Services.Include(s => s.Manager).Include(v=>v.Vehicles).Where(n=>n.Approved);
        }

        public void ApproveService(Service service)
        {
            var s = Context.Services.FirstOrDefault(q => q.Id == service.Id);
            if (s != null && !s.Approved)
            {
                s.Approved = true;
                Context.Entry(s).State = EntityState.Modified;
                Context.SaveChanges();
                var manager = Context.Users.FirstOrDefault(m => m.AppUserId == service.ManagerId);
                if (manager == null) return;
                var subject = "Odobren servis";
                var body =
                    "Postovani,\nOvim putem zelimo da vas obavestimo da je Vas servis odobren i dostupan korisnicima da ga koriste.\nSrecan rad,\nRent-a-car tim.";
                var smtp = new SmtpService();
                smtp.SendMail(subject, body, manager.Email);
            }
        }

        public Service GetDetails(int id)
        {
            var vehicles = Context.Vehicles.Where(v => v.Available && v.ServiceId == id).ToList();
            var service = Context.Services.Include(o => o.Offices).Include(m => m.Manager).FirstOrDefault(q => q.Id == id);
            if (service == null) return null;
            service.Vehicles = vehicles;
            return service;

        }

        public void UploadImage(string base64String, int id)
        {
            var service = Context.Services.FirstOrDefault(u => u.Id == id);
            service.ImagePath = base64String;
            Context.Entry(service).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}