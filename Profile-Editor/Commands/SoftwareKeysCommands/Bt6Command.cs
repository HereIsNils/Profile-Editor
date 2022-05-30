using Profile_Editor.Stores;
using System;
using System.Windows.Input;

namespace Profile_Editor.Commands.SoftwareKeysCommands
{
    internal class Bt6Command : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        public event EventHandler? CanExecuteChanged;

        public Bt6Command(UserSettingsStore userSettingsStore)
        {
            this.userSettingsStore = userSettingsStore;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.SoftKeys[0].SoftKey6 = parameter.ToString();
        }
    }
}
