using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;

namespace Peni.Data
{
	public class ForumNewThreadViewModel : ViewModelBase
	{
		// ICommand to bind to button which saves thread
		public ICommand SaveThreadCommand { get; private set; }

		/// <summary>
		/// Data binding the title of the thread
		/// </summary>
		private String threadTitle;
		public String ThreadTitle
		{
			get { return threadTitle; }
			set { threadTitle = value;
				RaisePropertyChanged(() => ThreadTitle); }
		}

		/// <summary>
		/// Data binding for the details on the thread (post content)
		/// </summary>
		private string threadDetails;
		public string ThreadDetails
		{
			get { return threadDetails; }
			set { threadDetails = value;
				RaisePropertyChanged(() => ThreadDetails); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.ForumNewThreadViewModel"/> class.
		/// </summary>
		/// <param name="navigationService">Navigation service.</param>
		public ForumNewThreadViewModel (IMyNavigationService navigationService)
		{
			// Create our forums database object
			var database = new ForumsDatabase();

			// Add  a new command to our ICommand
			SaveThreadCommand = new Command (() => {
				// Insert the thread into the database
				database.InsertThread(new Thread(ThreadTitle, "Anonymous", DateTime.Now.ToString(), ThreadDetails));

				// Set the data bindings to null as we have entered the new thread
				threadTitle = null;
				threadDetails = null;

				// Go back a page
				navigationService.GoBack();
			});
		}
	}
}

