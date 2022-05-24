using Profile_Editor.Model;
using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands.ChairPositionCommands
{
    internal class ChairHeightCommand : ICommand
    {
        private readonly MainViewModel _mainViewModel;

        private UserSettingsStore userSettingsStore { get; }

        public event EventHandler? CanExecuteChanged;

        public ChairHeightCommand(UserSettingsStore userSettingsStore)
        {
            this.userSettingsStore = userSettingsStore;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.ChairPositions[0].ChairPosition[0].Axis1 = parameter.ToString();
        }
    }
}
