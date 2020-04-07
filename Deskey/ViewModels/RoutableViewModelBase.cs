using System;
using ReactiveUI;

namespace Deskey.ViewModels
{
    public abstract class RoutableViewModelBase : ViewModelBase, IRoutableViewModel
    {
        public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

        public IScreen HostScreen { get; }

		public RoutableViewModelBase(IScreen screen) => HostScreen = screen;
    }
}
