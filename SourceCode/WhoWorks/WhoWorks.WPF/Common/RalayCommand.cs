using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WhoWorks.WPF.Common
{
    public class RalayCommand<T> : ICommand
    {
        private Predicate<T>? canExecute = null;
        private readonly Action<T> execute;

        public RalayCommand(Action<T> execute, Predicate<T>? canExecute = null)
        {
            if (execute == null)
                throw new ArgumentNullException("Execute");
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public RalayCommand(Action<T> execute)
            : this(execute, null) { }


        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute((T)parameter);
        }

        public void Execute(object? parameter)
        {
            execute((T)parameter);
        }
    }
}
