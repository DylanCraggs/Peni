/// <summary>
/// Forums class which displays a list of forum threads.
/// </summary>

using System;
using System.Collections.Generic;

using Xamarin.Forms;


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

			var threads = new List<ForumThread> ();
			for (int i = 0; i < 15; ++i) {
				threads.Add (new ForumThread (i, "Hello World", i, "Dylan", "23 Aug 2015"));
			}

			ForumListView.ItemsSource = threads;
		}

		protected void showMenuButtonPressed(object sender, EventArgs e) {
			menubutton.BackgroundColor = Color.Red;
		}

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

		protected void listItemClicked(object sender, EventArgs e) {
			ViewCell sendingItem;
			try {
				sendingItem = (ViewCell)sender;
			} catch (Exception ex) {
				DisplayAlert ("Error", ex.Message.ToString (), "Okay");
				return;
			}

			View cellView = sendingItem.View;
			cellView.BackgroundColor = Color.Red;

			DisplayAlert ("Click Event", "Clicked on ID: " + sendingItem.Id.ToString(), "Okay");
		}
	}
}

