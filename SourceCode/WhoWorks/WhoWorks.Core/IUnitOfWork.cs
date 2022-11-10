using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.Core
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : IEntityBaseModel;
        Task<int> SaveChanges(CancellationToken cancellationToken = default);
    }
}
