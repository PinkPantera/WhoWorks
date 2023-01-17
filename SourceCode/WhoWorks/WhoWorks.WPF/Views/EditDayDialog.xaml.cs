using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WhoWorks.WPF.Interfaces;

namespace WhoWorks.WPF.Views
{
    /// <summary>
    /// Interaction logic for EditDayDialog.xaml
    /// </summary>
    public partial class EditDayDialog : Window, IDialog
    {
        public EditDayDialog()
        {
            InitializeComponent();
        }
    }
}
