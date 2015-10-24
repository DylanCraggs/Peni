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

			List<string> usernameList = new List<string> () {
				("dylan@admin.com"),
				("sarah@admin.com"),
				("yuet@admin.com"),
				("michaela@admin.com"),
				("leandro@admin.com")
			};

			Command cmd = (Command)App.Locator.LoginPage.GetLoginCommand();
			App.Locator.LoginPage.SetLogin (usernameList[rand.Next(0, usernameList.Count) - 1], "password"); // rand num from 0 to usernameList.Count - 1
			if (cmd.CanExecute (cmd))
				cmd.Execute (cmd);
		}
	}

}