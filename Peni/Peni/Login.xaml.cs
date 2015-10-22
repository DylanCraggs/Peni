using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Peni.Data;
using System.Diagnostics;

namespace Peni
{
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
			BindingContext = App.Locator.LoginPage;
		}
	}

}