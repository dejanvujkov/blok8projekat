﻿using System.Collections.Generic;
using RentApp.Models.Entities;

namespace RentApp.Persistance.Repository.Interfaces
{
    public interface IBranchOfficeRepository : IRepository<BranchOffice, int>
    {
        IEnumerable<BranchOffice> GetRange(int pageIndex, int pageSize);
    }
}