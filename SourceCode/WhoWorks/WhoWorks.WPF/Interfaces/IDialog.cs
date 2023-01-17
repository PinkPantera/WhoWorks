using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.WPF.Interfaces
{
    public interface IDialog
    {
        object DataContext { get; set; }
        bool? DialogResult { get; set; }
        void Close();
        bool? ShowDialog();
    }
}
