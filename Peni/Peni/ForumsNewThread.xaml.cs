using System;
using System.Collections.Generic;
using Peni.Data.ViewModel;
using Peni.Data;
using Xamarin.Forms;

namespace Peni
{
	public partial class ForumsNewThread : ContentPage
	{
		public ForumsNewThread () {
			BindingContext = App.Locator.ForumNewThread;
			InitializeComponent ();
		}
	}
}

