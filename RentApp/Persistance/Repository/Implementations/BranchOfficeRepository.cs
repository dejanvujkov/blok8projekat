using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RentApp.Models.Entities;
using RentApp.Persistance.Repository.Interfaces;

namespace RentApp.Persistance.Repository.Implementations
{
    public class BranchOfficeRepository : Repository<BranchOffice, int>, IBranchOfficeRepository
    {
        public BranchOfficeRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<BranchOffice> GetRange(int pageIndex, int pageSize)
        {
            return Context.Offices.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        protected RADBContext Context => context as RADBContext;
    }
}