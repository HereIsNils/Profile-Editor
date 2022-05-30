using Profile_Editor.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands.LedLightCommands
{
    internal class IntensityCommand : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }

        public event EventHandler? CanExecuteChanged;

        public IntensityCommand(UserSettingsStore userSettingsStore)
        {
            this.userSettingsStore = userSettingsStore;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.LedLight[0].Intensity = parameter.ToString();
        }
    }
}
