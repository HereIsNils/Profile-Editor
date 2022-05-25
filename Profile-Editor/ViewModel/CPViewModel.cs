using Profile_Editor.Commands;
using Profile_Editor.Commands.ChairPositionCommands;
using Profile_Editor.Model;
using Profile_Editor.Stores;
using System;
using System.Windows.Input;

namespace Profile_Editor.ViewModel
{
    internal class CPViewModel : BaseViewModel
    {
        public MainViewModel viewModel;
        public ICommand CBPositionsChangedCommand { get; set; }
        public ICommand ChairHeightCommand { get; set; }
        public ICommand BackHeightCommand { get; set; }
        public ICommand HeadrestHeightCommand { get; set; }
        public ICommand HeadrestTiltCommand { get; set; }
        public ICommand SeatCorrectionCommand { get; set; }
        public ICommand SeatTiltCommand { get; set; }

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

        #region sliders
        private double _Axis1;
        public double Axis1
        {
            get { return _Axis1; }
            set
            {
                _Axis1 = value;
                OnPropertyChanged(nameof(_Axis1));
            }
        }
        private double _Axis2;
        public double Axis2
        {
            get { return _Axis2; }
            set
            {
                _Axis2 = value;
                OnPropertyChanged(nameof(_Axis2));
            }
        }
        private double _Axis3;
        public double Axis3
        {
            get { return _Axis3; }
            set
            {
                _Axis3 = value;
                OnPropertyChanged(nameof(_Axis3));
            }
        }
        private double _Axis4;
        public double Axis4
        {
            get { return _Axis4; }
            set
            {
                _Axis4 = value;
                OnPropertyChanged(nameof(_Axis4));
            }
        }
        private double _Axis5;
        public double Axis5
        {
            get { return _Axis5; }
            set
            {
                _Axis5 = value;
                OnPropertyChanged(nameof(_Axis5));
            }
        }
        private double _Axis6;
        public double Axis6
        {
            get { return _Axis6; }
            set
            {
                _Axis6 = value;
                OnPropertyChanged(nameof(_Axis6));
            }
        }
        #endregion sliders

        public CPViewModel(UserSettingsStore userSettingsStore, UserSettings userSettings)
        {
            CBPositionsChangedCommand = new CBPositionsChangedCommand(this, userSettingsStore);
            ChairHeightCommand = new ChairHeightCommand(userSettingsStore);
            BackHeightCommand = new BackHeightCommand(userSettingsStore);
            HeadrestHeightCommand = new HeadrestHeightCommand(userSettingsStore);
            HeadrestTiltCommand = new HeadrestTiltCommand(userSettingsStore);
            SeatCorrectionCommand = new SeatCorrectionCommand(userSettingsStore);
            SeatTiltCommand = new SeatTiltCommand(userSettingsStore);

            this.userSettings = userSettings;
            _userSettingsStore = userSettingsStore;
            _userSettingsStore.UserSettingsCreated += UpdateSettings;

            Axis1 = 0;
            Axis2 = 0;
            Axis3 = 0;
            Axis4 = 0;
            Axis5 = 0;
            Axis6 = 0;

        }

        private void UpdateSettings(UserSettings settings)
        {
            CPViewModel vm = new CPViewModel(_userSettingsStore, settings);
        }

        private void UpdateSliders(int i)
        {
            i = 0;

            Axis1 = Convert.ToDouble(_userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis1);
            Axis2 = Convert.ToDouble(_userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis2);
            Axis3 = Convert.ToDouble(_userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis3);
            Axis4 = Convert.ToDouble(_userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis4);
            Axis5 = Convert.ToDouble(_userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis5);
            Axis6 = Convert.ToDouble(_userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis6);
        }
    }
}
