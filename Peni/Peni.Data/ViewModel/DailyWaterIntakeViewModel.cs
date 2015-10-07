using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using Peni.Data.ViewModel;

namespace Peni.Data
{
	public class DailyWaterIntakeViewModel : ViewModelBase
	{
		// ICommand to bind to button which saves thread
		public ICommand SaveThreadCommand { get; private set; }

		/// <summary>
		/// Data binding the title of the thread
		/// </summary>
		private DateTime Date;
		public DateTime date
		{
			get { return date; }
			set { date = value;
				RaisePropertyChanged(() => date); }
		}

		/// <summary>
		/// Data binding for the details on the thread (post content)
		/// </summary>
		private float DailyIntake;
		public float dailyIntake
		{
			get { return dailyIntake; }
			set { dailyIntake = value;
				RaisePropertyChanged(() => dailyIntake); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.ForumNewThreadViewModel"/> class.
		/// </summary>
		/// <param name="navigationService">Navigation service.</param>
		public DailyWaterIntakeViewModel (IMyNavigationService navigationService)
		{
			// Create our forums database object
			var database = new HealthDatabase();

			// Add  a new command to our ICommand
			//SaveThreadCommand = new Command (() => {
				// Insert the thread into the database
				//database.InsertWaterIntake(new DailyWaterIntake());

			//});
		}
	}
}

