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
    internal class SeatCorrectionCommand : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        public CPViewModel CPViewModel { get; }

        private int i;

        public SeatCorrectionCommand(UserSettingsStore userSettingsStore, CPViewModel cPViewModel, int i)
        {
            this.userSettingsStore = userSettingsStore;
            CPViewModel = cPViewModel;
            this.i = i;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis3 = CPViewModel.Axis3.ToString();
        }
    }
}
