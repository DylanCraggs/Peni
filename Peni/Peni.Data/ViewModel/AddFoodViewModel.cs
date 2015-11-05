using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using System.Diagnostics;
using Peni.Data.ViewModel;
using System.Collections.Generic;

using Peni.Data;
using Microsoft.Practices.ServiceLocation;

namespace Peni.Data
{
	public class AddFoodViewModel : ViewModelBase
	{
		//Le Database
		private HealthDatabase database;

		private IMyNavigationService navigationService;

		public ICommand AddFood { get; set; }
		public ICommand TakeFood { get; set; }
		public ICommand GoToDashCommand { get; set; }

		//Used to store query results from le database
		public List<FoodTable> ListAmountEaten;

		//Bound to a label that tells the user how much water they have drunk
		public string HowMuchFood {
			get	{ return FoodIntake.ToString (); }
			set	{ RaisePropertyChanged (() => FoodIntake); }
		}

		// The almighty FoodIntake, that measures how much water you have consumed.
		private int FoodIntake ;

		// Collects the user's input
		private string foodAmountString;
		public string FoodAmountString { 
			get { return foodAmountString;	} 
			set { foodAmountString = value; 
				RaisePropertyChanged (() => FoodAmountString);}
		}

		// Changes user's input into an int because the user is stupid as fuck
		private int foodAmount 
		{
			get { return Convert.ToInt32(Convert.ToDouble(foodAmountString))				; }
			set { foodAmount = value; }
		}

		public AddFoodViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
			// Establishing the Database because YOLO 
			database = new HealthDatabase();

			ListAmountEaten = new List<FoodTable> (database.FoodQuery ());

			if (ListAmountEaten.Count==0 || ListAmountEaten[0].FoodDate.Date != DateTime.Now.Date) {
				database.NewFoodDay ();
				FoodIntake = 0;
			} else {
				FoodIntake = ListAmountEaten [0].CalorieIntake;
			}


			AddFood = new Command (() => {
				FoodIntake = FoodIntake + foodAmount;
				database.FoodUpdate(FoodIntake);
				RaisePropertyChanged (() => HowMuchFood);
			});

			TakeFood = new Command (() => {
				FoodIntake = FoodIntake - foodAmount;
				database.FoodUpdate(FoodIntake);
				RaisePropertyChanged (() => HowMuchFood);
			});

			GoToDashCommand = new Command (() => {
				this.navigationService.NavigateToModal(ViewModelLocator.DashboardKey);
			});

		}
	}
}

