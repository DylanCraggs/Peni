// Welcome to the Add Water View Model. Enjoy...

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
using System.Diagnostics;

namespace Peni.Data
{
	public class AddWaterViewModel : ViewModelBase
	{
		// ICommand to bind to button which saves water input
		public ICommand SaveWaterCommand { get; private set; }


		// Commands that are bound to buttons
		public ICommand AddCupWater { get; private set; }
		public ICommand MinusCupWater { get; private set; }
		public ICommand AddBottleWater { get; private set; }
		public ICommand MinusBottleWater { get; private set; }
		public ICommand MinusAmountWater { get; private set; }
		public ICommand AddAmountWater { get; private set; }

		// Tardis?
		private IMyNavigationService navigationService;

		public List<DWI> ListAmountDrunk;

		public string HowMuchWater {
		get	{
				return CurrIntake.ToString ();
			}

			set{
				RaisePropertyChanged (() => HowMuchWater); 
			}
		}

		// The almighty CurrIntake, that measures how much water you have consumed.
		private int CurrIntake;

		// Collects the user's input
		private string waterAmountString;
		public string WaterAmountString { 
			get { return waterAmountString; } 
			set { waterAmountString = value; 
				RaisePropertyChanged (() => WaterAmountString);}
		}

		// Changes user's input into an int because the user is stupid as fuck
		private int waterAmount 
		{
			get { return Convert.ToInt32(Convert.ToDouble(waterAmountString)); }
			set { waterAmount = value; }
		}

		public AddWaterViewModel (IMyNavigationService navigationService)
			{
				// This navigates things. Where? I do not know........
				this.navigationService = navigationService;

				// Establishing the Database because YOLO 
				var database = new HealthDatabase();

				// This code happens when the page loads. It's here because it kept producing errors when in the get set for each variable.
				// It pulls the amount of water drunk for the day from the database.
				// If no water has been drunk, it returns a 0 until something happens...
				ListAmountDrunk = new List<DWI> (database.WaterDrunk());
				if (ListAmountDrunk.Count == 0) {
					CurrIntake = 0;
					} else {
					CurrIntake = Convert.ToInt32 (ListAmountDrunk [0].WaterIntake);
					}

				// Saves stuff in the database
				SaveWaterCommand = new Command (() => {
				database.InsertOrUpdateDWI(new DWI(DateTime.Now.Date, CurrIntake));
				RaisePropertyChanged (() => HowMuchWater);
				} );


			// All of these following commands change the amount of water stored in the system. How. Exciting.
				AddCupWater = new Command (() => {
					CurrIntake = CurrIntake + 250;
					SaveWaterCommand.Execute(this);
				});

				MinusCupWater = new Command (() => {
				CurrIntake = CurrIntake - 250;
					if (CurrIntake<0)
						{CurrIntake=0;}
					SaveWaterCommand.Execute(this);
				});

				AddBottleWater = new Command (() => {
					CurrIntake = CurrIntake + 600;
					SaveWaterCommand.Execute(this);
				});

				MinusBottleWater = new Command (() => {
					CurrIntake = CurrIntake - 600;
					if (CurrIntake<0)
						{CurrIntake=0;}
					SaveWaterCommand.Execute(this);
				});

				AddAmountWater = new Command (() => {
					CurrIntake = CurrIntake + waterAmount;
					SaveWaterCommand.Execute(this);
				});

				MinusAmountWater = new Command (() => {
					CurrIntake = CurrIntake - waterAmount;
					if (CurrIntake<0)
						{CurrIntake=0;}
					SaveWaterCommand.Execute(this);
				});
		}
	
	}
}
// I wonder if anyeone is reading these comments? I'm thinking of hiding a story in here somewhere...