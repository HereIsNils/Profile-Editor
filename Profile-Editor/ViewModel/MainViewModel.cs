using Profile_Editor.Commands;
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
        public ICommand ImportXmlCommand { get; set; }

        public MainViewModel()
        {
            ImportXmlCommand = new ImportXmlCommand();
        }
    }
}
