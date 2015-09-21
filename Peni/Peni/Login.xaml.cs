using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Peni
{
	public partial class Login : ContentPage
	{
		public Login ()
		{
			BindingContext = App.Locator.LoginPage;
			InitializeComponent ();
		}
	}
}

