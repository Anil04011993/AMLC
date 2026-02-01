using AMLRS.Core.Abstraction.Reposotory;
using AMLRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AMLRS.Infrastructure.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey>
    where T : class
    {
        protected readonly AmlDbContext _context;
        protected readonly DbSet<T> _dbSet;
        protected readonly IUnitOfWork _unitOfWork;

        public Repository(AmlDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _unitOfWork = unitOfWork;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }

}
