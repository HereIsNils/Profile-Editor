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
        private UserSettingsStore userSettingsStore { get; }
        private int i;

        public event EventHandler? CanExecuteChanged;

        public ChairHeightCommand(UserSettingsStore userSettingsStore, int i)
        {
            this.userSettingsStore = userSettingsStore;
            this.i = i;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis1 = parameter.ToString();
        }
    }
}
