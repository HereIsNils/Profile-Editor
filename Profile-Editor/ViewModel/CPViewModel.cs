using Profile_Editor.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.ViewModel
{
    internal class CPViewModel : BaseViewModel
    {
        public ICommand CBPositionsChangedCommand { get; set; }

        public CPViewModel()
        {
            CBPositionsChangedCommand = new CBPositionsChangedCommand(this);
        }
    }
}
