using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Core;
using WhoWorks.Domain.Models;

namespace WhoWorks.Data.SQLServer.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : IEntityBaseModel
    {
        protected readonly DbContext context;

        public RepositoryBase(DbContext context)
        {
            this.context = context;
        }

        public virtual TEntity Add(TEntity entity)
        {
            return context
                  .Add(entity)
                  .Entity;
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await context.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public virtual void RemouveRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<TEntity?> SinglOrDefaulAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public virtual ValueTask<TEntity?> GetByIdAsync(int id)
        {
            return context.FindAsync<TEntity>(id);
        }

        public abstract ValueTask<TEntity?> Update(TEntity entity);
    }
}
