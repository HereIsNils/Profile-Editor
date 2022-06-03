using Microsoft.Win32;
using Profile_Editor.Model;
using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Profile_Editor.Commands
{
    internal class ImportXmlCommand : ICommand
    {
        private readonly UserSettingsStore _userSettingsStore;
        private readonly MainViewModel mainViewModel;

        public ImportXmlCommand(UserSettingsStore userSettingsStore, MainViewModel mainViewModel)
        {
            _userSettingsStore = userSettingsStore;
            this.mainViewModel=mainViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string filepath = "";
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = Environment.CurrentDirectory;
            fd.Filter = "xml files (*.xml)|*.xml";
            fd.RestoreDirectory = true;

            if (fd.ShowDialog() == true)
            {
                filepath = fd.FileName;
                if (filepath == "")
                {
                    return;
                }
            } else
            {
                return; // return if explorer gets closed or cancel gets selected
            }
            mainViewModel.CurrentPath = filepath;
            createObj(filepath);
            mainViewModel.IsEnabled = true;
        }

        public void createObj(string path)
        {
            
            XmlSerializer serializer = new XmlSerializer(typeof(UserSettings));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                if (fs == null | serializer == null) return;
                UserSettings userSettings = (UserSettings)serializer.Deserialize(fs);

                if(userSettings == null) return;
                _userSettingsStore.CreateUserSettings(userSettings);
            }
        }
    }
}
