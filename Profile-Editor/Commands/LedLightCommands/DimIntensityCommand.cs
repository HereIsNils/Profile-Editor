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
    internal class DimIntensityCommand : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        public LLViewModel ViewModel { get; }

        public event EventHandler? CanExecuteChanged;

        public DimIntensityCommand(UserSettingsStore userSettingsStore, LLViewModel viewModel)
        {
            this.userSettingsStore = userSettingsStore;
            ViewModel = viewModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.LedLight[0].DimIntensity = ViewModel.DimIntensity.ToString();
        }
    }
}
