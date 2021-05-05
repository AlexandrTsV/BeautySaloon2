using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BeautySaloon.Views
{
    public class DelegateCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action<object> execute)
        {
            this.execute = execute;
            canExecute = AlwaysCanExecute;
        }

        public void Execute(object param)
        {
            execute(param);
        }

        public bool CanExecute(object param)
        {
            return canExecute(param);
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private bool AlwaysCanExecute(object param)
        {
            return true;
        }
    }
}
