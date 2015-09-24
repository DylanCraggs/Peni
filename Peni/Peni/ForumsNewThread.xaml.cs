using System;
using System.Collections.Generic;
using Peni.Data.ViewModel;
using Peni.Data;
using Xamarin.Forms;

namespace Peni
{
	public partial class ForumsNewThread : BaseView
	{
		public ForumsNewThread () {
			BindingContext = App.Locator.ForumNewThread;
			InitializeComponent ();
			base.Init ();
		}
	}
}

