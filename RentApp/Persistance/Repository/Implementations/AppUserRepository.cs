using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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


        protected RADBContext Context => context as RADBContext;
    }
}