using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.Core
{
    public class IEntityBaseModel
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
