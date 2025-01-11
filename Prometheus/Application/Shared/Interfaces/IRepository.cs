using Infrastructure.Shared.Context;

namespace Application.Shared.Interfaces
{
    public interface IRepository
    {
        Task<TEntity> GetByIdAsync<TEntity>(Guid id) where TEntity : class;
        Task<bool> ExistsAsync<TEntity>(Func<TEntity, bool> predicate) where TEntity : class;
        Task AddAsync<TEntity>(TEntity entity) where TEntity : class;
        Task SaveChangesAsync();
    }

    public class Repository : IRepository
    {
        private readonly BaseContext _context;

        public Repository(BaseContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(Guid id) where TEntity : class
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> ExistsAsync<TEntity>(Func<TEntity, bool> predicate) where TEntity : class
        {
            return await Task.FromResult(_context.Set<TEntity>().Any(predicate));
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
