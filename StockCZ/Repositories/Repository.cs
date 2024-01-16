using Microsoft.EntityFrameworkCore;
using StockCZ.Models;
using StockCZ.Shared.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StockCZ.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseObject
    {
        public AppDbContext _dbContext;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(params object[] id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> GetMaxIdAsync()
        {
            int Id = 1;
            try
            {
                Id = await _dbContext.Set<T>().MaxAsync(a => a.BaseId) + 1;
            }
            catch
            {
                Id = 1;
            }

            return Id;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdWithIncludeAsync(long id, Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            var entity = _dbContext.Set<T>().Where(e => e.BaseId == id);

            if (filter != null)
            {
                entity = entity.Where(filter);
            }

            if (includes?.Length > 0)
            {
                foreach (var include in includes)
                {
                    entity = entity.Include(include);
                }
            }

            return await entity.FirstOrDefaultAsync();
        }
    }
}