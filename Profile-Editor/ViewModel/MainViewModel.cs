using Profile_Editor.Commands;
using Profile_Editor.Stores;
using System.Windows.Input;

namespace Profile_Editor.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly UserSettingsStore _userSettingsStore;
        public CPViewModel CPViewModel { get; }
        public IViewModel IViewModel { get; }
        public ISViewModel ISViewModel { get; }
        public LLViewModel LLViewModel { get; }
        public SKViewModel SKViewModel { get; }
        public TViewModel TViewModel { get; }
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
