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

		//Le Database
		private HealthDatabase database;

		//Used to store query results from le database
		private List<DWI> WaterBubbleList;


		// Time is stored in the database at Universal time because Xamarin is stupid.
		// All times have to have 10 hours added to them.
		// The user needs to drink water every two hours.
		public bool WaterNeeded {
			get {
				WaterBubbleList = new List<DWI> (database.WaterDrunk ()); 
				if (DateTime.Now.AddHours (-2) < WaterBubbleList[0].TheDate.AddHours(10) & WaterBubbleList[0].WaterIntake!=0)
				{ return true;}
				 else {return false;}
			}
		}


		public PeniMainViewModel (IMyNavigationService navigationService)
		{

			// Beam me up, Scotty
			this.navigationService = navigationService;

			// So many inappropriate innuendos are just waiting to be written here
			BeamToWater = new Command (() => {
				this.navigationService.NavigateToModal (ViewModelLocator.WaterPageKey); 
			});

	}
}

				}

