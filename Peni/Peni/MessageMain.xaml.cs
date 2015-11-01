using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Peni.Data;
using System.Diagnostics;

namespace Peni
{
	public partial class MessageMain : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.MessageMain"/> class.
		/// </summary>
		public MessageMain()
		{
			InitializeComponent ();
			BindingContext = App.Locator.MessagingMain;
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			App.Locator.MessagingMain.OnAppearing ();
		}

		/// <summary>
		/// Hides the click event.
		/// </summary>
		protected async void HideClickEvent(object sender, EventArgs e) {
			MessageList.SelectedItem = null;

			var sendingCell = (Cell)sender;
			var sendingItem = (Message)sendingCell.BindingContext;

			// on click go to a conversation with the receiving user ID = x
			var cmd = (Command)App.Locator.MessagingMain.GetNavigateToConversation(sendingItem.ReceivingUserID, sendingItem.ReceivingUserUsername).Result;
			if (cmd.CanExecute (this)) {
				cmd.Execute (this);
			}

		}
	}

	/// <summary>
	/// Peni forums master view (side menu + content)
	/// </summary>
	public class PeniMessageMain : MasterDetailPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.PeniForums"/> class.
		/// </summary>
		public PeniMessageMain()
		{
			Detail = new MessageMain();
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			this.Title = "Messages";

			// ItemTapped event handler for the side menu
			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}
	}
}

