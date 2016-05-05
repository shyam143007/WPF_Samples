using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mvvm_Patternn.ViewModel.Commands
{
    public class AddDelegateCommand : ICommand
    {
        Func<object, bool> _canExecute;
        Action<object> _Execute;

        public AddDelegateCommand(Action<object> execute) : this(execute, null)
        {

        }

        public AddDelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _Execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }
    }
}
