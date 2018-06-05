using System.Collections.Generic;
using RentApp.Models.Entities;

namespace RentApp.Persistance.Repository.Interfaces
{
    public interface IAppUserRepositroy : IRepository<AppUser, int>
    {
        IEnumerable<AppUser> GetRange(int pageIndex, int size);
    }
}