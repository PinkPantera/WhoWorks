using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.Domain.Models
{
    public class Person: BaseModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string IdentityCard { get; set; } = string.Empty;
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public int? PhotoId { get; set; }
        public Photo? Photo { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
