using MMNGS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMNGS.Services.Interfaces
{
    public interface IAdminService
    {
        Task<Admin?> GetAdminDetails(int adminId);

        Task CreateAdmin(int adminId, Admin admin);
    }
}
