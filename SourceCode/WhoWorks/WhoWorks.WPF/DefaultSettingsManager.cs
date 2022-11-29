using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.WPF.Interfaces;

namespace WhoWorks.WPF
{
    internal class DefaultSettingsManager : ISettingsManager
    {
        private readonly Properties.Settings settings = Properties.Settings.Default;

        public DefaultSettingsManager()
        {
            Load();
        }
        public string WebApiUrl { get; set; } = string.Empty;

        public void Load()
        {
            WebApiUrl = settings.WebApiUrl;
        }

        public void Save()
        {
            settings.WebApiUrl = WebApiUrl;

            settings.Save();
        }
    }
}
