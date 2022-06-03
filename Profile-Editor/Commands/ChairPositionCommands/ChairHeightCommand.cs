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
        private int i;

        private UserSettingsStore userSettingsStore { get; }
        public CPViewModel CPViewModel { get; }

        public event EventHandler? CanExecuteChanged;

        public ChairHeightCommand(UserSettingsStore userSettingsStore, CPViewModel cPViewModel, int i)
        {
            this.userSettingsStore = userSettingsStore;
            CPViewModel = cPViewModel;
            this.i = i;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis1 = CPViewModel.Axis1.ToString();
        }
    }
}
