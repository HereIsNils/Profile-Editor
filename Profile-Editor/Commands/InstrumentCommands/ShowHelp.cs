using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Profile_Editor.Commands.InstrumentCommands
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
            string text = "App Level zeigt das aktuell ausgewählte App Level an. Das App Level kann oben links ausgewählt werden. " +
                "Weitere Informationen dazu finden Sie in der Kurzanleitung Profil-Editor.\n" +
                "\nDer Halter, welcher konfiguriert werden soll, wird mit der Combobox festgelegt. Der an der Einheit angeschlossene Instrumententyp" +
                "wird dabei ignoriert.\n" +
                "\nDie Fußpedalmitte wird über den Slider festgelegt. Der Slider hat einen Minimalwert von 1 und einen Maximalwert von 128." +
                "1 entspricht der linken Seite und 128 der rechten Seite des Fußpedals.\n" +
                "\nDie Rotationsrichtung kann mit der Combobox festgelegt werden.\n" +
                "\nDer Modus für die Beschleunigung kann über die Combobox festgelegt werden.\n" +
                "\nDer Kühlmodus kann ausgewählt werden, sobald der Haken bei Kühlung gesetzt wurde. NaCl kann ausgewählt werden, " +
                "wenn der Haken bei NaCl aktiv gesetzt wurde. Es kann nur ein Kühlmodus gleichzeitig ausgewählt werden.\n" +
                "\nDas Level der Helligkeit kann festgelegt werden, sobald der Haken bei Helligkeit gesetzt wurde.";
            MessageBox.Show(text);
        }
    }
}
