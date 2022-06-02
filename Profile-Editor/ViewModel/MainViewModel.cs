using Profile_Editor.Commands;
using Profile_Editor.Stores;
using System.Windows.Input;

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
        #endregion Properties

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
            ImportXmlCommand = new ImportXmlCommand(userSettingsStore);
            DefaultFileCommand = new DefaultFileCommand(userSettingsStore, this);
            //SaveDataAsCommand = new SaveDataAsCommand();
            //SaveDataCommand = new SaveDataCommand();

            _userSettingsStore = userSettingsStore;
            CPViewModel = cpViewModel;
            IViewModel = iViewModel;
            ISViewModel = iSViewModel;
            LLViewModel = llViewModel;
            SKViewModel = skViewModel;
            TViewModel = tViewModel;
            VViewModel = vViewModel;

        }
    }
}
