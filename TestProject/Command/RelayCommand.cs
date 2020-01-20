using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TestProject.Command
{
    public class RelayCommand : ICommand
    {
        private readonly Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public bool CanExecute(object notUsed)
        {
            return true;
        }

        public void Execute(object notUsed)
        {
            _action();
        }

    }

    public class RelayParameterizedCommand : ICommand
    {
        private readonly Action<object> _action;


        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayParameterizedCommand(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

    }
}
