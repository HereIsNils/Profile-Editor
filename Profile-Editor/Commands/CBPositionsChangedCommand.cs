using Profile_Editor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands
{
    internal class CBPositionsChangedCommand : ICommand
    {
        public CPViewModel _cpViewModel;
        public event EventHandler? CanExecuteChanged;

        public CBPositionsChangedCommand(CPViewModel cpViewModel)
        {
            _cpViewModel = cpViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            
        }
    }
}
