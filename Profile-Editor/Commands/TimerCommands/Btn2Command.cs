using Profile_Editor.Stores;
using System;
using System.Windows.Input;

namespace Profile_Editor.Commands.TimerCommands
{

    internal class Btn2Command : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        public event EventHandler? CanExecuteChanged;

        public Btn2Command(UserSettingsStore userSettingsStore)
        {
            this.userSettingsStore = userSettingsStore;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string direction = "2";
            if (Convert.ToBoolean(parameter))
            {
                direction = "1";
                userSettingsStore.userSettings.Timers[0].Timer[1].Direction = direction;
                return;
            }
            userSettingsStore.userSettings.Timers[0].Timer[1].Direction = direction;
        }
    }
}
