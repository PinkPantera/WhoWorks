using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataService.Models
{
    public class ScheduleModel
    {
        public ResidenceModel Residence { get; set; }
        public PersonModel Person { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly TimeBegin { get; set; }
        public TimeOnly TimeEnd { get; set; }
    }
}
