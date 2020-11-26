using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestCookieWeb.Core.Abstractions.IRepositories.Base
{
    public interface IBaseRepo<TEntity> where TEntity : class 
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        void RefreshEntity(TEntity entity);
    }
}
