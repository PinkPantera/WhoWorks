using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WhoWorks.WpfCustomControlLibrary.CustomControls;

namespace WhoWorks.WPF.Common
{
    public class Day : NotifyPropertyChangedBase, IDay
    {
        private int dayOfWeek;
        private int weekNo;
        private string? content;
        private int idContent;

        public StateOfDay State
        {
            get
            {
                if (dayOfWeek == 6)
                    return StateOfDay.Disabled;
                if (IdContent == 0)
                    return StateOfDay.NotActive;
                if (Hours == null || Hours.Count == 0)
                    return StateOfDay.Understaffed;
                return StateOfDay.Completed;
            }
        }
        public int IdContent
        {
            get => idContent;
            set
            {
                if (SetProprty(ref idContent, value))
                {
                    OnPropertyChanged(nameof(State));
                }
            }
        }
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
        public string? Content
        {
            get => content;
            set => SetProprty(ref content, value);
        }
    }
}
