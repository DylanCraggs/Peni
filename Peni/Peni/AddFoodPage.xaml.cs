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
	public partial class AddFoodPageMain : ContentPage
	{
		public AddFoodPageMain ()
		{
			InitializeComponent ();
			BindingContext = App.Locator.FoodVM;
		}
	}

	public class AddFoodPage : MasterDetailPage
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.PeniForums"/> class.
		/// </summary>
		public AddFoodPage()
		{
			Detail = new AddFoodPageMain();
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			this.Title = "Add Food";

			// ItemTapped event handler for the side menu
			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}
	}
}

