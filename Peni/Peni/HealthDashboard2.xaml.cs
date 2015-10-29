using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Peni.Data;
using Peni.Data.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using System.Diagnostics;

namespace Peni
{
	public partial class HealthDashboard2 : ContentPage
	{
		public HealthDashboard2 ()
		{
			InitializeComponent ();
			BindingContext = App.Locator.Dashboard;

			//dashboardWaterImage.GestureRecognizers.Add (new TapGestureRecognizer (OnTap));
		}




	}
}

