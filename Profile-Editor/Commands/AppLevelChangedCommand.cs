using Profile_Editor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands
{
    internal class AppLevelChangedCommand : ICommand
    {
        private IViewModel iViewModel;

        public AppLevelChangedCommand(IViewModel iViewModel)
        {
            this.iViewModel = iViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            iViewModel.AppLevel = parameter.ToString();
        }
    }
}
