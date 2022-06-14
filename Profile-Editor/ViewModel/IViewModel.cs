using Profile_Editor.Commands.InstrumentCommands;
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
    internal class IViewModel : BaseViewModel
    {
        private UserSettingsStore _userSettingsStore;
        private MainViewModel _mainViewModel;

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

        #region Commands
        public ICommand AppLevelCommand { get; set; }
        public ICommand HolderChangedCommand { get; set; }
        public ICommand SCenterValueChangedCommand { get; set; }
        public ICommand RotationChangedCommand { get; set; }
        public ICommand AuxChangedCommand { get; set; }
        public ICommand CoolantModeChangedCommand { get; set; }
        public ICommand LuxStateChangedCommand { get; set; }
        #endregion Commands

        #region IViewModel Members
        private int _HolderIndex;
        public int HolderIndex
        {
            get { return _HolderIndex; }
            set { _HolderIndex = value; OnPropertyChanged(nameof(HolderIndex)); }
        } // sets the index for the holder to be configured

        private int _HolderTag;
        public int HolderTag
        {
            get { return _HolderTag; }
            set { _HolderTag = value; OnPropertyChanged(nameof(HolderTag)); }
        } // currently selected Tag of the holder
        private string _AppLevel;
        public string AppLevel
        {
            get { return _AppLevel; }
            set { _AppLevel = value; OnPropertyChanged(nameof(AppLevel)); }
        } // sets app level text

        private int _AppLevelIndex;
        public int AppLevelIndex
        {
            get { return _AppLevelIndex; }
            set { _AppLevelIndex = value; OnPropertyChanged(nameof(AppLevelIndex)); }
        }

        private int _SCenterValue;
        public int SCenterValue
        {
            get { return _SCenterValue; }
            set { _SCenterValue = value; OnPropertyChanged(nameof(SCenterValue)); }
        } // value of pedal slider

        private int _RotationTag;
        public int RotationTag
        {
            get { return _RotationTag; }
            set { _RotationTag = value; OnPropertyChanged(nameof(RotationTag)); }
        }

        private int _AuxIndex;
        public int AuxIndex
        {
            get { return _AuxIndex; }
            set { _AuxIndex = value; OnPropertyChanged(nameof(AuxIndex)); }
        } // index of Aux combobox

        private bool _CoolantState;
        public bool CoolantState
        {
            get { return _CoolantState; }
            set { _CoolantState = value; OnPropertyChanged(nameof(CoolantState)); }
        } // cooling mode enabled or disabled

        private bool _NaclState;
        public bool NaclState
        {
            get { return _NaclState; }
            set { _NaclState = value; OnPropertyChanged(nameof(NaclState)); }
        } // NaCl enabled or disabled

        private bool _Aircooling;
        public bool Aircooling
        {
            get { return _Aircooling; }
            set { _Aircooling = value; OnPropertyChanged(nameof(Aircooling)); }
        } // enable or disable aircooling

        private bool _AirWatercooling;
        public bool AirWatercooling
        {
            get { return _AirWatercooling; }
            set { _AirWatercooling = value; OnPropertyChanged(nameof(AirWatercooling)); }
        } //  enable or disable air and water cooling

        private bool _NaclCooling;
        public bool Naclcooling
        {
            get { return _NaclCooling; }
            set { _NaclCooling = value; OnPropertyChanged(nameof(_NaclCooling)); }
        } //  enable or disable NaCl cooling

        private bool _LuxState;
        public bool LuxState
        {
            get { return _LuxState; }
            set { _LuxState = value; OnPropertyChanged(nameof(LuxState)); }
        } //  enable or disable lux

        private int _LuxLevel;
        public int LuxLevel
        {
            get { return _LuxLevel; }
            set { _LuxLevel = value; OnPropertyChanged(nameof(LuxLevel)); }
        } // value for the lux level
        #endregion IViewModel Members

        #region States

        private bool _RadioGridEnabled;
        public bool RadioGridEnabled
        {
            get { return _RadioGridEnabled; }
            set { _RadioGridEnabled = value; OnPropertyChanged(nameof(RadioGridEnabled)); }
        } // state for the grid with all radio buttons

        private bool _NaclButtonEnabled;
        public bool NaclButtonEnabled
        {
            get { return _NaclButtonEnabled; }
            set { _NaclButtonEnabled = value; OnPropertyChanged(nameof(NaclButtonEnabled)); }
        } // state for the NaCl radio button

        private bool _LuxLevelEnabled;
        public bool LuxLevelEnabled
        {
            get { return _LuxLevelEnabled; }
            set { _LuxLevelEnabled = value; OnPropertyChanged(nameof(LuxLevelEnabled)); }
        }
        #endregion States

        public IViewModel(UserSettingsStore userSettingsStore, UserSettings userSettings) // aux and coolmode broken
        {
            AppLevelCommand = new AppLevelCommand(this); // aorn not needed
            HolderChangedCommand = new HolderChangedCommand(this);
            SCenterValueChangedCommand = new SCenterValueChangedCommand(userSettingsStore, this);
            RotationChangedCommand = new RotationChangedCommand(userSettingsStore, this);
            AuxChangedCommand = new AuxChangedCommand(userSettingsStore, this);
            CoolantModeChangedCommand = new CoolantModeChangedCommand(userSettingsStore, this);
            LuxStateChangedCommand = new LuxStateChangedCommand(userSettingsStore, this);

            _userSettingsStore = userSettingsStore;
            this.userSettings = userSettings;

            _userSettingsStore.UserSettingsCreated += RefreshView;
        }

        public void RefreshView(UserSettings obj)
        {
            AppLevel = obj.AppLevelNames[0].AppLevelName[AppLevelIndex].Value;
            Instrument instrument = GetLevel(obj);
            SCenterValue = Convert.ToInt32(instrument.Center);
            RotationTag = Convert.ToInt32(instrument.Rotation);
            AuxIndex = Convert.ToInt32(instrument.Auxilliary);
            SetLuxLevel(instrument.Lux);
            SetCoolantMode(instrument.CoolantMode);
        }

        private void SetCoolantMode(string coolantMode)
        {
            string hex = ToHex(coolantMode);
            int i = Convert.ToInt32(coolantMode);
            int i0 = i >> 4;
            string coolMode = hex.Substring(1, 1);

            if (hex == "11") 
            {
                Naclcooling = false;
                NaclButtonEnabled = false;

                CoolantState = false;
                RadioGridEnabled = false;

                Aircooling = false;
                AirWatercooling = false;
                
                return; // ancl and mode off
            } 

            if (i0 == 2)
            {
                Naclcooling = true;
                NaclButtonEnabled = true;
            } else
            {
                Naclcooling = false;
                NaclButtonEnabled = false;
            }

            if (coolMode == "1") return;
            
            CoolantState = true;
            RadioGridEnabled = true;

            switch (coolMode)
            {
                case "2":
                    Aircooling = true;
                    break;
                case "3":
                    AirWatercooling = true;
                    break;
                case "4":
                    Naclcooling = true;
                    break;

                default:
                    break;
            }
        }

        public Instrument GetLevel(UserSettings obj)
        {
            // needs to be converted, since there is no applevel 0
            int iA = AppLevelIndex + 1;
            string iAString = iA.ToString();

            if (HolderTag == 0) HolderTag = 1;

            Instrument instrument = obj.Instruments[0].Instrument.First(x => x.AppLevel == iAString && x.Holder == HolderTag.ToString());
            return instrument;
        }

        private void SetLuxLevel(string lux)
        {
            string hex = ToHex(lux);
            int i = Convert.ToInt32(lux);

            if (hex == "12") return; // lux off and level 1
            int i0 = i >> 4;
            string hexState = hex.Substring(1, 1);
            LuxLevel = i0;

           if(hexState == "2") return; // lux off
            LuxLevelEnabled = true;
            LuxState = true;
        }

        private string ToHex(string s)
        {
            int i = Convert.ToInt32(s);
            string hex = i.ToString("x2");
            return hex;
        }
    }
}
