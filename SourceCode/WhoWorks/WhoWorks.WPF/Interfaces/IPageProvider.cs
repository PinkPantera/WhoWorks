using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.WPF.Common;

namespace WhoWorks.WPF.Interfaces
{
    public interface IPageProvider
    {
        IPage GetPage(PageType pageType);
    }
}
