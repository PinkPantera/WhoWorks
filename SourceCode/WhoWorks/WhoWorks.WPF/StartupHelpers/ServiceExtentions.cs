using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.WPF.Common;
using WhoWorks.WPF.Interfaces;
using WhoWorks.WPF.Providers;
using WhoWorks.WPF.ViewModels;

namespace WhoWorks.WPF.StartupHelpers
{
    public delegate IPage ServicePageResolver(PageType pageType);

    public static class ServiceExtentions
    {
        public static void AddPageProvider(this IServiceCollection services)
        {
            services.AddSingleton<IPageProvider, PageProvider>();
            services.AddTransient<EmptyPageVeiwModel>();
            services.AddTransient<HomePageViewModel>();
            services.AddTransient<PersonsPageViewModel>();
            services.AddTransient<SettingsPageViewModel>();

            services.AddTransient<ServicePageResolver>(serviceProvider => pageType =>
            {
                switch (pageType)
                {
                    case PageType.Home:
                        return serviceProvider.GetService<HomePageViewModel>();
                    case PageType.Persons:
                        return serviceProvider.GetService<PersonsPageViewModel>();
                   case PageType.Settings:
                        return serviceProvider.GetService<SettingsPageViewModel>();

                    default: 
                        return serviceProvider.GetRequiredService<EmptyPageVeiwModel>();

                }
            });
        }
    }
}
