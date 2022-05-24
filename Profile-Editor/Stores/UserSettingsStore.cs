using Profile_Editor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile_Editor.Stores
{
    internal class UserSettingsStore
    {
        private UserSettings _userSettings;
        public UserSettings userSettings => _userSettings;

        public event Action<UserSettings> UserSettingsCreated;

        public UserSettingsStore()
        {

            _userSettings = new UserSettings();
        }

        public void CreateUserSettings(UserSettings settings)
        {
            if(settings == null) return;
            _userSettings = settings;
        }
    }
}
