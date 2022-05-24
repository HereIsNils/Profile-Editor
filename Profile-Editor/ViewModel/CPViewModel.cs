using Profile_Editor.Commands;
using Profile_Editor.Commands.ChairPositionCommands;
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

        private ChairPosition _chairPosition;
        public ChairPosition ChairPosition
        {
            get { return _chairPosition; }
            set
            {
                _chairPosition = value;
                OnPropertyChanged(nameof(ChairPosition));
            }
        }
        private UserSettingsStore _userSettingsStore;

        public CPViewModel(UserSettingsStore userSettingsStore)
        {
            CBPositionsChangedCommand = new CBPositionsChangedCommand(this);
            ChairHeightCommand = new ChairHeightCommand(userSettingsStore);
            BackHeightCommand = new BackHeightCommand(userSettingsStore);
            HeadrestHeightCommand = new HeadrestHeightCommand(userSettingsStore);
            HeadrestTiltCommand = new HeadrestTiltCommand(userSettingsStore);
            SeatCorrectionCommand = new SeatCorrectionCommand(userSettingsStore);
            SeatTiltCommand = new SeatTiltCommand(userSettingsStore);
            _userSettingsStore = userSettingsStore;

        }
    }
}
