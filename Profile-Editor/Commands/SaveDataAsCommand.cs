using Microsoft.Win32;
using Profile_Editor.Model;
using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Profile_Editor.Commands
{
    internal class SaveDataAsCommand : ICommand
    {
        private UserSettingsStore userSettingsStore;
        private readonly MainViewModel mainViewModel;

        public SaveDataAsCommand(UserSettingsStore userSettingsStore, MainViewModel mainViewModel)
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

            string filepath = "";
            SaveFileDialog fd = new SaveFileDialog();
            fd.InitialDirectory = path;
            fd.Filter = "xml files (*.xml)|*.xml";
            fd.RestoreDirectory = true;

            if (fd.ShowDialog() == true)
            {
                filepath = fd.FileName;
                if (filepath == "")
                {
                    return;
                }
            }
            else
            {
                return; // return if explorer gets closed or cancel gets selected
            }
            System.IO.FileStream file = System.IO.File.OpenWrite(filepath);
            writer.Serialize(file, userSettingsStore.userSettings);
            file.Close();
        }
    }
}
