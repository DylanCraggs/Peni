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
	public partial class JournalMain : ContentPage
	{
		public JournalMain ()
		{
			InitializeComponent ();
			BindingContext = App.Locator.JournalVM;
		}
	}

	public class Journal : MasterDetailPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.PeniForums"/> class.
		/// </summary>
		public Journal()
		{
			Detail = new JournalMain();
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			this.Title = "Journal";

			// ItemTapped event handler for the side menu
			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}
	}
}

