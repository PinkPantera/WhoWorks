using ClientDataService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.WPF.Interfaces;

namespace WhoWorks.WPF.ApiSettings
{
    internal class WebApiSettings : IWebApiSettings
    {
        public WebApiSettings(ISettingsManager settingsManager)
        {
            GetUrl = settingsManager.WebApiUrl;
        }

        public string GetUrl { get; }
    }
}
