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
		}

		protected void ButtonClicked(object sender, EventArgs e)
		{
			// These conditions need to be changed once the database is setup
			if (entryUsername.Text != null) {
				if (entryPassword.Text != null) {
					Navigation.PushModalAsync (new PeniMasterDetail ());
				} else {
					loginLabel.Text = "Please Enter Username and / or Password Again";
				}

			}
		}

		public async void AttemptLogin() {
			ProfileDatabase database = new ProfileDatabase ();

			if (await database.AttemptLoginAuth ("admin@admin.com", "password"))
				Debug.WriteLine ("Login Success");
			else
				Debug.WriteLine ("Login Failed");
		}
	}

}