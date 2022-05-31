using Profile_Editor.Commands.LedLightCommands;
using Profile_Editor.Model;
using Profile_Editor.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.ViewModel
{
    internal class LLViewModel : BaseViewModel
    {
        public MainViewModel viewModel;

        public ICommand IntensityCommand { get; set; }
        public ICommand ColorTempCommand { get; set; }
        public ICommand DimModeCommand { get; set; }
        public ICommand DimIntensityCommand { get; set; }

        private UserSettingsStore _userSettingsStore;
        public UserSettingsStore UserSettingsStore
        {
            get { return _userSettingsStore; }
            set
            {
                _userSettingsStore = value;
                OnPropertyChanged(nameof(_userSettingsStore));
            }
        }

        public UserSettings userSettings { get; set; }

        #region IViewModel Members
        private int _intensity;
        public int Intensity
        {
            get { return _intensity; }
            set 
            { 
                _intensity = value; 
                OnPropertyChanged(nameof(Intensity)); 
            }
        }

        private int _colorTemp;
        public int ColorTemp
        {
            get { return _colorTemp; }
            set
            {
                _colorTemp = value;
                OnPropertyChanged(nameof(ColorTemp));
            }
        }

        private int _dimMode;
        public int DimMode 
        {
            get { return _dimMode; } 
            set
            {
                _dimMode = value;
                OnPropertyChanged(nameof(DimMode));
            }
        }

        private int _dimIntensity;
        public int DimIntensity
        {
            get { return _dimIntensity; }
            set 
            { 
                _dimIntensity = value;
                OnPropertyChanged(nameof(DimIntensity));
            }
        }
        #endregion IViewModel Members

        public LLViewModel(UserSettingsStore userSettingsStore, UserSettings userSettings)
        {
            IntensityCommand = new IntensityCommand(userSettingsStore);
            ColorTempCommand = new ColorTempCommand(userSettingsStore);
            DimModeCommand = new DimModeCommand(userSettingsStore);
            DimIntensityCommand = new DimIntensityCommand(userSettingsStore);

            UserSettingsStore = userSettingsStore;
            this.userSettings = userSettings;
        }

    }
}
