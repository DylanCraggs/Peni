using System;
using System.Collections.Generic;

using Peni.Data;
using Xamarin.Forms;

namespace Peni
{
	public partial class ForumsNewThread : ContentPage
	{
		public ForumsNewThread () {
			InitializeComponent ();
		}

		/// <summary>
		/// Adds the new thread to the database
		/// </summary>
		/// <param name="sender">Sending object.</param>
		/// <param name="e">Event.</param>
		protected void AddNewThread(object sender, EventArgs e) {
			var Database = new ForumsDatabase ();
			Thread thread = new Thread(Title.Text.ToString(), "Anonymous", DateTime.Now.ToString(), Content.Text.ToString());
			Database.InsertOrUpdateThread(thread);
			Navigation.PopAsync ();
			Navigation.PushAsync(new ForumThreadPage(thread));
		}
	}
}

