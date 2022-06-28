using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Profile_Editor.Commands.TimerCommands
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
            string text = "Ein Timer setzt sich aus der Splate Minute und Sekunde zusammen. " +
                "In der Spalte Minute kann die Minutenanzahl des Timers festgelegt werden und in der Spalte Sekunde die Sekundenanzahl\n" +
                "\nUm einen Timer in eine Stoppuhr umzukonfigurieren, muss der Button auf der linken Seite gedrückt werden. Wenn der Button blau ausgefüllt ist, ist die Stoppuhr aktiv.";
            MessageBox.Show(text);
        }
    }
}
