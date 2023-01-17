using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoWorks.WPF.Common;
using WhoWorks.WPF.Interfaces;
using WhoWorks.WPF.Views;

namespace WhoWorks.WPF.Providers
{
    public class DialogProvider : IDialogService
    {
        public object ShowDialog<TViewModel>(object obj) where TViewModel : IClosable
        {
            var viewModel =  Activator.CreateInstance(typeof(TViewModel));

            if (viewModel is IInitializable)
            {
                ((IInitializable)viewModel).Initialize(obj);
            }

            ViewModelDialog viewModelDialog = new (viewModel as IClosable, (IDialog)Activator.CreateInstance(typeof(EditDayDialog)));
            object? result = null;

            EventHandler<DialogCloseEventArgs>? handler = null;
            handler = (sender, e) =>
            {
                if (viewModelDialog.ViewModel.CanClose())
                {
                    viewModelDialog.ViewModel.CloseRequested -= handler;
                    result = e.Result;
                   viewModelDialog.Dialog.Close();
                }
            };


            viewModelDialog.ViewModel.CloseRequested += handler;
            viewModelDialog.Dialog.DataContext = viewModelDialog.ViewModel;
            viewModelDialog.Dialog.ShowDialog();

            return obj;
        }
    }
}
