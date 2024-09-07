
using System.Linq.Expressions;

namespace backendecom.Repositories
{
    public interface IRepository<T> where T : class
    {
        // Basic CRUD operations
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Remove(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
