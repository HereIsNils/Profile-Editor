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
        public ICommand ShowHelp { get; set; }

        private int _Index;
        public int Index
        {
            get { return _Index; }
            set { _Index = value; OnPropertyChanged(nameof(Index)); }
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

        public VViewModel(UserSettingsStore userSettingsStore, UserSettings userSettings)
        {
            LanguageChangeCommand = new LanguageChangeCommand(userSettingsStore, this);
            ShowHelp = new ShowHelp();

            UserSettingsStore = userSettingsStore;
            this.userSettings = userSettings;

            _userSettingsStore.UserSettingsCreated += RefreshView;
        }

        private void RefreshView(UserSettings settings)
        {
            Index = Convert.ToInt32(settings.Various[0].Language);
        }
    }
}
