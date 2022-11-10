using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.Service.ModelsDto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentityCard { get; set; }
        public AddressDto? AddressDto { get; set; }
        public PhotoDto? PhotoDto { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
