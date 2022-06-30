using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Profile_Editor.Commands.LedLightCommands
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
            string text = "Der Dimm-Modus wird über die Combobox festgelegt.\n " +
                "\nDie Slider legen die Stufe des jeweiligen Wertes fest. Helligkeit und Modus Helligkeit haben einen minimalen Wert von 1 " +
                "und einen maximalen Wert von 5.\n" +
                "\nDer Slider für Farbtemperatur hat ebenfalls 5 Stufen. Hier entspricht die 1. Stufe einer Farbtemperatur von 4000 K. " +
                "Die 5. Stufe enstpricht 6000 K.";
            MessageBox.Show(text);
        }
    }
}
