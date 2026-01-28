using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Infrastructure.Data;

namespace AMLRS.Infrastructure.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey>
    where T : class//BaseEntity<TKey>
    {
        protected readonly AmlDbContext _context;

        public Repository(AmlDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(TKey id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }
    }


}
