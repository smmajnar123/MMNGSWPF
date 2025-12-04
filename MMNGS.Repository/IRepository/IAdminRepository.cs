using MMNGS.DataAccess.Models;
using MMNGS.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMNGS.Repository.IRepository
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        Task<Admin?> GetAdminWithSubscriptionAsync(int adminId);
    }
}
