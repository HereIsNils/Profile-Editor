using Profile_Editor.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands.LedLightCommands
{
    internal class DimIntensityCommand : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        public event EventHandler? CanExecuteChanged;

        public DimIntensityCommand(UserSettingsStore userSettingsStore)
        {
            this.userSettingsStore = userSettingsStore;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.LedLight[0].DimIntensity = parameter.ToString();
        }
    }
}
