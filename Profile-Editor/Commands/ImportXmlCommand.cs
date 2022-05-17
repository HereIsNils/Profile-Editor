using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

            DataSet ds = new DataSet();
            ds.ReadXml(filepath);
            DataView bla = ds.Tables[0].DefaultView;
        }
    }
}
