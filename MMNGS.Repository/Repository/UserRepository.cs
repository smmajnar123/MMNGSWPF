using MMNGS.DataAccess.Data;
using MMNGS.DataAccess.Models;
using MMNGS.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMNGS.Repository.Repository
{
    public class UserRepository(MMNGSDbContext context) : GenericRepository<User>(context), IUserRepository
    {
    }
}
