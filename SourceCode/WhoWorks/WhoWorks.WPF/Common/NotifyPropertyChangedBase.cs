using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WhoWorks.WPF.Common
{
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetProprty<T>(ref T field, T value, [CallerMemberName] string? propertyName=null)
        {
            bool propertyChanged = false;

            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                propertyChanged = true;
                OnPropertyChanged(propertyName);
            }

            return propertyChanged;
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName=null)
        {
            PropertyChanged ?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
