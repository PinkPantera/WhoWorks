using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

            await DalayAndReturnAsync(10);

            CheckConnectionResult = "Successful";

        }
        #endregion

        private async Task<int> DalayAndReturnAsync(int value)
        {
            await Task.Delay(TimeSpan.FromSeconds(value));
            return value;
        }

    }
}
