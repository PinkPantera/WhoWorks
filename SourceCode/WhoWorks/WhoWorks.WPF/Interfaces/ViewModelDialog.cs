using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.WPF.Interfaces
{
    public record ViewModelDialog(IClosable ViewModel, IDialog Dialog);

}
