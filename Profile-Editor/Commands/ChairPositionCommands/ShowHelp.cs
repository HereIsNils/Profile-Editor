using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Profile_Editor.Commands.ChairPositionCommands
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
            string text = "Mit der Combobox kann die gewünschte Postition ausgewählt werden, die konfiguriert werden möchte.\n " +
                "\nDie Slider geben den jeweiligen Wert in Prozent an und können auf die gewünschte Position gestellt werden.";

            MessageBox.Show(text);
        }
    }
}
