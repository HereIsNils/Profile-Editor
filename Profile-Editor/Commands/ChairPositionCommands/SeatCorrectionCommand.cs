using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Windows.Input;

namespace Profile_Editor.Commands.ChairPositionCommands
{
    internal class SeatCorrectionCommand : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        public CPViewModel CPViewModel { get; }

        public SeatCorrectionCommand(UserSettingsStore userSettingsStore, CPViewModel cPViewModel)
        {
            this.userSettingsStore = userSettingsStore;
            CPViewModel = cPViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.ChairPositions[0].ChairPosition[Convert.ToInt32(parameter)].Axis3 = CPViewModel.Axis3.ToString();
        }
    }
}
