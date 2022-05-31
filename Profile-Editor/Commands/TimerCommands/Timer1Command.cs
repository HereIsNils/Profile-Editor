using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands.TimerCommands
{
    internal class Timer1Command : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        private int seconds = 0;
        private int minutes = 0;
        private bool timer = true;

        public event EventHandler? CanExecuteChanged;

        public Timer1Command(UserSettingsStore userSettingsStore, int seconds, int minutes, bool timer)
        {
            this.seconds = seconds;
            this.minutes = minutes;
            this.timer = timer;
        }


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            int min = GetMin(minutes);
            int sec = min + seconds;
            string dir = "1";

            if (timer)
            {
                dir = "2";
            }

            userSettingsStore.userSettings.Timers[0].Timer[0].Interval = sec.ToString();
            userSettingsStore.userSettings.Timers[0].Timer[0].Direction = dir;
        }

        private int GetMin(int min)
        {
            int sec =0;
            int i = 0;
            while (min <= i)
            {
                sec = sec + 60;
                ++i;
            }
            return sec;
        }
    }
}
