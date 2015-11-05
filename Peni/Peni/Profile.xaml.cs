using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Peni
{
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
			this.BindingContext = App.Locator.ProfilePage;
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
