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

		private List<DWI> WaterAmount;

		private int userGoal {
			get { return 2000;}
		}
		private int IntWaterAmount {
			get { var database = new HealthDatabase ();
				WaterAmount = new List<DWI> (database.WaterDrunk());
				if (WaterAmount.Count == 0) {
					return 0;
				} else { return WaterAmount[0].WaterIntake; }
				; }
			set { ; }
		}

		public string WaterImage {
			get { 

				if (IntWaterAmount < (userGoal / 4)) {
					return "card_water_0.png";
				} else {
					if (IntWaterAmount < (userGoal / 2)) {
						return "card_water_25.png";
					} else {
						if (IntWaterAmount < (userGoal * .75)) {
							return "card_water_50.png";
						} else {
								if (IntWaterAmount < userGoal) {
									return "card_water_75.png";
								} else
							return "card_water_100.png";
						}
					}
				}


				 }
			set { ; }
		}

		public string LabelText {
			get {
				return IntWaterAmount.ToString ();
			}	
			set { 
				RaisePropertyChanged (() => LabelText);
				 }	}


		public HealthDashboardViewModel (IMyNavigationService navigationService)
		{
			// Navigation
			this.navigationService = navigationService;
			GoToWaterCommand = new Command (() => {
				this.navigationService.NavigateToModal(ViewModelLocator.WaterPageKey); 
			});
				
		}
}
}
