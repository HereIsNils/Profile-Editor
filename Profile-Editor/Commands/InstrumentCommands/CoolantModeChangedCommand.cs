using Profile_Editor.Model;
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
            SetStates();
            Instrument instrument = viewModel.GetLevel(userSettingsStore.userSettings);
            instrument.CoolantMode = coolantMode;
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
                        return mode.ToString();
                    }
                    if (viewModel.AirWatercooling)
                    {
                        mode = 0x23;
                        return mode.ToString();
                    }
                    if (viewModel.Naclcooling)
                    {
                        mode = 0x24;
                        return mode.ToString();
                    }
                }
                mode = 0x21;
                return mode.ToString();
            }
            else if (viewModel.CoolantState)
            {
                if (viewModel.Aircooling)
                {
                    mode = 0x12;
                    return mode.ToString();
                }
                if (viewModel.AirWatercooling)
                {
                    mode = 0x13;
                    return mode.ToString();
                }
            }
            return mode.ToString();
        }

        private void SetStates()
        {
            // radio buttons
            if(viewModel.CoolantState == true)
            {
                viewModel.RadioGridEnabled = true;
            } else
            {
                viewModel.RadioGridEnabled = false;
            }

            // NaCl only
            if(viewModel.NaclState == true)
            {
                viewModel.NaclButtonEnabled = true;
            } else
            {
                viewModel.NaclButtonEnabled = false;
            }
        }
    }
}
