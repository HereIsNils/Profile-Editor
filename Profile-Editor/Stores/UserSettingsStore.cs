using Profile_Editor.Model;
using System;

namespace Profile_Editor.Stores
{
    internal class UserSettingsStore
    {
        private UserSettings _userSettings;
        public UserSettings userSettings => _userSettings;

        public event Action<UserSettings> UserSettingsCreated;

        public UserSettingsStore(UserSettings settings)
        {

            _userSettings = settings;
        }

        public void CreateUserSettings(UserSettings settings)
        {
            if (settings == null) return;
            _userSettings = settings;
            UserSettingsCreated?.Invoke(settings);
        }
    }
}
