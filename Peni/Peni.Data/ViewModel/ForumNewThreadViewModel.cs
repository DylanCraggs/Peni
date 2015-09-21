using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;

namespace Peni.Data
{
	public class ForumNewThreadViewModel : ViewModelBase
	{

		public ICommand SaveThreadCommand { get; private set; }

		private String threadTitle;
		public String ThreadTitle
		{
			get { return threadTitle; }
			set { threadTitle = value;
				RaisePropertyChanged(() => ThreadTitle); }
		}

		private string threadDetails;
		public string ThreadDetails
		{
			get { return threadDetails; }
			set { threadDetails = value;
				RaisePropertyChanged(() => ThreadDetails); }
		}

		public ForumNewThreadViewModel (IMyNavigationService navigationService)
		{
			var database = new ForumsDatabase();
			SaveThreadCommand = new Command (() => {
				database.InsertOrUpdateThread(new Thread(ThreadTitle, "Anonymous", DateTime.Now.ToString(), ThreadDetails));
				navigationService.GoBack();
			});
		}
	}
}

