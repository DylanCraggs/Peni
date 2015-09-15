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
			Cell sendingItem; 

			// Attempt to store cell requested in sendingItem
			try {
				sendingItem = (Cell)sender;
			} catch (Exception ex) {
				DisplayAlert ("Error", ex.Message.ToString (), "Okay");
				return;
			}

			// Store reference to binding that cell has
			var thread = (ForumThread)sendingItem.BindingContext;

			// Show the requested by parsing the object
			Navigation.PushAsync(new ForumThreadPage(thread));
		}
	}
}

