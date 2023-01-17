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
    public class EditDayViewModel : ViewModelBase, IClosable, IInitializable
    {
        public EditDayViewModel()
        {
            CloseWindowCommand = new RalayCommand<object>(CloseWindowCommandExecute);
        }

        public Day DayToEdit { get; set; }

        public ICommand CloseWindowCommand { get; set; }

        public event EventHandler<DialogCloseEventArgs> CloseRequested;

        public bool CanClose()
        {
            return true;
        }

        public void Initialize(object obj)
        {
            DayToEdit = (Day)obj;
        }

        private void CloseWindowCommandExecute(object obj)
        {
            var tmp = "TEST";
            CloseRequested?.Invoke(this, new DialogCloseEventArgs(tmp));
        }
    }
}
