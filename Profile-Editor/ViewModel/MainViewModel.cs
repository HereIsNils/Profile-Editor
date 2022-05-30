using Profile_Editor.Commands;
using Profile_Editor.Stores;
using System.Windows.Input;

namespace Profile_Editor.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        private UserSettingsStore _userSettingsStore;
        private CPViewModel _cpViewModel;
        public CPViewModel CPViewModel 
        { 
            get { return _cpViewModel; }
            set
            { 
                _cpViewModel = value; 
                OnPropertyChanged(nameof(_cpViewModel));
            }
        }
        public IViewModel IViewModel { get; }
        public ISViewModel ISViewModel { get; }
        public LLViewModel LLViewModel { get; }
        public SKViewModel SKViewModel { get; }
        private TViewModel _tViewModel;
        public TViewModel TViewModel 
        {
            get { return _tViewModel; } 
            set { _tViewModel = value; }
        }
        public VViewModel VViewModel { get; }

        public ICommand ImportXmlCommand { get; set; }


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
