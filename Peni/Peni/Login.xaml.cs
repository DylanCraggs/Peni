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

		protected override void OnAppearing() {
			base.OnAppearing ();

			Random rand = new Random ();

			List<string> usernameList = new List<string> ();
			usernameList.Add ("dylan@admin.com");
			usernameList.Add ("sarah@admin.com");
			usernameList.Add ("yuet@admin.com");
			usernameList.Add ("michaela@admin.com");
			usernameList.Add ("leandro@admin.com");

			Command cmd = (Command)App.Locator.LoginPage.GetLoginCommand();
			App.Locator.LoginPage.SetLogin (usernameList[rand.Next(usernameList.Capacity)], "password");
			if (cmd.CanExecute (cmd))
				cmd.Execute (cmd);
		}
	}

}