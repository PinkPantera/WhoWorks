using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.WPF.Common;
using WhoWorks.WPF.Interfaces;

namespace WhoWorks.WPF.ViewModels
{
    public abstract class ViewModelBasePage : ViewModelBase, IPage
    {
        private readonly PageType pageType;
        public ViewModelBasePage(PageType pageType)
        {
            this.pageType = pageType;
            Title = PageSetup.GetPageTitle(pageType);
        }

        public PageType PageType => pageType;

        public virtual void Refreshe()
        {
        }
    }
}
