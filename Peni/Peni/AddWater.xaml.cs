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
	public partial class AddWaterPageMain : ContentPage
	{
		public AddWaterPageMain()
		{
			InitializeComponent();
			BindingContext = App.Locator.AddWater;
		}
	}

	public class AddWaterPage : MasterDetailPage
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.PeniForums"/> class.
		/// </summary>
		public AddWaterPage()
		{
			Detail = new AddWaterPageMain();
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			this.Title = "Add Water";

			// ItemTapped event handler for the side menu
			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}
	}
	/*
	public class PeniWater : MasterDetailPage
	{
		public PeniWater()
		{
			Detail = new AddWaterPage();
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			Title = "Add Water";

			// ItemTapped event handler for the side menu
			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}
	}
	*/
}
