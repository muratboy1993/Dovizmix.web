using Data.Provider.EF;
using Data.Repositories.DataAccess.EF.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Data.Repositories.DataAccess.EF.Concrete
{

    public abstract class EntityRepositoryBase<T> : IEntityRepositoryBase<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public EntityRepositoryBase(EFDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException("Db Context null!");
            _dbSet = dbContext.Set<T>();
        }
        public async Task<int> Add(T entity)
        {
            var addedEntity = _dbSet.Add(entity);
            addedEntity.State = EntityState.Added;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            var updatedEntity = _dbSet.Attach(entity);
            updatedEntity.State = EntityState.Modified;
            int a = await _dbContext.SaveChangesAsync();
            _dbContext.Entry(entity).State = EntityState.Detached;
            return a;
        }

        public async Task<int> Delete(T entity)
        {

            if (entity.GetType().GetProperty("IsDelete") != null)
            {
                T _entity = entity;

                _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

                return await this.Update(_entity);
            }
            else
            {
                // Önce entity'nin state'ini kontrol etmeliyiz.
                EntityEntry dbEntityEntry = _dbContext.Entry(entity);
                
                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
                return await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            //return filter == null
            //         ? _dbSet.ToListAsync()
            //         : _dbSet.Where(filter).ToListAsync();

            if(filter==null)
            {
                return await _dbSet.ToListAsync();
            }
            else
            {
                return await _dbSet.Where(filter).ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null) return false ;
            else
            {
                if (entity.GetType().GetProperty("IsDelete") != null)
                {
                    T _entity = entity;
                    _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

                    await this.Update(_entity);
                }
                else
                {
                    await Delete(entity);
                }
            }
            return true;
        }
    }
}
