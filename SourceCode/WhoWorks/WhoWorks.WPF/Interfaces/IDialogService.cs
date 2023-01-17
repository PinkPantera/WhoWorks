using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.WPF.Interfaces
{
    public interface IDialogService
    {
        object ShowDialog<TViewModel>(object obj) where TViewModel : IClosable;
    }
}
