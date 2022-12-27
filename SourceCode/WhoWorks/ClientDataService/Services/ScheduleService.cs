using ClientDataService.Interfaces;
using ClientDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataService.Services
{
    public class ScheduleService : IScheduleService
    {
        public Task<ScheduleModel> CreateAsync(ScheduleModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ScheduleModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ScheduleModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<ScheduleModel>> GetSchedulesResidanceByMonthAsync(int year, int month, int idResidance)
        {
            IList< ScheduleModel> list = new List<ScheduleModel>();
            list.Add(new ScheduleModel
            {
                Residence = new ResidenceModel { Id = 1 },
                Date = new DateOnly(year, month, 29),
                TimeBegin = new TimeOnly(8,0),
                TimeEnd = new TimeOnly(19,0),
                Person = new PersonModel { FirstName = "Cleary", SecondName = "Stephen" }
            });
            list.Add(new ScheduleModel
            {
                Residence = new ResidenceModel { Id = 1 },
                Date = new DateOnly(year, month, 2),
                TimeBegin = new TimeOnly(8, 0),
                TimeEnd = new TimeOnly(19, 0),
                Person = new PersonModel { FirstName = "Cleary", SecondName = "Stephen" }
            });
            list.Add(new ScheduleModel
            {
                Residence = new ResidenceModel { Id = 1 },
                Date = new DateOnly(year, month, 3),
                TimeBegin = new TimeOnly(8, 0),
                TimeEnd = new TimeOnly(10, 30),
                Person = new PersonModel { FirstName = "Cleary", SecondName = "Stephen" }
            });
            list.Add(new ScheduleModel
            {
                Residence = new ResidenceModel { Id = 1 },
                Date = new DateOnly(year, month, 5),
                TimeBegin = new TimeOnly(8, 0),
                TimeEnd = new TimeOnly(19, 0),
                Person = new PersonModel { FirstName = "Cleary", SecondName = "Stephen" }
            });
            list.Add(new ScheduleModel
            {
                Residence = new ResidenceModel { Id = 1 },
                Date = new DateOnly(year, month, 6),
                TimeBegin = new TimeOnly(8, 0),
                TimeEnd = new TimeOnly(19, 0),
                Person = new PersonModel { FirstName = "Cleary", SecondName = "Stephen" }
            });

            list.Add(new ScheduleModel
            {
                Residence = new ResidenceModel { Id = 1 },
                Date = new DateOnly(year, month, 7),
                TimeBegin = new TimeOnly(8, 0),
                TimeEnd = new TimeOnly(12, 0),
                Person = new PersonModel { FirstName = "Cleary", SecondName = "Stephen" }
            });
            list.Add(new ScheduleModel
            {
                Residence = new ResidenceModel { Id = 1 },
                Date = new DateOnly(year, month, 7),
                TimeBegin = new TimeOnly(15, 0),
                TimeEnd = new TimeOnly(19, 0),
                Person = new PersonModel { FirstName = "Villetorte", SecondName = "Emilie" }
            });
            list.Add(new ScheduleModel
            {
                Residence = new ResidenceModel { Id = 1 },
                Date = new DateOnly(year, month, 19),
                TimeBegin = new TimeOnly(8, 0),
                TimeEnd = new TimeOnly(19, 0),
                Person = new PersonModel { FirstName = "Pichaud", SecondName = "Christophe" }
            });
            list.Add(new ScheduleModel
            {
                Residence = new ResidenceModel { Id = 1 },
                Date = new DateOnly(year, month, 20),
                TimeBegin = new TimeOnly(8, 0),
                TimeEnd = new TimeOnly(19, 0),
                Person = new PersonModel { FirstName = "Pichaud", SecondName = "Christophe" }
            });
            list.Add(new ScheduleModel
            {
                Residence = new ResidenceModel { Id = 1 },
                Date = new DateOnly(year, month, 21),
                TimeBegin = new TimeOnly(8, 0),
                TimeEnd = new TimeOnly(19, 0),
                Person = new PersonModel { FirstName = "Pichaud", SecondName = "Christophe" }
            });

            return Task.FromResult(list);
        }

        public Task<ScheduleModel> UpdateAsync(ScheduleModel model)
        {
            throw new NotImplementedException();
        }
    }
}
