using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using RentApp.Models.Entities;
using RentApp.Persistance.Repository.Interfaces;

namespace RentApp.Persistance.Repository.Implementations
{
    public class AppUserRepository : Repository<AppUser, int>, IAppUserRepositroy
    {
        
        public AppUserRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<AppUser> GetRange(int pageIndex, int size)
        {
            return Context.AppUsers.Skip((pageIndex - 1) * size).Take(size);
        }

        public IEnumerable<AppUser> GetAllUnapprovedUsers()
        {
            return Context.AppUsers.Where(u => !string.IsNullOrEmpty(u.ImagePath) && !u.Approved);
        }

        public void ApproveUser(AppUser user)
        {
            //TODO ispraviti ovde exception da ne baca
            var u = Context.AppUsers.FirstOrDefault(s => user != null && s.Id == user.Id);
            if (u != null && !u.Approved)
            {
                u.Approved = true;
            }
            Context.Entry(u).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IEnumerable<RAIdentityUser> GetAllManagers()
        {
            var managers = Context.Users.Where(u => u.Roles.Any(r => r.RoleId.Equals("6b7ff08d-7607-498a-8bb3-d71a60c9588d"))).Include(i=>i.AppUser).ToList();
            return managers;
        }

        public IdentityUser GetUserDetails(string username)
        {
            var user = Context.Users.Where(v => v.Id.Equals(username)).Include(i=>i.AppUser).FirstOrDefault();
            return user;

        }


        protected RADBContext Context => context as RADBContext;
    }
}