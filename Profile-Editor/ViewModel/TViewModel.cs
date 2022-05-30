using Profile_Editor.Model;
using Profile_Editor.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile_Editor.ViewModel
{
    internal class TViewModel : BaseViewModel
    {
        public MainViewModel viewModel;

        private int _Sek1;
        public int Sek1
        {
            get { return _Sek1; }
            set 
            { 
                _Sek1 = value; 
                OnPropertyChanged(nameof(_Sek1));
            }
        }

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

        public TViewModel(UserSettingsStore userSettingsStore, UserSettings userSettings)
        {
            this.userSettings = userSettings;
            _userSettingsStore = userSettingsStore;
            _userSettingsStore.UserSettingsCreated += UpdateSettings;

            UpdateTimers();
        }

        private void UpdateSettings(UserSettings settings)
        {
            TViewModel vm = new TViewModel(_userSettingsStore, settings);
            
        }

        public void UpdateTimers()
        {
            if (_userSettingsStore.userSettings.Timers == null) return;
            Sek1 = Convert.ToInt32(_userSettingsStore.userSettings.Timers[0].Timer[0].Interval);
        }
    }
}
