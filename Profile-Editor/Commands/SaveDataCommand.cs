using Profile_Editor.Model;
using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Profile_Editor.Commands
{
    internal class SaveDataCommand : ICommand
    {
        private UserSettingsStore userSettingsStore;
        private readonly MainViewModel mainViewModel;

        public SaveDataCommand(UserSettingsStore userSettingsStore, MainViewModel mainViewModel)
        {
            this.userSettingsStore = userSettingsStore;
            this.mainViewModel=mainViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string path = mainViewModel.CurrentPath;
            XmlSerializer writer = new XmlSerializer(typeof(UserSettings));
            
            System.IO.File.WriteAllText(path, string.Empty);
            System.IO.FileStream file = System.IO.File.OpenWrite(path);
            writer.Serialize(file, userSettingsStore.userSettings);
            file.Close();
        }
    }
}
