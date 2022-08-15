using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_LoginForm.ViewModel
{
    public class ViewModelCommand : ICommand
    {
        // Fields
        private readonly Action<object?> _executeAction;
        private readonly Func<object?, bool>? _canExecute;

        // Constructors
        public ViewModelCommand(Action<object?> executeAction)
        {
            _executeAction = executeAction;
            _canExecute = null;
        }

        public ViewModelCommand(Action<object?> executeAction, Func<object?, bool> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecute = canExecuteAction;
        }

        // Events
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; } 
        }

        // Methods
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }
    }
}
