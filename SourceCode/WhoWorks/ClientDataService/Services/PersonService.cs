﻿using ClientDataService.Extentions;
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
        private readonly IWebApiSettings webApiSettings;

        public PersonService(IWebApiSettings webApiSettings)
        {
            this.webApiSettings = webApiSettings;
        }

        public Task<PersonModel> CreateAsync(PersonModel personModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(PersonModel personModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<PersonModel>> GetAllAsync()
        {
            IList<PersonModel> list;
            using var httpClient = new HttpClient();
            list = await httpClient.GetAsync<List<PersonModel>>($"{webApiSettings.GetUrl}/Person/GetAll");

            return list;
        }

        public Task<PersonModel> UpdateAsync(PersonModel personModel)
        {
            throw new NotImplementedException();
        }
    }
}
