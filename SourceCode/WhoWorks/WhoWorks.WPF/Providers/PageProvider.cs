using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.WPF.Common;
using WhoWorks.WPF.Interfaces;
using WhoWorks.WPF.StartupHelpers;

namespace WhoWorks.WPF.Providers
{
    public class PageProvider : IPageProvider
    {
        private readonly ServicePageResolver servicePageResolver;
        public PageProvider(ServicePageResolver servicePageResolver)
        {
            this.servicePageResolver = servicePageResolver;
        }

        public IPage GetPage(PageType pageType)
        {
            return servicePageResolver(pageType);
        }
    }
}
