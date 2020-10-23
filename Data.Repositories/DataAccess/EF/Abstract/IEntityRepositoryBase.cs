using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Abstract
{
    public interface IEntityRepositoryBase<T> where T : class
    {
        Task<T> Get(Expression<Func<T, bool>> filter = null);
        Task<T> GetById(int id);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<int> Add(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<bool> Delete(int id);
    }
}
