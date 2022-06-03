using Profile_Editor.Commands.SoftwareKeysCommands;
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
    internal class SKViewModel : BaseViewModel
    {
        public MainViewModel viewModel;

        public ICommand Btn1Command { get; set; }
        public ICommand Btn2Command { get; set; }
        public ICommand Btn3Command { get; set; }
        public ICommand Btn4Command { get; set; }
        public ICommand Btn5Command { get; set; }
        public ICommand Btn6Command { get; set; }

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

        #region SKViewModel Members
        private int _position1;
        public int Position1
        {
            get { return _position1; }
            set
            {
                _position1 = value;
                OnPropertyChanged(nameof(Position1));
            }
        }

        private int _position2;
        public int Position2
        {
            get { return _position2; }
            set
            {
                _position2 = value;
                OnPropertyChanged(nameof(Position2));
            }
        }

        private int _position3;
        public int Position3
        {
            get { return _position3; }
            set
            {
                _position3 = value;
                OnPropertyChanged(nameof(Position3));
            }
        }

        private int _position4;
        public int Position4
        {
            get { return _position4; }
            set
            {
                _position4 = value;
                OnPropertyChanged(nameof(Position4));
            }
        }

        private int _position5;
        public int Position5
        {
            get { return _position5; }
            set
            {
                _position5 = value;
                OnPropertyChanged(nameof(Position5));
            }
        }

        private int _position6;
        public int Position6
        {
            get { return _position6; }
            set
            {
                _position6 = value;
                OnPropertyChanged(nameof(Position6));
            }
        }
        #endregion SKViewModel Members

        public SKViewModel(UserSettingsStore userSettingsStore, UserSettings userSettings)
        {
            Btn1Command = new Bt1Command(userSettingsStore);
            Btn2Command = new Bt2Command(userSettingsStore);
            Btn3Command = new Bt3Command(userSettingsStore);
            Btn4Command = new Bt4Command(userSettingsStore);
            Btn5Command = new Bt5Command(userSettingsStore);
            Btn6Command = new Bt6Command(userSettingsStore);

            this.userSettings = userSettings;
            _userSettingsStore = userSettingsStore;

            Position1 = -1;
            Position2 = -1;
            Position3 = -1;
            Position4 = -1;
            Position5 = -1;
            Position6 = -1;

            _userSettingsStore.UserSettingsCreated += RefreshView;
        }

        private void RefreshView(UserSettings settings)
        {
            Position1 = Convert.ToInt32(settings.SoftKeys[0].SoftKey1);
            Position2 = Convert.ToInt32(settings.SoftKeys[0].SoftKey2);
            Position3 = Convert.ToInt32(settings.SoftKeys[0].SoftKey3);
            Position4 = Convert.ToInt32(settings.SoftKeys[0].SoftKey4);
            Position5 = Convert.ToInt32(settings.SoftKeys[0].SoftKey5);
            Position6 = Convert.ToInt32(settings.SoftKeys[0].SoftKey6);
        }
    }
}
