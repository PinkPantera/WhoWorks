using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.Service.ModelsDto
{
    public class AddressDto
    {
        public string ShortAddress { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string CityCode { get; set; }
    }
}
