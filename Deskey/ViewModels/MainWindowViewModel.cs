using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace Deskey.ViewModels
{
	public class MainWindowViewModel : ViewModelBase, IScreen
	{
		public string Greeting => "Welcome to Avalonia!";

        public RoutingState Router { get; } = new RoutingState();
    }
}
