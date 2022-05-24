using Profile_Editor.Stores;
using Profile_Editor.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Profile_Editor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly UserSettingsStore _userSettingsStore = new UserSettingsStore();

        public App()
        {
            _userSettingsStore = new UserSettingsStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            

            CPViewModel cpViewModel = new CPViewModel(_userSettingsStore);
            IViewModel iViewModel = new IViewModel();
            ISViewModel isViewModel = new ISViewModel();
            LLViewModel llViewModel = new LLViewModel();
            SKViewModel skViewModel = new SKViewModel();
            TViewModel tViewModel = new TViewModel();
            VViewModel vViewModel = new VViewModel();

            MainViewModel mainViewModel = new MainViewModel(cpViewModel,
                                                            iViewModel,
                                                            isViewModel,
                                                            llViewModel,
                                                            skViewModel,
                                                            tViewModel,
                                                            vViewModel,
                                                            _userSettingsStore);

            MainWindow = new MainWindow()
            {
                DataContext = mainViewModel
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
