/// <summary>
/// Forums class which displays a list of forum threads.
/// </summary>

using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Peni.Data;


namespace Peni
{
	public partial class Forums : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Forums"/> class.
		/// </summary>
		public Forums ()
		{
			InitializeComponent ();
			UpdateList ();
		}

		/// <summary>
		/// Menu button pressed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event.</param>
		protected void showMenuButtonPressed(object sender, EventArgs e) {
			Navigation.PushAsync (new ForumsNewThread (this));
		}

		/// <summary>
		/// Favs button pressed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event.</param>
		protected void favButtonPressed(object sender, EventArgs e) {
			Button senderBtn; 

			// Attempt to cast the sending object to a button
			try {
				senderBtn = (Button)sender;
			} catch (Exception ex) {
				DisplayAlert("Error", "Failed to change value of favorite", "Okay");
				return;
			}

			DisplayAlert ("Debug Topic Data", "Your Topic ID: ", "Okay");
		}

		/// <summary>
		/// List item clicked.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event.</param>
		protected void listItemClicked(object sender, EventArgs e) {
			Cell sendingItem; 

			// Attempt to store cell requested in sendingItem
			try {
				sendingItem = (Cell)sender;
			} catch (Exception ex) {
				DisplayAlert ("Error", ex.Message.ToString (), "Okay");
				return;
			}

			// Store reference to binding that cell has
			var thread = (Thread)sendingItem.BindingContext;

			// Show the requested by parsing the object
			Navigation.PushAsync(new ForumThreadPage(thread));
		}

		public void UpdateList() {
			var Database = new ForumsDatabase ();
			ForumListView.ItemsSource = Database.GetAll();
		}
	}
}

