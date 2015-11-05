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
	public partial class HealthDashboard2Main : ContentPage
	{
		public HealthDashboard2Main ()
		{
			InitializeComponent ();
			BindingContext = App.Locator.Dashboard;
		}
	}

	public class HealthDashboard2 : MasterDetailPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.PeniForums"/> class.
		/// </summary>
		public HealthDashboard2()
		{
			Detail = new HealthDashboard2Main();
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			this.Title = "Health Dashboard";

			// ItemTapped event handler for the side menu
			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}
	}
}

