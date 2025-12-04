using MMNGS.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMNGS.Services.IServices
{
    public interface IUserService
    {
        Task<List<User?>> GetUserDetails();
    }
}
