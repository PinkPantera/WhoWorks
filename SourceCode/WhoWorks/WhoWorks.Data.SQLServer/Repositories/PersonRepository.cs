using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Core;
using WhoWorks.Domain.Models;

namespace WhoWorks.Data.SQLServer.Repositories
{
    public class PersonRepository : IRepository
    {
        private readonly WhoWorksDbContext dbContext;

        public PersonRepository(WhoWorksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IUnitOfWork UnitOfWork => dbContext;

        public Person AddPerson(Person person)
        {
            return dbContext.Persons.Add(person).Entity;
        }
    }
}
