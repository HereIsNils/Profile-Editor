using Profile_Editor.Commands.TimerCommands;
using Profile_Editor.Model;
using Profile_Editor.Stores;
using System;
using System.Windows.Input;

namespace Profile_Editor.ViewModel
{
    internal class TViewModel : BaseViewModel
    {
        public MainViewModel viewModel;

        #region Commands
        public ICommand Timer1Command { get; set; }
        public ICommand Timer2Command { get; set; }
        public ICommand Timer3Command { get; set; }
        public ICommand Timer4Command { get; set; }
        public ICommand Timer5Command { get; set; }
        public ICommand Btn1Command { get; set; }
        public ICommand Btn2Command { get; set; }
        public ICommand Btn3Command { get; set; }
        public ICommand Btn4Command { get; set; }
        public ICommand Btn5Command { get; set; }
        #endregion Commands

        private UserSettingsStore _userSettingsStore;
        public UserSettingsStore UserSettingsStore
        {
            get { return _userSettingsStore; }
            set
            {
                _userSettingsStore = value;
                OnPropertyChanged(nameof(_userSettingsStore));
                
            }
        }

        public UserSettings userSettings { get; set; }


        #region TViewModel Members
        /*------- Sekunden -------*/
        private int _Sek1;
        public int Sek1
        {
            get { return _Sek1; }
            set
            {
                _Sek1 = value;
                OnPropertyChanged(nameof(Sek1));
            }
        }

        private int _Sek2;
        public int Sek2
        {
            get { return _Sek2; }
            set
            {
                _Sek2 = value;
                OnPropertyChanged(nameof(Sek2));
            }
        }

        private int _Sek3;
        public int Sek3
        {
            get { return _Sek3; }
            set
            {
                _Sek3 = value;
                OnPropertyChanged(nameof(Sek3));
            }
        }

        private int _Sek4;
        public int Sek4
        {
            get { return _Sek4; }
            set
            {
                _Sek4 = value;
                OnPropertyChanged(nameof(Sek4));
            }
        }

        private int _Sek5;
        public int Sek5
        {
            get { return _Sek5; }
            set
            {
                _Sek5 = value;
                OnPropertyChanged(nameof(Sek5));
            }
        } 

        /*------- Minuten -------*/
        private int _Min1;
        public int Min1
        {
            get { return _Min1; }
            set
            {
                _Min1 = value;
                OnPropertyChanged(nameof(Min1));
            }
        }

        private int _Min2;
        public int Min2
        {
            get { return _Min2; }
            set
            {
                _Min2 = value;
                OnPropertyChanged(nameof(Min2));
            }
        }

        private int _Min3;
        public int Min3
        {
            get { return _Min3; }
            set
            {
                _Min3 = value;
                OnPropertyChanged(nameof(Min3));
            }
        }

        private int _Min4;
        public int Min4
        {
            get { return _Min4; }
            set
            {
                _Min4 = value;
                OnPropertyChanged(nameof(Min4));
            }
        }

        private int _Min5;
        public int Min5
        {
            get { return _Min5; }
            set
            {
                _Min5 = value;
                OnPropertyChanged(nameof(Min5));
            }
        }

        /*------- Button -------*/
        private bool _Btn1;
        public bool Btn1
        {
            get { return _Btn1; }
            set
            {
                _Btn1 = value;
                OnPropertyChanged(nameof(Btn1));
            }
        }

        private bool _Btn2;
        public bool Btn2
        {
            get { return _Btn2; }
            set
            {
                _Btn2 = value;
                OnPropertyChanged(nameof(Btn2));
            }
        }

        private bool _Btn3;
        public bool Btn3
        {
            get { return _Btn3; }
            set
            {
                _Btn3 = value;
                OnPropertyChanged(nameof(Btn3));
            }
        }

        private bool _Btn4;
        public bool Btn4
        {
            get { return _Btn4; }
            set
            {
                _Btn4 = value;
                OnPropertyChanged(nameof(Btn4));
            }
        }

        private bool _Btn5;
        public bool Btn5
        {
            get { return _Btn5; }
            set
            {
                _Btn5 = value;
                OnPropertyChanged(nameof(Btn5));
            }
        }
        #endregion TViewModel Members

        public TViewModel(UserSettingsStore userSettingsStore, UserSettings userSettings)
        {
            this.userSettings = userSettings;
            _userSettingsStore = userSettingsStore;
            Timer1Command = new Timer1Command(userSettingsStore, this);
            Timer2Command = new Timer2Command(userSettingsStore, this);
            Timer3Command = new Timer3Command(userSettingsStore, this);
            Timer4Command = new Timer4Command(userSettingsStore, this);
            Timer5Command = new Timer5Command(userSettingsStore, this);

            Btn1Command = new Btn1Command(userSettingsStore);
            Btn2Command = new Btn2Command(userSettingsStore);
            Btn3Command = new Btn3Command(userSettingsStore);
            Btn4Command = new Btn4Command(userSettingsStore);
            Btn5Command = new Btn5Command(userSettingsStore);


            _userSettingsStore.UserSettingsCreated += RefreshView;
        }

        private void RefreshView(UserSettings settings)
        {
            if (settings.Timers == null) return;

            Min1 = GetMin(Convert.ToInt32(settings.Timers[0].Timer[0].Interval));
            Sek1 = GetSec(Convert.ToInt32(settings.Timers[0].Timer[0].Interval));
            Btn1 = GetBtn(settings.Timers[0].Timer[0].Direction);

            Min2 = GetMin(Convert.ToInt32(settings.Timers[0].Timer[1].Interval));
            Sek2 = GetSec(Convert.ToInt32(settings.Timers[0].Timer[1].Interval));
            Btn2 = GetBtn(settings.Timers[0].Timer[1].Direction);

            Min3 = GetMin(Convert.ToInt32(settings.Timers[0].Timer[2].Interval));
            Sek3 = GetSec(Convert.ToInt32(settings.Timers[0].Timer[2].Interval));
            Btn3 = GetBtn(settings.Timers[0].Timer[2].Direction);

            Min4 = GetMin(Convert.ToInt32(settings.Timers[0].Timer[3].Interval));
            Sek4 = GetSec(Convert.ToInt32(settings.Timers[0].Timer[3].Interval));
            Btn4 = GetBtn(settings.Timers[0].Timer[3].Direction);

            Min5 = GetMin(Convert.ToInt32(settings.Timers[0].Timer[4].Interval));
            Sek5 = GetSec(Convert.ToInt32(settings.Timers[0].Timer[4].Interval));
            Btn5 = GetBtn(settings.Timers[0].Timer[4].Direction);
        }

        private int GetMin(int i)
        {
            int min, sec;

            sec = i % 60;
            min = i - sec;
            min = min / 60;
            return min;
        }

        private int GetSec(int i)
        {
            int sec;
            sec = i % 60;
            return sec;
        }

        private bool GetBtn(string i)
        {
            if (i == "2") return false;
            return true;
        }

    }
}
