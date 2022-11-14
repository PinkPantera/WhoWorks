using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.Core;

namespace WhoWorks.Domain.Models
{
    public class BaseModel: IEntityBaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
