using MMNGS.DataAccess.Models;
using MMNGS.Repository.Interfaces;
using MMNGS.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMNGS.Services.Services
{
    public class UserService(IUnitOfWork unitOfWork) : IUserService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<List<User?>> GetUserDetails()
        {
            var userData = await _unitOfWork.Users.GetAllAsync();
            return (List<User?>)userData;
        }
    }
}
