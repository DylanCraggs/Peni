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
	public partial class AddJournelMain : ContentPage
	{
		public AddJournelMain ()
		{
			InitializeComponent ();
			BindingContext = App.Locator.NewJournalEntryVM;
		}
	}

	public class AddJournel : MasterDetailPage
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.PeniForums"/> class.
		/// </summary>
		public AddJournel()
		{
			Detail = new AddJournelMain();
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			this.Title = "Add Feeling";

			// ItemTapped event handler for the side menu
			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}
	}
}

