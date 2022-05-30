using Profile_Editor.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands.LedLightCommands
{
    internal class ColorTempCommand : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        public event EventHandler? CanExecuteChanged;

        public ColorTempCommand(UserSettingsStore store)
        {
            userSettingsStore = store;
        }

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.LedLight[0].ColorTemperature = parameter.ToString();
        }
    }
}
