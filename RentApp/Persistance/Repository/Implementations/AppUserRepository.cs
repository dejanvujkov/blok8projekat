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

        protected RADBContext Context => context as RADBContext;
    }
}