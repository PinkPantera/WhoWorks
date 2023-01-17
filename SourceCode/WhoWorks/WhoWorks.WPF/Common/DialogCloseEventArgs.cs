using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.WPF.Common
{
    public class DialogCloseEventArgs : EventArgs
    {
        public DialogCloseEventArgs(object result) => Result = result;
        public object Result { get; }

    }


}
