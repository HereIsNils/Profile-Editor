using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Windows.Input;

namespace Profile_Editor.Commands.ChairPositionCommands
{
    internal class ChairHeightCommand : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        public CPViewModel CPViewModel { get; }

        public event EventHandler? CanExecuteChanged;

        public ChairHeightCommand(UserSettingsStore userSettingsStore, CPViewModel cPViewModel)
        {
            this.userSettingsStore = userSettingsStore;
            CPViewModel = cPViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.ChairPositions[0].ChairPosition[Convert.ToInt32(parameter)].Axis1 = CPViewModel.Axis1.ToString();
        }
    }
}
