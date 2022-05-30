using Profile_Editor.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands
{
    internal class BackHeightCommand : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }

        public event EventHandler? CanExecuteChanged;
        private int i;

        public BackHeightCommand(UserSettingsStore userSettingsStore, int i)
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
            userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis2 = parameter.ToString();
        }
    }
}
