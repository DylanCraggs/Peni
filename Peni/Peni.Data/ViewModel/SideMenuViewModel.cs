using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Peni.Data.ViewModel;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Peni;
using System.Collections.Generic;

namespace Peni.Data
{
	public class SideMenuViewModel : ViewModelBase
	{

		/// <summary>
		/// Gets/sets the navigate to home menu item action
		/// </summary>
		/// <value>The navigate to home.</value>
		public ICommand NavigateToHome { get; private set; }

		/// <summary>
		/// Gets/sets the navigate to health menu item action
		/// </summary>
		/// <value>The navigate to health.</value>
		public ICommand NavigateToHealth { get; private set; }

		/// <summary>
		/// Gets/sets the navigate to forums menu item action
		/// </summary>
		/// <value>The navigate to forums.</value>
		public ICommand NavigateToForums { get; private set; }

		/// <summary>
		/// Gets/sets the navigate to resources menu item action
		/// </summary>
		/// <value>The navigate to resources.</value>
		public ICommand NavigateToResources { get; private set; }

		/// <summary>
		/// Gets/sets the navigate to my account menu item action
		/// </summary>
		/// <value>The navigate to my account.</value>
		public ICommand NavigateToMyAccount { get; private set; }

		/// <summary>
		/// Gets/sets the navigate to logout menu item action
		/// </summary>
		/// <value>The navigate to logout.</value>
		public ICommand NavigateToLogout { get; private set; }

		/// <summary>
		/// The navigation service.
		/// </summary>
		private IMyNavigationService navigationService;

		/// <summary>
		/// List containing the items to be displayed in the side menu
		/// </summary>
		private List<MenuItem> menuList = new List<MenuItem> ();
		public List<MenuItem> MenuList {
			get { return menuList; }
			set { ; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.SideMenuViewModel"/> class.
		/// </summary>
		/// <param name="navigationService">Navigation service.</param>
		public SideMenuViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;

			// Add a command to our home navigation ICommand
			NavigateToHome = new Command (x => {
				this.navigationService.NavigateToModal(ViewModelLocator.PeniMasterDetail);
				Debug.WriteLine("SideMenuViewModel : NavigateToHome " + navigationService.CurrentPageKey);
			});

			// Add a command to our health navigation ICommand
			NavigateToHealth = new Command (() => {
				this.navigationService.NavigateToModal(ViewModelLocator.DashboardKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToHealth " + navigationService.CurrentPageKey);
			});

			// Add a command to our forum navigation ICommand
			NavigateToForums = new Command (x => {
				this.navigationService.NavigateToModal(ViewModelLocator.ForumsPageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToForums " + navigationService.CurrentPageKey);
			});

			// Add a command to our account navigation ICommand
			NavigateToMyAccount = new Command (x => {
				this.navigationService.NavigateToModal(ViewModelLocator.MyProfilePageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToMyAccount " + navigationService.CurrentPageKey);
			});

			// Add a command to our logout navigation ICommand
			NavigateToLogout = new Command (() => {
				this.navigationService.NavigateToModal(ViewModelLocator.LoginPageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToLayout " + navigationService.CurrentPageKey);
			});
			// End of command actions

			setupMenuNavigation ();
		}

		/// <summary>
		/// Adds our navigation items to our navigation ListView.
		/// </summary>
		private void setupMenuNavigation() {
			menuList.Add (new MenuItem () { 
				Title = "Home", 
				IconSource = "ic_home_white_48dp.png", 
				Command = NavigateToHome,
			});

			menuList.Add (new MenuItem () { 
				Title = "Health", 
				IconSource = "ic_favorite_white_48dp.png", 
				Command = NavigateToHealth,
			});

			menuList.Add (new MenuItem () { 
				Title = "Forum", 
				IconSource = "ic_question_answer_white_48dp.png", 
				Command = NavigateToForums,
			});

			menuList.Add(new MenuItem() {
				Title = "My Account",
				IconSource = "ic_account_circle_white_48dp.png",
				Command = NavigateToMyAccount,
			});

			menuList.Add(new MenuItem() {
				Title = "Logout",
				IconSource = "ic_power_settings_new_white_48dp.png",
				Command = NavigateToLogout,
			});
		}
	}
}

