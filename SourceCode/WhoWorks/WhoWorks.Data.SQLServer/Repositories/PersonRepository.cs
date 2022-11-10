using Microsoft.EntityFrameworkCore;
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

        public async override ValueTask<Person?> Update(Person entity)
        {
            var person = await dbContext.Persons.FindAsync(entity.Id);

            if (person == null)
                return null;

            person.FirstName = entity.FirstName;
            person.SecondName = entity.SecondName;
            person.DateOfBirth = entity.DateOfBirth;
            person.IdentityCard = entity.IdentityCard;
            person.Phone = entity.Phone;
            person.Email = entity.Email;

            if (entity.Address != null)
            {
                if (person.Address == null)
                {
                    person.Address = new Address();
                }
                person.Address.ShortAddress = entity.Address.ShortAddress;
                person.Address.Town = entity.Address.Town;
                person.Address.Region = entity.Address.Region;
                person.Address.Country = entity.Address.Country;
                person.Address.CityCode = entity.Address.CityCode;
            }

            if (entity.Photo != null)
            {
                if (person.Photo == null)
                {
                    person.Photo = new Photo();
                }
                person.Photo.ImageData = entity.Photo.ImageData;
            }

            return person;
        }
    }
}
