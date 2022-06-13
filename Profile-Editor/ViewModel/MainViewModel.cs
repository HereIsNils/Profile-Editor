using Profile_Editor.Commands;
using Profile_Editor.Model;
using Profile_Editor.Stores;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Profile_Editor.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        private UserSettingsStore _userSettingsStore;

        #region Properties
        private CPViewModel _CPViewModel;
        public CPViewModel CPViewModel
        {
            get { return _CPViewModel; }
            set { _CPViewModel = value; OnPropertyChanged(nameof(CPViewModel)); }
        }

        private IViewModel _IViewModel;
        public IViewModel IViewModel
        {
            get { return _IViewModel; }
            set { _IViewModel = value; OnPropertyChanged(nameof(IViewModel)); }
        }

        private ISViewModel _ISViewModel;
        public ISViewModel ISViewModel
        {
            get { return _ISViewModel; }
            set { _ISViewModel = value; OnPropertyChanged(nameof(ISViewModel)); }
        }

        private LLViewModel _LLViewModel;
        public LLViewModel LLViewModel
        {
            get { return _LLViewModel; }
            set { _LLViewModel = value; OnPropertyChanged(nameof(LLViewModel)); }
        }

        private SKViewModel _SKViewModel;
        public SKViewModel SKViewModel
        {
            get { return _SKViewModel; }
            set { _SKViewModel = value; OnPropertyChanged(nameof(SKViewModel)); }
        }

        private TViewModel _TViewModel;
        public TViewModel TViewModel
        {
            get { return _TViewModel; }
            set { _TViewModel = value; OnPropertyChanged(nameof(TViewModel)); }
        }

        private VViewModel _VViewModel;
        public VViewModel VViewModel
        {
            get { return _VViewModel; }
            set { _VViewModel = value; OnPropertyChanged(nameof(VViewModel)); }
        }

        private string _DefaultPath;
        public string DefaultPath
        {
            get { return _DefaultPath; }
            set { _DefaultPath = value; OnPropertyChanged(nameof(DefaultPath)); }
        }

        private string _CurrentPath;
        public string CurrentPath
        {
            get { return _CurrentPath; }
            set { _CurrentPath = value; OnPropertyChanged(nameof(CurrentPath)); }
        }

        private List<string> _AppLevels;
        public List<string> AppLevels
        {
            get { return _AppLevels; }
            set { _AppLevels = value; OnPropertyChanged(nameof(AppLevels)); }
        }

        private int _AppLevelIndex;
        public int AppLevelIndex
        {
            get { return _AppLevelIndex; }
            set { _AppLevelIndex = value; OnPropertyChanged(nameof(AppLevelIndex)); }
        }

        private bool _IsEnabled;
        public bool IsEnabled
        {
            get { return _IsEnabled; }
            set { _IsEnabled = value; OnPropertyChanged(nameof(IsEnabled)); }
        }
        #endregion Properties

        public ICommand AppLevelChangedCommand { get; set; }
        public ICommand ImportXmlCommand { get; set; }
        public ICommand DefaultFileCommand { get; set; }
        public ICommand SaveDataCommand { get; set; }
        public ICommand SaveDataAsCommand { get; set; }


        public MainViewModel(
            CPViewModel cpViewModel,
            IViewModel iViewModel,
            ISViewModel iSViewModel,
            LLViewModel llViewModel,
            SKViewModel skViewModel,
            TViewModel tViewModel,
            VViewModel vViewModel,
            UserSettingsStore userSettingsStore)
        {
            AppLevelChangedCommand = new AppLevelChangedCommand(iViewModel, userSettingsStore, this);
            ImportXmlCommand = new ImportXmlCommand(userSettingsStore, this);
            DefaultFileCommand = new DefaultFileCommand(userSettingsStore, this);
            SaveDataAsCommand = new SaveDataAsCommand(userSettingsStore, this);
            SaveDataCommand = new SaveDataCommand(userSettingsStore, this);

            _userSettingsStore = userSettingsStore;
            CPViewModel = cpViewModel;
            IViewModel = iViewModel;
            ISViewModel = iSViewModel;
            LLViewModel = llViewModel;
            SKViewModel = skViewModel;
            TViewModel = tViewModel;
            VViewModel = vViewModel;
            AppLevels = new List<string>();
            IsEnabled = false;

            _userSettingsStore.UserSettingsCreated += RefreshAppLvl;

            fillView();
        }

        private void fillView()
        {
            DefaultPath = Settings1.Default.defaultPath;
            if (DefaultPath == null)
            {
                return;
            }
            string path = DefaultPath;
            if (File.Exists(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserSettings));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    if (fs == null | serializer == null) return;
                    StreamReader stream = new StreamReader(fs, Encoding.UTF8);
                    UserSettings userSettings = (UserSettings)serializer.Deserialize(stream);

                    if (userSettings == null) return;
                    _userSettingsStore.CreateUserSettings(userSettings);
                    IsEnabled = true;
                }
            }
            else return;
        }

        private void RefreshAppLvl(UserSettings settings)
        {
            AppLevels.Clear();
            for (int i = 0; i < 3; i++)
            {
                AppLevels.Add(settings.AppLevelNames[0].AppLevelName[i].Value);
            }
        }
    }
}
