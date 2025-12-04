using Microsoft.EntityFrameworkCore;
using MMNGS.DataAccess.Data;
using MMNGS.DataAccess.Models;
using MMNGS.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MMNGS.Repository.Repository
{
    public class AdminRepository(MMNGSDbContext context) : GenericRepository<Admin>(context), IAdminRepository
    {
        private new readonly MMNGSDbContext _context = context;

        // Fetch Admin with Subscription included
        public async Task<Admin?> GetAdminWithSubscriptionAsync(int adminId)
        {
            return await _dbSet
                .Include(a => a.Subscription)    // Load Subscription navigation
                .FirstOrDefaultAsync(a => a.AdminId == adminId);
        }
    }
}
