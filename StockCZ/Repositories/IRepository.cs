using StockCZ.Shared.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StockCZ.Repositories
{
    public interface IRepository<T> where T : BaseObject
    {
        Task<T> GetByIdAsync(params object[] id);
        Task<T> GetByIdWithIncludeAsync(long id, Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> GetMaxIdAsync();
    }
}