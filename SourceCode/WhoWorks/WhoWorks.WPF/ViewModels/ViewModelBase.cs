using WhoWorks.WPF.Common;

namespace WhoWorks.WPF.ViewModels
{
    public class ViewModelBase : NotifyPropertyChangedBase
    {
        private string title =  string.Empty;

        public string Title
        {
            get => title;
            set
            {
                SetProprty(ref title, value);
            }
        }
    }
}
