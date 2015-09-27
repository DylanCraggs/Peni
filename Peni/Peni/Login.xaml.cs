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

			// Event handler for when user completes username entry
			entryUsername.Completed += (sender, e) => {
				entryPassword.Focus();
			};

			// Event handler for when user completes password entry
			entryPassword.Completed += (sender, e) => {
				if(buttonLogin.Command.CanExecute(BindingContext)) {
					buttonLogin.Command.Execute(BindingContext);
				}
			};
		}
	}
}

