using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Core;
using WhoWorks.Domain.Models;

namespace WhoWorks.Data.SQLServer.Repositories
{
    public class PersonRepository : RepositoryBase<Person>
    {
        private readonly WhoWorksDbContext dbContext;

        public PersonRepository(WhoWorksDbContext dbContext)
            :base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<Person>> GetAll()
        {
            var result = await dbContext.Persons
                .AsQueryable()
                .Where(p => !p.IsDeleted)
                .ToListAsync();

            return result;
        }
    }
}
