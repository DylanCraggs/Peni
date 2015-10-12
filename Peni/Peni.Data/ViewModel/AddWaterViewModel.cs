using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using System.Diagnostics;
using Peni.Data.ViewModel;
using System.Collections.Generic;

namespace Peni.Data
{
	public class AddWaterViewModel : ViewModelBase
	{
		// ICommand to bind to button which saves water input

		public ICommand SaveWaterCommand { get; private set; }

		public ICommand AddCupWater { get; private set; }
		public ICommand MinusCupWater { get; private set; }
		public ICommand AddBottleWater { get; private set; }
		public ICommand MinusBottleWater { get; private set; }
		public ICommand MinusAmountWater { get; private set; }
		public ICommand AddAmountWater { get; private set; }


		private IMyNavigationService navigationService;

		public DateTime lastWater
		{
			get { return lastWater; }
			set { lastWater=DateTime.Now;
			}
		}


		private int currIntake
		{
			get {return CurrIntake;}
			set {currIntake = CurrIntake;
				RaisePropertyChanged (() => currIntake);}
		}

		public int CurrIntake;

		public string stringCurrIntake
		{
			get { return CurrIntake.ToString(); }
			set { CurrIntake = int.Parse(value);
			//	RaisePropertyChanged(() => stringCurrIntake.ToString()); 
			}
		}

		public AddWaterViewModel (IMyNavigationService navigationService)
			{
				this.navigationService = navigationService;

				var database = new HealthDatabase();

				SaveWaterCommand = new Command ((currIntake) => {
					database.InsertOrUpdateDWI(new DWI(DateTime.Now.Date, CurrIntake));
				} );

			AddCupWater = new Command (() => {
				CurrIntake = CurrIntake + 250;
				RaisePropertyChanged (() => stringCurrIntake);
				RaisePropertyChanged (() => lastWater);
				SaveWaterCommand.Execute(this);
			});

			MinusCupWater = new Command (() => {
				CurrIntake = CurrIntake - 250;
				if (CurrIntake<0)
					{CurrIntake=0;}
				RaisePropertyChanged (() => stringCurrIntake);
				RaisePropertyChanged (() => lastWater);
				SaveWaterCommand.Execute(this);
			});

			AddBottleWater = new Command (() => {
				CurrIntake = CurrIntake + 600;
				RaisePropertyChanged (() => stringCurrIntake);
				RaisePropertyChanged (() => lastWater);
				SaveWaterCommand.Execute(this);
			});

			MinusBottleWater = new Command (() => {
				CurrIntake = CurrIntake - 600;
				if (CurrIntake<0)
					{CurrIntake=0;}
				RaisePropertyChanged (() => stringCurrIntake);
				RaisePropertyChanged (() => lastWater);
				SaveWaterCommand.Execute(this);
			});

			AddAmountWater = new Command (() => {
				CurrIntake = CurrIntake + 250;
				RaisePropertyChanged (() => stringCurrIntake);
				RaisePropertyChanged (() => lastWater);
				SaveWaterCommand.Execute(this);
			});

			MinusAmountWater = new Command (() => {
				CurrIntake = CurrIntake - 250;
				if (CurrIntake<0)
					{CurrIntake=0;}
				RaisePropertyChanged (() => stringCurrIntake);
				RaisePropertyChanged (() => lastWater);
				SaveWaterCommand.Execute(this);
			});

		}


	}
}

