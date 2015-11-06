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
	public class GoalsViewModel : ViewModelBase
	{
		//Le Database
		private HealthDatabase database;

		private IMyNavigationService navigationService;
	
		public GoalsViewModel (IMyNavigationService navigationService)
			{
				
			}
	}
}

