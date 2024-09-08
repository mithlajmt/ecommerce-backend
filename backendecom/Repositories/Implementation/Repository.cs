using backendecom.Data; // This includes the ApplicationDbContext, which is the Entity Framework Core DbContext
using Microsoft.EntityFrameworkCore; // Provides DbSet<T> and other EF Core functionalities

namespace backendecom.Repositories.Implementation // Defines the namespace for organizing your classes
{
    // Generic repository implementation for any type of class (T).
    // The "where T : class" constraint ensures that T is always a reference type (i.e., an entity class).
    public class Repository<T> : IRepository<T> where T : class
    {
        // Private members to store the DbContext and DbSet for the given entity type (T).
        private readonly ApplicationDbContext _context; // The database context that will manage the connection to the database.
        private readonly DbSet<T> _dbSet; // DbSet represents a table in the database for the entity of type T.

        // Constructor that accepts the ApplicationDbContext and initializes the _dbSet.
        public Repository(ApplicationDbContext context)
        {
            // We inject the ApplicationDbContext through the constructor, which is a best practice for Dependency Injection (DI).
            _context = context;

            // _dbSet is assigned the DbSet of the type T from the context.
            // This allows us to work with the table corresponding to the entity T.
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

    }
}
