using System;
using System.Windows.Input;

namespace Presentation {
    public class Command : ICommand{
        private readonly Action action;

        public Command(Action action) {
            this.action = action;
        }

        public bool CanExecute(object parameter) {
            return true;
        }



        public void Execute() {
            action();
        }

        public void Execute(object parameter) {
           Execute();
        }

        public event EventHandler CanExecuteChanged;
    }
}