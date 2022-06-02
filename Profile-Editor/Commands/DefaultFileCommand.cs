using Microsoft.Win32;
using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands
{
    internal class DefaultFileCommand : ICommand
    {
        private UserSettingsStore userSettingsStore;
        private MainViewModel mainViewModel;

        public DefaultFileCommand(UserSettingsStore userSettingsStore, MainViewModel mainViewModel)
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
            OpenFileDialog fd = new OpenFileDialog();
            fd.InitialDirectory = Environment.CurrentDirectory;
            fd.Filter = "xml files (*.xml)|*.xml";
            fd.RestoreDirectory = true;

            if (fd.ShowDialog() == true)
            {
                mainViewModel.DefaultPath = fd.FileName;
            }
            else
            {
                // return if explorer gets closed or cancel gets selected
                return;
            }
        }
    }
}
