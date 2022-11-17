using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.WPF.Common;
using WhoWorks.WPF.Interfaces;

namespace WhoWorks.WPF.ViewModels
{
    public class PersonsPageViewModel : ViewModelBasePage, IPage
    {
        public PersonsPageViewModel()
           : base(PageType.Persons)
        {
        }
    }
}
