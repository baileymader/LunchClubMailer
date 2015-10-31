using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LunchClubMailer
{
  class DelegateCommand : ICommand
  {
    private readonly Predicate<object> canExecute;
    private readonly Action<object> execute;

    public DelegateCommand(Action<object> execute) : this(execute,null) { }

    public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
    {
      this.execute = execute;
      this.canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
      return canExecute == null ? true : canExecute(parameter);
    }

    public event EventHandler CanExecuteChanged;

    protected virtual void OnCanExecuteChanged(EventArgs e)
    {
        EventHandler handler = CanExecuteChanged;
        if (handler != null)
        {
            handler(this, e);
        }
    }

    public void Execute(object parameter)
    {
      execute(parameter);
    }
  }
}
