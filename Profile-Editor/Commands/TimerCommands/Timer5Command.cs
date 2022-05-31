using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Windows.Input;

namespace Profile_Editor.Commands.TimerCommands
{
    internal class Timer5Command : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        private TViewModel tViewModel { get; }

        public event EventHandler? CanExecuteChanged;

        public Timer5Command(UserSettingsStore userSettingsStore, TViewModel tViewModel)
        {
            this.userSettingsStore = userSettingsStore;
            this.tViewModel = tViewModel;
        }


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            int min = GetMin(tViewModel.Min5);
            int sec = min + tViewModel.Sek5;
            string dir = "1";

            if (tViewModel.Btn5)
            {
                dir = "2";
            }

            userSettingsStore.userSettings.Timers[0].Timer[4].Interval = sec.ToString();
            userSettingsStore.userSettings.Timers[0].Timer[4].Direction = dir;
        }

        private int GetMin(int min)
        {
            int sec = 0;
            int i = 0;
            while (min > i)
            {
                sec = sec + 60;
                ++i;
            }
            return sec;
        }
    }
}
