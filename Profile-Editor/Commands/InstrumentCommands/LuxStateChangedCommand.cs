using Profile_Editor.Model;
using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands.InstrumentCommands
{
    internal class LuxStateChangedCommand : ICommand
    {
        private UserSettingsStore userSettingsStore;
        private IViewModel viewModel;

        public LuxStateChangedCommand(UserSettingsStore userSettingsStore, IViewModel viewModel)
        {
            this.userSettingsStore = userSettingsStore;
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string lux = GetLux();
            Instrument instrument = viewModel.GetLevel(userSettingsStore.userSettings);
            instrument.Lux = lux;
        }

        private string GetLux()
        {
            string lux = "12"; // level 1, lux off

            string level = viewModel.LuxLevel.ToString();

            if(viewModel.LuxState == true)
            {
                lux = $"{level}1";
                viewModel.LuxLevelEnabled = true;
            }
            else
            {
                lux = $"{level}2";
                viewModel.LuxLevelEnabled = false;
            }

            string luxConverted = HexToString(lux);
            return luxConverted;
        }

        /// <summary>
        /// Takes a byte, converts it to an integer and returns it as string
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        private string HexToString(string mode)
        {
            int value = Convert.ToInt32(mode, 16);
            return value.ToString();
        }
    }
}
