using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.Domain.Models
{
    public class Address: BaseModel
    {
        public string ShortAddress { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string CityCode { get; set; }

        public List<Person> Persons { get; set; }
    }
}
