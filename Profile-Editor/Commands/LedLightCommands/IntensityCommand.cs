using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands.LedLightCommands
{
    internal class IntensityCommand : ICommand
    {
        private LLViewModel viewModel;

        private UserSettingsStore userSettingsStore { get; }

        public event EventHandler? CanExecuteChanged;

        public IntensityCommand(UserSettingsStore userSettingsStore, LLViewModel viewModel)
        {
            this.userSettingsStore = userSettingsStore;
            this.viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.LedLight[0].Intensity = viewModel.Intensity.ToString();
        }
    }
}
