using ClientDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataService.Interfaces
{
    public interface IScheduleService : IServiceBase<ScheduleModel>
    {
        Task<IList<ScheduleModel>> GetSchedulesResidanceByMonthAsync(int year, int month, int idResidance);
    }
}
