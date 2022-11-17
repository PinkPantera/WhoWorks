using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.WPF.Common
{
    public static class PageSetup
    {
        private static readonly Dictionary<PageType, string> pages
            = new()
            {
                { PageType.Home, Resource.HomePageTitle },
                { PageType.Persons, Resource.PersonsPageTitle },
                { PageType.Uknown, Resource.PageNotFoundMessage }

            };

        public static string GetPageTitle(PageType pageType)
        {
            pages.TryGetValue(pageType, out string title);
            return title;
        }
    }
}
