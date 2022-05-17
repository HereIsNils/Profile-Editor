using Microsoft.Win32;
using Profile_Editor.Model;
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
         
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string filepath = "";
            UserSettings userSettings = new UserSettings();
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = Environment.CurrentDirectory;
            fd.Filter = "xml files (*.xml)|*.xml";
            fd.RestoreDirectory = true;

            if (fd.ShowDialog() == true)
            {
                filepath = fd.FileName;
                if (string.IsNullOrEmpty(filepath))
                {
                    return;
                }
            }
            userSettings = createObj(filepath);
        }

        public UserSettings createObj(string path)
        { 
            XmlSerializer serializer = new XmlSerializer(typeof(UserSettings));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                UserSettings userSettings = (UserSettings) serializer.Deserialize(fs);
                return userSettings;
            }
        }
    }
}
