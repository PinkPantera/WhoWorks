using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.WpfCustomControlLibrary.CustomControls;

namespace WhoWorks.WPF.Common
{
    public class Day : NotifyPropertyChangedBase, IDay
    {
        private int dayOfWeek;
        private int weekNo;

        public int WeekNo
        {
            get => weekNo;
            set => SetProprty(ref weekNo, value);
        }
        public int DayOfWeek
        {
            get => dayOfWeek;
            set => SetProprty(ref dayOfWeek, value);
        }
        public DateOnly Date { get; set; }
        public int NumberOfDay { get; set; }
        public List<AssignedHours> Hours { get; set; }
        public string? Content { get; set; }
    }
}
