using Profile_Editor.Model;
using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System.Diagnostics;
using System.Windows;

namespace Profile_Editor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly UserSettingsStore _userSettingsStore;
        private UserSettings _userSettings = new UserSettings();

        public App()
        {
            _userSettings = new UserSettings();
            _userSettingsStore = new UserSettingsStore(_userSettings);
        }
        protected override void OnStartup(StartupEventArgs e)
        {


            CPViewModel cpViewModel = new CPViewModel(_userSettingsStore, _userSettings);
            IViewModel iViewModel = new IViewModel(_userSettingsStore, _userSettings);
            ISViewModel isViewModel = new ISViewModel(); // currently not in use
            LLViewModel llViewModel = new LLViewModel(_userSettingsStore, _userSettings);
            SKViewModel skViewModel = new SKViewModel(_userSettingsStore, _userSettings);
            TViewModel tViewModel = new TViewModel(_userSettingsStore, _userSettings);
            VViewModel vViewModel = new VViewModel(_userSettingsStore, _userSettings);

            MainViewModel mainViewModel = new MainViewModel(cpViewModel,
                                                            iViewModel,
                                                            isViewModel,
                                                            llViewModel,
                                                            skViewModel,
                                                            tViewModel,
                                                            vViewModel,
                                                            _userSettingsStore);

            MainWindow window = new MainWindow()
            {
               DataContext = mainViewModel
            };
            MainWindow.Show();
            Debug.WriteLine(window.DataContext);
            base.OnStartup(e);
        }
    }
}
