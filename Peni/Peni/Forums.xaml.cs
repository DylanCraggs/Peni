/// <summary>
/// Forums class which displays a list of forum threads.
/// </summary>

using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Peni.Data;
using Peni.Data.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;


namespace Peni
{
	public partial class Forums : ContentPage {
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Forums"/> class.
		/// </summary>
		public Forums ()
		{
			BindingContext = App.Locator.ForumsListPage;
			InitializeComponent ();

			/*
			var fab = new FloatingActionButtonView() {
				ImageName = "ic_add.png",
				ColorNormal = Color.FromHex("f16378"),
				ColorPressed = Color.FromHex("f592a1"),
				ColorRipple = Color.FromHex("f16378"),
				Clicked = async (sender, args) => 
				{
					MenuButtonPressed();
				},
			};
			*/

			var fab = new Button () {
				Text = "+",
				Command = ForumPageViewModel.NewThreadCommand,
				BackgroundColor = Color.FromHex ("F16378"),
				BorderRadius = 5,
			};


			// Position the pageLayout to fill the entire screen.
			// Manage positioning of child elements on the page by editing the pageLayout.
			AbsoluteLayout.SetLayoutFlags(pageLayout, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(pageLayout, new Rectangle(0f, 0f, 1f, 1f));

			// Overlay the FAB in the bottom-right corner
			AbsoluteLayout.SetLayoutFlags(fab, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(fab, new Rectangle(1f, 1f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			test.Children.Add (fab);
		}

		/// <summary>
		/// Menu button pressed.
		/// </summary>
		private void MenuButtonPressed() {
			Navigation.PushAsync (new ForumsNewThread ());
		}

		/// <summary>
		/// List item clicked.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event.</param>
		protected void listItemClicked(object sender, EventArgs e) {
			Cell sendingItem; 

			// Attempt to store cell requested in sendingItem
			try {
				sendingItem = (Cell)sender;
			} catch (Exception ex) {
				DisplayAlert ("Error", ex.Message.ToString (), "Okay");
				return;
			}

			// Store reference to binding that cell has
			var thread = (Thread)sendingItem.BindingContext;

			// Show the requested by parsing the object
			Navigation.PushAsync(new ForumThreadPage(thread));
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			var vm = ServiceLocator.Current.GetInstance<ForumPageViewModel> ();
			vm.OnAppearing();
		}
	}

	public class PeniForums : MasterDetailPage
	{
		public PeniForums()
		{
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			Detail = new Forums();
		}
	}
}

