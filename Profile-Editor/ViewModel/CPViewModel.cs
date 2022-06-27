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
        private int _position;

        #region Commands
        public ICommand CBPositionsChangedCommand { get; set; }
        public ICommand ChairHeightCommand { get; set; }
        public ICommand BackHeightCommand { get; set; }
        public ICommand HeadrestHeightCommand { get; set; }
        public ICommand HeadrestTiltCommand { get; set; }
        public ICommand SeatCorrectionCommand { get; set; }
        public ICommand SeatTiltCommand { get; set; }
        public ICommand ShowHelp { get; set; }
        #endregion Commands

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

        #region CPViewModel Members
        public int Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

        private double _Axis1;
        public double Axis1
        {
            get { return _Axis1; }
            set
            {
                _Axis1 = value;
                OnPropertyChanged(nameof(Axis1));
            }
        }
        private double _Axis2;
        public double Axis2
        {
            get { return _Axis2; }
            set
            {
                _Axis2 = value;
                OnPropertyChanged(nameof(Axis2));
            }
        }
        private double _Axis3;
        public double Axis3
        {
            get { return _Axis3; }
            set
            {
                _Axis3 = value;
                OnPropertyChanged(nameof(Axis3));
            }
        }
        private double _Axis4;
        public double Axis4
        {
            get { return _Axis4; }
            set
            {
                _Axis4 = value;
                OnPropertyChanged(nameof(Axis4));
            }
        }
        private double _Axis5;
        public double Axis5
        {
            get { return _Axis5; }
            set
            {
                _Axis5 = value;
                OnPropertyChanged(nameof(Axis5));
            }
        }
        private double _Axis6;
        public double Axis6
        {
            get { return _Axis6; }
            set
            {
                _Axis6 = value;
                OnPropertyChanged(nameof(Axis6));
            }
        }
        #endregion CPViewModel Members

        public CPViewModel(UserSettingsStore userSettingsStore, UserSettings userSettings)
        {
            CBPositionsChangedCommand = new CBPositionsChangedCommand(this, userSettingsStore);
            ChairHeightCommand = new ChairHeightCommand(userSettingsStore, this);
            BackHeightCommand = new BackHeightCommand(userSettingsStore, this);
            HeadrestHeightCommand = new HeadrestHeightCommand(userSettingsStore, this);
            HeadrestTiltCommand = new HeadrestTiltCommand(userSettingsStore, this);
            SeatCorrectionCommand = new SeatCorrectionCommand(userSettingsStore, this);
            SeatTiltCommand = new SeatTiltCommand(userSettingsStore, this);
            ShowHelp = new ShowHelp();

            this.userSettings = userSettings;
            _userSettingsStore = userSettingsStore;
            _userSettingsStore.UserSettingsCreated += RefreshView;

            Position = -1;

        }

        private void RefreshView(UserSettings obj)
        {
            int i = Position;
            if (i == -1) return;
            Axis1 = Convert.ToDouble(obj.ChairPositions[0].ChairPosition[i].Axis1);
            Axis2 = Convert.ToDouble(obj.ChairPositions[0].ChairPosition[i].Axis2);
            Axis3 = Convert.ToDouble(obj.ChairPositions[0].ChairPosition[i].Axis3);
            Axis4 = Convert.ToDouble(obj.ChairPositions[0].ChairPosition[i].Axis4);
            Axis5 = Convert.ToDouble(obj.ChairPositions[0].ChairPosition[i].Axis5);
            Axis6 = Convert.ToDouble(obj.ChairPositions[0].ChairPosition[i].Axis6);
        }
    }
}
