using MMNGS.DataAccess.Models;
using MMNGS.Repository.Interfaces;
using MMNGS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMNGS.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        public async Task CreateAdmin(int adminId, Admin admin)
        {
            admin.AdminId = adminId;

            // Add the new User
            await _unitOfWork.Admins.AddAsync(admin);

            // Save changes for all operations in this method
            await _unitOfWork.CompleteAsync();
        }

        public async Task<Admin?> GetAdminDetails(int adminId)
        {
            return await _unitOfWork.Admins.GetAdminWithSubscriptionAsync(adminId);
        }
    }
}
