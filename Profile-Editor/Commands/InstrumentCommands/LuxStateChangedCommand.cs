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
            userSettingsStore.userSettings.Instruments[viewModel.AppLevelIndex].Instrument[viewModel.HolderIndex].Lux = lux;
        }

        private string GetLux()
        {
            string lux = "11"; // level 1, lux off

            string level = viewModel.LuxLevel.ToString();

            if(viewModel.LuxState == true)
            {
                lux = $"2{level}";
            }
            else
            {
                lux = $"1{level}";
                viewModel.LuxLevelEnabled = false;
            }

            string luxConverted = ConvertByteToDecString(Convert.ToByte(lux));
            return luxConverted;
        }

        /// <summary>
        /// Takes a byte, converts it to an integer and returns it as string
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        private string ConvertByteToDecString(byte mode)
        {
            int value = (Int32)mode;
            return value.ToString();
        }
    }
}
