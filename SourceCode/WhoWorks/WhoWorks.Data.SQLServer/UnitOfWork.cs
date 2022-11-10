using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhoWorks.Core;

namespace WhoWorks.Data.SQLServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WhoWorksDbContext dbContext;
        private readonly IServiceProvider services;

        public UnitOfWork(WhoWorksDbContext dbContext, IServiceProvider services )
        {
            this.dbContext = dbContext;
            this.services = services;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : IEntityBaseModel
        {
           return services.GetRequiredService<IRepository<TEntity>>();
        }

        public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
