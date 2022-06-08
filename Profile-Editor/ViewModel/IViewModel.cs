﻿using Profile_Editor.Commands.InstrumentCommands;
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
        public ICommand LuxLevelChangedCommand { get; set; }
        #endregion Commands

        #region IViewModel Members
        private int _HolderIndex;
        public int HolderIndex
        {
            get { return _HolderIndex; }
            set { _HolderIndex = value; OnPropertyChanged(nameof(HolderIndex)); }
        } // sets the index for the holder to be configured

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
            private set { _RotationTag = value; OnPropertyChanged(nameof(RotationTag)); }
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

        public IViewModel(UserSettingsStore userSettingsStore, UserSettings userSettings)
        {
            AppLevelCommand = new AppLevelCommand(this);
            HolderChangedCommand = new HolderChangedCommand(this);
            SCenterValueChangedCommand = new SCenterValueChangedCommand(userSettingsStore, this);
            RotationChangedCommand = new RotationChangedCommand(userSettingsStore, this);
            AuxChangedCommand = new AuxChangedCommand(userSettingsStore, this);
            CoolantModeChangedCommand = new CoolantModeChangedCommand(userSettingsStore, this);
            LuxStateChangedCommand = new LuxStateChangedCommand(userSettingsStore, this);
            LuxLevelChangedCommand = new LuxLevelChangedCommand(userSettingsStore, this);

            _userSettingsStore = userSettingsStore;
            this.userSettings = userSettings;

            _userSettingsStore.UserSettingsCreated += RefreshView;
        }

        private void RefreshView(UserSettings obj)
        {
            AppLevel = obj.AppLevelNames[0].AppLevelName[AppLevelIndex].Value;
            Instrument instrument = GetLevel(obj);
            SCenterValue = Convert.ToInt32(instrument.Center);
            RotationTag = Convert.ToInt32(instrument.Rotation);
            AuxIndex = Convert.ToInt32(instrument.Auxilliary);
            SetLuxLevel(instrument.Lux);

        }

        private Instrument GetLevel(UserSettings obj)
        {
            // needs to be converted, since there is no applevel 0
            int iA = AppLevelIndex + 1;
            string iAString = iA.ToString();

            // needs to be converted since there is no holder 0
            int iH = HolderIndex + 1;
            string iHString = iH.ToString();

            Instrument instrument = obj.Instruments[0].Instrument.First(x => x.AppLevel == iAString && x.Holder == iHString.ToString());
            return instrument;
        }

        private void SetLuxLevel(string lux)
        {
            string hex = StringToHex(lux);

            if (hex == "12") return; // lux off and level 1
            LuxLevel = Convert.ToInt32(hex[0]);

            if(hex[1] == 2) return; // lux off
            LuxLevelEnabled = true;
            LuxState = true;
        }

        private string StringToHex(string s)
        {
            int i = Convert.ToInt32(s);
            string hex = i.ToString("x2");
            return hex;
        }
    }
}
