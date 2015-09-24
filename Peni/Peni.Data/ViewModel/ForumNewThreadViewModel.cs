using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;

namespace Peni.Data
{
	public class ForumNewThreadViewModel : ViewModelBase
	{
		// Command to bind to button which saves thread
		public ICommand SaveThreadCommand { get; private set; }

		/// <summary>
		/// The thread title.
		/// </summary>
		private String threadTitle;
		public String ThreadTitle
		{
			get { return threadTitle; }
			set { threadTitle = value;
				RaisePropertyChanged(() => ThreadTitle); }
		}

		/// <summary>
		/// The thread details (thread post content you could also call it)
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
			var database = new ForumsDatabase();
			SaveThreadCommand = new Command (() => {
				database.InsertOrUpdateThread(new Thread(ThreadTitle, "Anonymous", DateTime.Now.ToString(), ThreadDetails));
				threadTitle = null;
				threadDetails = null;
				navigationService.GoBack();
			});
		}
	}
}

