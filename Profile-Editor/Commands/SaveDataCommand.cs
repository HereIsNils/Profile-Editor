using Profile_Editor.Model;
using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.IO;
using System.Text;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
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
            this.mainViewModel = mainViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string xmlString;
            string path = mainViewModel.CurrentPath;
            XmlSerializer writer = new XmlSerializer(typeof(UserSettings));
            StringWriter sw = new StringWriter();

            writer.Serialize(sw, userSettingsStore.userSettings);
            xmlString = sw.ToString();

            string xmlFormatted = PrettyXml(xmlString);


            FileStream file = File.OpenWrite(path);
            writer.Serialize(file, xmlFormatted);
            file.Close();
        }

        private string PrettyXml(string xml)
        {
            var stringBuilder = new StringBuilder();

            var element = XElement.Parse(xml);

            var settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                element.Save(xmlWriter);
            }

            return stringBuilder.ToString();
        }
    }
}
