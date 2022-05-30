﻿using Profile_Editor.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Profile_Editor.Commands.ChairPositionCommands
{
    internal class SeatCorrectionCommand : ICommand
    {
        private UserSettingsStore userSettingsStore { get; }
        private int i

        public SeatCorrectionCommand(UserSettingsStore userSettingsStore, int i)
        {
            this.userSettingsStore = userSettingsStore;
            this.i = i;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            userSettingsStore.userSettings.ChairPositions[0].ChairPosition[i].Axis3 = parameter.ToString();
        }
    }
}