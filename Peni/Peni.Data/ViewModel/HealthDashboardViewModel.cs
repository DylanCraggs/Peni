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
	public class HealthDashboardViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		public ICommand GoToWaterCommand { get ; set ; }
		public ICommand GoToJourCommand { get ; set; }
		public ICommand GoToFoodCommand { get; set; }

		private List<DWI> WaterAmount;

		// How much have you drunk? I bet you were wondering that this morning when you woke up without your undies.
		private int IntWaterAmount {
			get {
				var database = new HealthDatabase ();
				WaterAmount = new List<DWI> (database.WaterDrunk ());
				if (WaterAmount.Count == 0) {
					return 0;
				} else {
					return WaterAmount [0].WaterIntake;
				}
			}
			set { ; }
		}

		private int waterGoal {
			get { return 2000;}
		}

		// Changes the water image on the dashboard XAML depending on how much water has been drunk.
		// This is a bunch of if statements because in c# land switch is a selective bitch who requires
		// all her potential matches to constants. What a prude.
		public string WaterImage {
			get { 

				if (IntWaterAmount < (waterGoal / 4)) {
					return "card_water_0.png";
				} else {
					if (IntWaterAmount < (waterGoal / 2)) {
						return "card_water_25.png";
					} else {
						if (IntWaterAmount < (waterGoal * .75)) {
							return "card_water_50.png";
						} else {
							if (IntWaterAmount < waterGoal) {
								return "card_water_75.png";
							} else
								return "card_water_100.png";
						}}}}}

		public string WaterDrunkLabel {
			get {
				var database = new HealthDatabase ();
				WaterAmount = new List<DWI> (database.WaterDrunk ());
				if (WaterAmount.Count == 0) {
					return "You have not drunk any water today!";
				} else {
					return "You have drunk " + WaterAmount [0].WaterIntake.ToString () + "mLs today!";
				}
			}
			set {RaisePropertyChanged (() => WaterDrunkLabel) ;}
		}

		private List<FoodTable> FoodAmount;

		public string StringFoodEaten {
			get {
				var database = new HealthDatabase ();
				FoodAmount = new List<FoodTable> (database.FoodQuery ());
				if (FoodAmount.Count == 0) {
					return "You haven not eaten anything today";
				} else {
					return "You have eaten " + FoodAmount [0].CalorieIntake + " calories today!";
				}
			}
			set { RaisePropertyChanged (() => StringFoodEaten); }
		}

		private int IntFoodAmount {
			get {
				var database = new HealthDatabase ();
				FoodAmount = new List<FoodTable> (database.FoodQuery ());
				if (FoodAmount.Count == 0) {
					return 0;
				} else {
					return FoodAmount [0].CalorieIntake;
				}
			}
			set { ; }
		}

		private int foodGoal {
			get { return 1200;}
		}

		public string FoodImage {
			get { if (IntFoodAmount < (foodGoal / 4)) {
					return "card_food_0.png";
				} else {
					if (IntFoodAmount < (foodGoal / 2)) {
						return "card_food_25.png";
					} else {
						if (IntFoodAmount < (foodGoal * .75)) {
							return "card_food_50.png";
						} else {
							if (IntFoodAmount < foodGoal) {
								return "card_food_75.png";
							} else
								return "card_food_100.png";
						}}}}}



		private List<JournalTable> feelingList;

		private int recur;
		private int combinedFeelings;
		private int feelingAverage;
		private int feelingGoal {
			get { return 5;}
		}

		public string FeelingImage {
			get { if (feelingAverage <= (feelingGoal *.2)) {
					return "card_emotion_extremely_sad.png";
			} else {
				if (feelingAverage < (feelingGoal *.4)) {
					return "card_emotion_sad.png";
				} else {
					if (feelingAverage < (feelingGoal * .6)) {
						return "card_emotion_ok.png";
					} else {
						if (feelingAverage < feelingGoal * .8) {
							return "card_emotion_happy.png";
						} else
							return "card_emotion_extremely_happy.png";
					}}}}}


		public HealthDashboardViewModel (IMyNavigationService navigationService)
		{
			var database = new HealthDatabase ();


			feelingList = new List<JournalTable> (database.AvgFeeling ());

			if (feelingList.Count == 0) {
				feelingAverage = 3;
			} else {
				combinedFeelings = 0;

				if (feelingList.Count < 10) {
					recur = feelingList.Count;
				} else {
					recur = 10;
				}

				for (int c = 0; c < recur; c = c + 1) {
					switch (feelingList[c].Rank) {
					case "happy.png":
						combinedFeelings = combinedFeelings + 5;
						break;
					case "sad.png":
						combinedFeelings = combinedFeelings + 1;
						break;
					default:
						combinedFeelings = combinedFeelings + 3;
						break;
					}
				}
				feelingAverage = combinedFeelings / recur;
			}


			// Navigation
			this.navigationService = navigationService;
			GoToWaterCommand = new Command (() => {
				this.navigationService.NavigateToModal(ViewModelLocator.WaterPageKey); 
			});

			GoToJourCommand = new Command (() => {
				this.navigationService.NavigateToModal(ViewModelLocator.JournalKey);
			});

			GoToFoodCommand = new Command (() => {
				this.navigationService.NavigateToModal(ViewModelLocator.FoodKey);
			});

		}
}
}
