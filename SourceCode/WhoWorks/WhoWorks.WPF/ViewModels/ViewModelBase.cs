using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.WPF.Common;

namespace WhoWorks.WPF.ViewModels
{
    public class ViewModelBase : NotifyPropertyChangedBase
    {
        private string title;


        public string Title
        {
            get => title;
            set
            {
                SetProprty(ref title, value);
            }
        }
    }
}
