using Profile_Editor.Commands.VariousCommands;
using Profile_Editor.Model;
using Profile_Editor.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.ViewModel
{
    internal class VViewModel : BaseViewModel
    {
        MainViewModel mainViewModel;
        public ICommand LanguageChangeCommand { get; set; }

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

        public VViewModel(UserSettingsStore userSettingsStore, UserSettings userSettings)
        {
            UserSettingsStore = userSettingsStore;
            this.userSettings = userSettings;
            LanguageChangeCommand = new LanguageChangeCommand(userSettingsStore, this);
        }
    }
}
