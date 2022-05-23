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
        protected override void OnStartup(StartupEventArgs e)
        {
            CPViewModel cpViewModel = new CPViewModel();
            MainViewModel mainViewModel = new MainViewModel(cpViewModel,
                    new IViewModel(),
                    new ISViewModel(),
                    new LLViewModel(),
                    new SKViewModel(),
                    new TViewModel(),
                    new VViewModel());

            MainWindow = new MainWindow()
            {
                DataContext = mainViewModel
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
