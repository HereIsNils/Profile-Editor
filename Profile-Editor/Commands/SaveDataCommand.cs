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
            FileStream fs = null;
            StringWriter sw = new StringWriter();

            File.WriteAllText(path, String.Empty);

            writer.Serialize(sw, userSettingsStore.userSettings);
            xmlString = sw.ToString();

            string xmlFormatted = PrettyXml(xmlString);

            fs = new FileStream(path, FileMode.Append);
            StreamWriter stream = new StreamWriter(fs);
            stream.Write(xmlFormatted);
            stream.Close();
        }

        private string PrettyXml(string xml)
        {
            string result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                document.LoadXml(xml);

                writer.Formatting = Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                string formattedXml = sReader.ReadToEnd();

                result = formattedXml;
            }
            catch (XmlException)
            {
                // Handle the exception
            }

            mStream.Close();
            writer.Close();

            return result;
        }
    }
}
