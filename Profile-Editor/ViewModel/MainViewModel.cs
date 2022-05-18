using Profile_Editor.Commands;
using Profile_Editor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public CPViewModel CPViewModel { get; }
        public IViewModel IViewModel { get; }
        public ISViewModel ISViewModel { get; }
        public LLViewModel LLViewModel { get; }
        public SKViewModel SKViewModel { get; }
        public TViewModel TViewModel { get; }
        public VViewModel VViewModel { get; }

        private UserSettings _userSettings;
        public UserSettings UserSettings
        {
            get { return _userSettings; }
            set 
            { 
                _userSettings = value;
                OnPropertyChanged(nameof(UserSettings));
            }
        }

        public ICommand ImportXmlCommand { get; set; }


        public MainViewModel(
            CPViewModel cpViewModel,
            IViewModel iViewModel,
            ISViewModel iSViewModel,
            LLViewModel llViewModel,
            SKViewModel skViewModel,
            TViewModel tViewModel,
            VViewModel vViewModel)
        {
            ImportXmlCommand = new ImportXmlCommand(this);
            UserSettings = new UserSettings();
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
