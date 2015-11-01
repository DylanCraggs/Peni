using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace Peni
{
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
			this.BindingContext = App.Locator.ProfilePage;


			Bio.Completed += (sender, e) => {
				Debug.WriteLine("Updated!");
				Peni.Data.Globals.UserSession.UserBio = Bio.Text;
				UpdateBio();
			};

			/*
			switchPrivacy.OnChanged += (object sender, ToggledEventArgs e) => {
				Debug.WriteLine(e.Value.ToString());
				Peni.Data.Globals.UserSession.UserPrivacy = e.Value;
				UpdatePrivacy();
			};
			*/
		}

		/// <summary>
		/// Updates the bio.
		/// </summary>
		private void UpdateBio() {
			//var value = (Editor)e;
			//Peni.Data.Globals.UserSession.UserBio = value.Text.ToString ();
			Peni.Data.ProfileDatabase database = new Peni.Data.ProfileDatabase ();
			database.UpdateProfile (Peni.Data.Globals.UserSession);
		}

		/// <summary>
		/// Updates the privacy.
		/// </summary>
		private async void UpdatePrivacy(object sender, ToggledEventArgs e) {
			Peni.Data.Globals.UserSession.UserPrivacy = e.Value;
			Peni.Data.ProfileDatabase database = new Peni.Data.ProfileDatabase ();
			await database.UpdateProfile (Peni.Data.Globals.UserSession);
		}
	}

	public class Profile : MasterDetailPage {
		public Profile() {
			Detail = new ProfilePage();
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			this.Title = "Profile";

			// ItemTapped event handler for the side menu
			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}
	}
}
