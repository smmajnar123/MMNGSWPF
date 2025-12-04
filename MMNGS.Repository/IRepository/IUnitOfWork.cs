using MMNGS.DataAccess.Models;
using MMNGS.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMNGS.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Define repositories for your entities
        IAdminRepository Admins { get; }
        IUserRepository Users { get; }
        Task<int> CompleteAsync();
    }
}
