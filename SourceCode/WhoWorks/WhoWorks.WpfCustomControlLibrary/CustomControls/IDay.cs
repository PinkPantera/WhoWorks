using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.WpfCustomControlLibrary.CustomControls
{
    public interface IDay
    {
        string Content { get; set; }
        int DayOfWeek { get; set; }
        int NumberOfDay { get; set; }
        int WeekNo { get; set; }
    }
}
