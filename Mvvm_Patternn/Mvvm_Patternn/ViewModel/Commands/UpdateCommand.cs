using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mvvm_Patternn.ViewModel.Commands
{
    public class UpdateCommand : ICommand
    {
        object viewModel;

        public UpdateCommand(object viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            object[] parameters = { parameter };
            this.viewModel.GetType().GetMethod("UpdateData").Invoke(this.viewModel, parameters);
        }
    }
}
