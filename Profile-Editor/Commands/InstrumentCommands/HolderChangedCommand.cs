using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands.InstrumentCommands
{
    internal class HolderChangedCommand : ICommand
    {
        private IViewModel viewModel;

        public HolderChangedCommand(IViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            //viewModel.HolderIndex = Convert.ToInt32(parameter);
            viewModel.RefreshView(viewModel.UserSettingsStore.userSettings);
        }
    }
}
