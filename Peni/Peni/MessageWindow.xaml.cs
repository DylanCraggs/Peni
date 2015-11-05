using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Peni.Data;
using System.Diagnostics;

namespace Peni
{
	public partial class MessageWindowMain : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.MessageWindow"/> class.
		/// </summary>
		public MessageWindowMain ()
		{
			InitializeComponent ();
			BindingContext = App.Locator.MessagingMain;
			SendResponseOnComplete ();
		}

		/// <summary>
		/// Sends a message response to another user
		/// </summary>
		private void SendResponseOnComplete() {
			Response.Completed += (sender, e) => {
				// No text inputted
				if(Response.Text.Length <= 0)
					return;

				// Execute our command in the view model
				Command command = (Command)App.Locator.MessagingMain.SendMessageCommand;
				if(command.CanExecute(this)) {
					command.Execute(this);
					Response.Text = "";
				}
			};
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			App.Locator.MessagingMain.OnAppearing ();
		}
	}

	public class MessageWindow : MasterDetailPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.PeniForums"/> class.
		/// </summary>
		public MessageWindow()
		{
			Detail = new MessageWindowMain();
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

