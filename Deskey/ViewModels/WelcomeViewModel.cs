using System;
using System.Windows.Input;
using Deskey.ViewModels;
using ReactiveUI;

namespace Deskey
{
    public class WelcomeViewModel : RoutableViewModelBase
    {
        public ICommand OpenExplorer { get; }

        public WelcomeViewModel(IScreen screen) : base(screen)
        { 
            OpenExplorer = ReactiveCommand.CreateFromObservable(
                () => HostScreen.Router.Navigate.Execute(new ExplorerViewModel(HostScreen))
            );
        }
    }

    public class ExplorerViewModel : RoutableViewModelBase
    {
        public ExplorerViewModel(IScreen screen) : base(screen)
        { 
            
        }
    }
}