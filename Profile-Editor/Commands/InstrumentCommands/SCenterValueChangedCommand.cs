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
    internal class SCenterValueChangedCommand : ICommand
    {
        private UserSettingsStore userSettingsStore;
        private IViewModel viewModel;

        public SCenterValueChangedCommand(UserSettingsStore userSettingsStore, IViewModel viewModel)
        {
            this.userSettingsStore = userSettingsStore;
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            int i = viewModel.HolderIndex;
            //userSettingsStore.userSettings.Instruments[appLvl].Instrument[i].Center = parameter.toString();
            throw new NotImplementedException();
        }
    }
}
