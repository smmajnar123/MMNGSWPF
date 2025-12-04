using MMNGS.DataAccess.Data;
using MMNGS.DataAccess.Models;
using MMNGS.Repository.Interfaces;
using MMNGS.Repository.IRepository;

namespace MMNGS.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MMNGSDbContext _context;

        // Repository backing fields
        private IAdminRepository? _admins;
        private IUserRepository? _users;
        public UnitOfWork(MMNGSDbContext context)
        {
            _context = context;
        }

        // Repository Properties (Lazy Initialization)
        public IAdminRepository Admins =>
            _admins ??= new AdminRepository(_context);

        public IUserRepository Users =>
            _users ??= new UserRepository(_context);


        // Save Changes to the database
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Dispose the DbContext
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
