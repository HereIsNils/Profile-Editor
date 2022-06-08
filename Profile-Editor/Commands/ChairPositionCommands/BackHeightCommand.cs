using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Windows.Input;

namespace Profile_Editor.Commands
{
    internal class BackHeightCommand : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        public CPViewModel CPViewModel { get; }

        public event EventHandler? CanExecuteChanged;

        public BackHeightCommand(UserSettingsStore userSettingsStore, CPViewModel cPViewModel)
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
            userSettingsStore.userSettings.ChairPositions[0].ChairPosition[Convert.ToInt32(parameter)].Axis2 = CPViewModel.Axis2.ToString();
        }
    }
}
