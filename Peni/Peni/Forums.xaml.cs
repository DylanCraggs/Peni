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
using System.Diagnostics;


namespace Peni
{
	public partial class Forums : ContentPage {
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Forums"/> class.
		/// </summary>
		public Forums ()
		{
			InitializeComponent ();
			BindingContext = App.Locator.ForumsListPage;

			CreateToolbar ();
			CreateFAB ();

			this.Title = "Forums";
		}

		/// <summary>
		/// Creates the toolbar.
		/// </summary>
		public void CreateToolbar() {
			ToolbarItems.Add (new ToolbarItem("My Home", "My Home", () => {
				Debug.WriteLine("My Home Pressed");
				// Run command to show all threads from the forum view model
			}, ToolbarItemOrder.Secondary, 0));

			ToolbarItems.Add (new ToolbarItem("My Favorites", "My Favorites", () => {
				Debug.WriteLine("My Favorites Pressed");
				// Run command to show users favorite threads from the forum view model
			}, ToolbarItemOrder.Secondary, 0));

			ToolbarItems.Add (new ToolbarItem("My Threads", "My Threads", () => {
				Debug.WriteLine("My Threads Pressed");
				// Run command to show users threads from the forum view model
			}, ToolbarItemOrder.Secondary, 0));
		}

		/// <summary>
		/// Creates the floating action button (FAB).
		/// </summary>
		public void CreateFAB() {
			Command cmd = (Command)App.Locator.ForumsListPage.GetNewThreadCommand();

			// Create the floating action button
			var fab = new FloatingActionButtonView () {
				ImageName = "ic_add.png",
				ColorNormal = Color.FromHex ("F16378"),
				ColorPressed = Color.FromHex ("F592A1"),
				ColorRipple = Color.FromHex ("F16378"),
				Clicked = async (sender, args) => {
					if (cmd.CanExecute (cmd)) {
						cmd.Execute (cmd);
					}
				},
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
		/// Menu button pressed event handler.
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
			// Stop the orange background showing up
			ForumListView.SelectedItem = null;

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

			// Grab the command interface and create a command from it
			Command cmd = (Command)App.Locator.ForumsListPage.GetGoToThreadCommand(thread);
			if (cmd.CanExecute (cmd)) {
				cmd.Execute (cmd);
			}
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing() {
			base.OnAppearing ();
			var viewmodel = ServiceLocator.Current.GetInstance<ForumPageViewModel>();
			viewmodel.OnAppearing();
		}
	}

	/// <summary>
	/// Peni forums master view (side menu + content)
	/// </summary>
	public class PeniForums : MasterDetailPage
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.PeniForums"/> class.
		/// </summary>
		public PeniForums()
		{
			Detail = new Forums();
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			this.Title = "Forums";

			// ItemTapped event handler for the side menu
			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}
	}
}

