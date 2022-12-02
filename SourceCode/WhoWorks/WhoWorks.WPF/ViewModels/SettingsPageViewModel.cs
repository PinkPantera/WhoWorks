using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WhoWorks.Core.Diagnostic;
using WhoWorks.WPF.ApiSettings;
using WhoWorks.WPF.Common;
using WhoWorks.WPF.Interfaces;

namespace WhoWorks.WPF.ViewModels
{
    internal class SettingsPageViewModel : ViewModelBasePage
    {
        private readonly ISettingsManager settingsManager;
        private string webApiUrl = string.Empty;
        private string checkConnectionResult;

        public SettingsPageViewModel(ISettingsManager settingsManager)
            : base(PageType.Settings)
        {
            this.settingsManager = settingsManager;
            WebApiUrl = settingsManager.WebApiUrl;

            CheckConnectionCommand = new RalayCommand<object>(CheckConnectionCommandExecute);
        }

        public string WebApiUrl
        {
            get { return webApiUrl; }
            set
            {
                SetProprty(ref webApiUrl, value);
            }
        }

        public string CheckConnectionResult
        {
            get => checkConnectionResult;
            set
            {
                SetProprty(ref checkConnectionResult, value);
            }
        }

        public ICommand CheckConnectionCommand { get; }

        #region Commands
        private async void CheckConnectionCommandExecute(object obj)
        {
            CheckConnectionResult = "Try to Connect...";

            var requestUri = $"{WebApiUrl}/health";
            try
            {
                var serverHealthInformation = await ApiServerDiagnostic.GetServerHealthInformationAsync(requestUri);
                CheckConnectionResult = serverHealthInformation.Status;

            }
            catch(Exception ex)
            {
                CheckConnectionResult = ex.Message;
            }
        }


        #endregion
    }
}
