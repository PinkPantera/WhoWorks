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
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IPageProvider pageProvider;
        private IPage selectedPage;
       
        public MainWindowViewModel(IPageProvider pageProvider)
        {
            Title = Resource.MainWindowTitle;
            this.pageProvider = pageProvider;
            SelectedPage = pageProvider.GetPage(PageType.Home);
            MenuCommand = new RalayCommand<PageType>(MenuCommandExecute);
        }

        public IPage SelectedPage
        {
            get => selectedPage;
            set
            {
                SetProprty(ref selectedPage, value);
            }
        }

        public ICommand MenuCommand { get; }


        #region Command
        private void MenuCommandExecute(PageType pageType)
        {
            if (pageType == PageType.Uknown || SelectedPage.PageType == pageType)
             return;

            SelectedPage = pageProvider.GetPage(pageType);
            SelectedPage.Refreshe();
        }

        #endregion
    }
}
