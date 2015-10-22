/// <summary>
/// Class for reading a thread that is on the forum
/// </summary>

using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Windows.Input;
using System.Diagnostics;
using Microsoft.Practices.ServiceLocation;
using Peni.Data;

namespace Peni
{
	public partial class ForumThreadPage : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.ForumThreadPage"/> class.
		/// </summary>
		public ForumThreadPage () {
			InitializeComponent ();
			BindingContext = App.Locator.ForumsListPage;

			// Attempts to execute the leave comment comment from the view model
			CommentBox.Completed += (sender, e) => {
				// Check if there's input
				if(CommentBox.Text.Length <= 0)
					return;

				// Add the comment to the database
				Command cmd = (Command)App.Locator.ForumsListPage.GetLeaveCommentCommand ();
				if (cmd.CanExecute (cmd)) {
					cmd.Execute (cmd);
					UpdateView();
				}
			};
		}

		/// <summary>
		/// Updates the view.
		/// </summary>
		protected override void OnAppearing()
		{
			CommentBox.Text = "";
			ServiceLocator.Current.GetInstance<ForumPageViewModel> ().OnAppearing ();
		}

		private void UpdateView() {
			CommentBox.Text = "";
			ServiceLocator.Current.GetInstance<ForumPageViewModel> ().OnAppearing ();
		}
	}
}

