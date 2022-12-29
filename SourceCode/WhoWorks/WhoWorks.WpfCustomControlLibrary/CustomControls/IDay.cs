using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WhoWorks.WpfCustomControlLibrary.CustomControls
{
    public interface IDay
    {
        int IdContent { get; set; }
        string Content { get; set; }
        int DayOfWeek { get; set; }
        int NumberOfDay { get; set; }
        int WeekNo { get; set; }
        StateOfDay State { get; }
    }
}
