using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Peni.Data.ViewModel;

namespace Peni.Data
{
	public class HealthTestViewModel : ViewModelBase
	{

		// ICommand to bind to button which saves thread
		public ICommand SaveGoalsCommand { get; private set; }

		/// <summary>
		/// The step goal.
		/// </summary>
		private String stepGoal;
		public String StepGoal
		{
			get { return stepGoal; }
			set { stepGoal = value;
				RaisePropertyChanged(() => StepGoal); }
		}

		private String waterGoal;
		public String WaterGoal
		{
			get { return waterGoal; }
			set { stepGoal = value;
				RaisePropertyChanged(() => WaterGoal); }
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.ForumNewThreadViewModel"/> class.
		/// </summary>
		/// <param name="navigationService">Navigation service.</param>
		public HealthTestViewModel (IMyNavigationService navigationService)
		{
			// Create our forums database object
			var database = new HealthDatabase();

			// Add  a new command to our ICommand
			SaveGoalsCommand = new Command (() => {
				// Insert the thread into the database

				database.InsertGoals(new Goals(stepGoal, waterGoal));
				// Set the data bindings to null as we have entered the new thread
					stepGoal = null;
				    waterGoal = null;

				// Go back a page
				navigationService.NavigateToModal(ViewModelLocator.PeniMasterDetail);
			});
		}
	}
}


