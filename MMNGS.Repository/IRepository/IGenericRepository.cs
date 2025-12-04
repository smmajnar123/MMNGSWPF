using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MMNGS.Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        // READ
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);

        // CREATE
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        // UPDATE
        void Update(T entity); // Note: Update is often sync as EF Core tracks changes

        // DELETE
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        Task<T?> GetByIdWithIncludeAsync(int id, params Expression<Func<T, object>>[] includes);
    }
}
