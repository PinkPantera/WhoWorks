using System.Linq.Expressions;

namespace WhoWorks.Core
{
    public interface IRepository<TEntity> where TEntity : IEntityBaseModel
    {
        ValueTask<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> SinglOrDefaulAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemouveRange(IEnumerable<TEntity> entities);

        ValueTask<TEntity?> Update(TEntity entity);

    }
}