using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestCookieWeb.Core.Abstractions.IServices.Base
{
    public interface IBaseService<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetIdAsync(int id);
        Task CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
