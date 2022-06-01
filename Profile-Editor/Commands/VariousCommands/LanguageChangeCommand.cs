using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands.VariousCommands
{
    internal class LanguageChangeCommand : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        private VViewModel vViewModel { get; }

        public event EventHandler? CanExecuteChanged;

        public LanguageChangeCommand(UserSettingsStore userSettingsStore, VViewModel vViewModel)
        {
            this.userSettingsStore = userSettingsStore;
            this.vViewModel = vViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.Various[0].Language = parameter.ToString();
        }
    }
}
