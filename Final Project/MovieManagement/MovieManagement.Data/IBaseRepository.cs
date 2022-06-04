using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Data
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(params object[] key);

        Task CreateAsync(T entity);

        //Task RemoveAsync(T entity);

        Task RemoveAsync(params object[] Key);

        Task UpdateAsync(T entity);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> Table { get; }
    }
}
