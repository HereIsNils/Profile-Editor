using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile_Editor.ViewModel
{
    internal class IViewModel : BaseViewModel
    {
        public string AppLevel { get; set; }

        public IViewModel()
        {
            AppLevel = "App Level: 1";
        }
    }
}
