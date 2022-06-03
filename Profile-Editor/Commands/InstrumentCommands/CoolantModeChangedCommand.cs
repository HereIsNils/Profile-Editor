using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands.InstrumentCommands
{
    internal class CoolantModeChangedCommand : ICommand
    {
        private UserSettingsStore userSettingsStore;
        private IViewModel viewModel;

        public CoolantModeChangedCommand(UserSettingsStore userSettingsStore, IViewModel viewModel)
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
            string coolantMode = GetCoolantMode();
            userSettingsStore.userSettings.Instruments[viewModel.AppLevelIndex].Instrument[viewModel.HolderIndex].CoolantMode = coolantMode;
        }

        private string GetCoolantMode()
        {
            byte mode = 0x11;

            if (viewModel.NaclState)
            {
                if (viewModel.CoolantState)
                {
                    if (viewModel.Aircooling)
                    {
                        mode = 0x22;
                        return ConvertToString(mode);
                    }
                    if (viewModel.AirWatercooling)
                    {
                        mode = 0x23;
                        return ConvertToString(mode);
                    }
                    if (viewModel.Naclcooling)
                    {
                        mode = 0x24;
                        return ConvertToString(mode);
                    }
                }
                mode = 0x21;
                return ConvertToString(mode);
            }
            else if (viewModel.CoolantState)
            {
                if (viewModel.Aircooling)
                {
                    mode = 0x12;
                    return ConvertToString(mode);
                }
                if (viewModel.AirWatercooling)
                {
                    mode = 0x13;
                    return ConvertToString(mode);
                }
            }
            return ConvertToString(mode);
        }

        private string ConvertToString(byte mode)
        {
            int value = (Int32)mode;
            return value.ToString();
        }
    }
}
