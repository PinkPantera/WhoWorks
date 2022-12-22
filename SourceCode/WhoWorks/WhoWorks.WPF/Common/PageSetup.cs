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
                { PageType.Main, Resource.MainPageTitle },
                { PageType.Persons, Resource.PersonsPageTitle },
                { PageType.Buildings, Resource.BuildingsPageTitle },
                { PageType.Settings, Resource.SettingsPageTitle},
                { PageType.Schedule, Resource.SchedulePageTitle},
                { PageType.Uknown, Resource.PageNotFoundMessage },
            };

        public static string GetPageTitle(PageType pageType)
        {
            var result = pages.TryGetValue(pageType, out string title);

            if (!result)
                return  Resource.PageTitleNotDefined;

            return title;
        }
    }
}
