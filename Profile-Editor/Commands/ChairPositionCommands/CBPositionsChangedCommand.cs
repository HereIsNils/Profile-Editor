using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Windows.Input;

namespace Profile_Editor.Commands
{
    internal class CBPositionsChangedCommand : ICommand
    {
        public CPViewModel cpViewModel;
        private UserSettingsStore _userSettingsStore;

        public event EventHandler? CanExecuteChanged;

        public CBPositionsChangedCommand(CPViewModel cpViewModel, UserSettingsStore userSettingsStore)
        {
            this.cpViewModel = cpViewModel;
            _userSettingsStore = userSettingsStore;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            int i = Convert.ToInt32(parameter);
            cpViewModel.Axis1 = Convert.ToDouble(_userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis1);
            cpViewModel.Axis2 = Convert.ToDouble(_userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis2);
            cpViewModel.Axis3 = Convert.ToDouble(_userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis3);
            cpViewModel.Axis4 = Convert.ToDouble(_userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis4);
            cpViewModel.Axis5 = Convert.ToDouble(_userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis5);
            cpViewModel.Axis6 = Convert.ToDouble(_userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis6);
        }
    }
}
