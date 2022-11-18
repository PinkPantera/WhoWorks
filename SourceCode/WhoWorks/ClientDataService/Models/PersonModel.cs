using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataService.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string IdentityCard { get; set; } = string.Empty;
        public AddressModel? Address { get; set; }
        public PhotoModel? Photo { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
