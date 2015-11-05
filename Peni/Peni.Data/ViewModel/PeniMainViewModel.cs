using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using Peni.Data.ViewModel;
using System.Collections.Generic;

using Peni.Data;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics;

namespace Peni.Data
{
	public class PeniMainViewModel : ViewModelBase
	{

		//Seriously what is this thing
		private IMyNavigationService navigationService;

		// Takes you to the Add Water Page
		public ICommand BeamToWater { get; private set; }
		public ICommand BeamToFeels { get; private set; }
		public ICommand BeamToFood { get; private set; }

		//Used to store query results from le database
		private List<DWI> WaterBubbleList;
		private List<FoodTable> FoodBubbleList;


		// Time is stored in the database at Universal time because Xamarin is stupid.
		// All times have to have 10 hours added to them.
		// The user needs to drink water every two hours.
		public bool WaterNeeded {
			get {
				var database = new HealthDatabase();
				WaterBubbleList = new List<DWI> (database.WaterDrunk ()); 
				if (WaterBubbleList.Count == 0) {
					return true;
				} else {
					if ((DateTime.Now > WaterBubbleList [0].TheDate.AddHours(2)) & (WaterBubbleList [0].WaterIntake != 0)) {
						return true;
					} else {
						return false;
					}
				}
			}
			set { RaisePropertyChanged (() => WaterNeeded); }
		}

		public bool FoodNeeded {
			get {
				var database = new HealthDatabase();
				FoodBubbleList = new List<FoodTable> (database.FoodQuery ()); 
				if (FoodBubbleList.Count == 0) {
					return true;
				} else {
					if ((DateTime.Now > FoodBubbleList [0].FoodDate.AddHours(5)) & (FoodBubbleList [0].CalorieIntake != 0)) {
						return true;
					} else {
						return false;
					}
				}
			}
			set { RaisePropertyChanged (() => WaterNeeded); }
		}


		public PeniMainViewModel (IMyNavigationService navigationService)
		{
			var database = new HealthDatabase();
			WaterBubbleList = new List<DWI> (database.WaterDrunk ()); 
			if (WaterBubbleList.Count == 0) {
				WaterNeeded = true;
			} else {
				if ((DateTime.Now > WaterBubbleList [0].TheDate.AddHours (2)) & (WaterBubbleList [0].WaterIntake != 0)) {
					WaterNeeded = true;
				} else {
					WaterNeeded = false;
				}
			}

			FoodBubbleList = new List<FoodTable> (database.FoodQuery ()); 
			if (FoodBubbleList.Count == 0) {
				FoodNeeded = true;
			} else {
				if ((DateTime.Now > FoodBubbleList [0].FoodDate.AddHours (5)) & (FoodBubbleList [0].CalorieIntake != 0)) {
					FoodNeeded = true;
				} else {
					FoodNeeded = false;
				}
			}

			// Beam me up, Scotty
			this.navigationService = navigationService;

			// So many inappropriate innuendos are just waiting to be written here
			BeamToWater = new Command (() => {
				this.navigationService.NavigateToModal (ViewModelLocator.WaterPageKey); 
			});

			BeamToFood = new Command (() => {
				this.navigationService.NavigateToModal (ViewModelLocator.FoodKey); 
			});

			BeamToFeels = new Command (() => {
				this.navigationService.NavigateToModal (ViewModelLocator.NewJournalKey); 
			});

		}
	}

}

