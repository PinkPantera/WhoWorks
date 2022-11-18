using ClientDataService.Extentions;
using ClientDataService.Interfaces;
using ClientDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataService.Services
{
    public class PersonService : IPersonService
    {
        public Task<PersonModel> CreateAsync(PersonModel personModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(PersonModel personModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonModel>> GetAllAsync()
        {
            IEnumerable<PersonModel> list;
            using var httpClient = new HttpClient();
            list = await httpClient.GetAsyncM<PersonModel>("https://localhost:44383/api/Person/GetAll");

            return list;
        }

        public Task<PersonModel> UpdateAsync(PersonModel personModel)
        {
            throw new NotImplementedException();
        }
    }
}
