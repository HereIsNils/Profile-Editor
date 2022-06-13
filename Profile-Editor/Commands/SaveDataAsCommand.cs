using Microsoft.Win32;
using Profile_Editor.Model;
using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Windows.Input;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

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
            string xmlString;
            string path = mainViewModel.CurrentPath;
            XmlSerializer writer = new XmlSerializer(typeof(UserSettings));
            FileStream fs = null;

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

            StringWriter sw = new StringWriter();

            writer.Serialize(sw, userSettingsStore.userSettings);
            xmlString = sw.ToString();

            string xmlFormatted = PrettyXml(xmlString);
            
            fs = new FileStream(filepath, FileMode.Create);
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
