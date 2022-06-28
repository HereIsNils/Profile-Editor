using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Profile_Editor.Commands.VariousCommands
{
    internal class ShowHelp : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string text = "Die gewünschte Anzeigesprache der Einheit kann mit der Combobox festgelegt werden.";
            MessageBox.Show(text);
        }
    }
}
