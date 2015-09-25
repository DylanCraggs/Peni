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
		/// Gets/sets the navigate to home.
		/// </summary>
		/// <value>The navigate to home.</value>
		public ICommand NavigateToHome { get; private set; }

		/// <summary>
		/// Gets/sets the navigate to health.
		/// </summary>
		/// <value>The navigate to health.</value>
		public ICommand NavigateToHealth { get; private set; }

		/// <summary>
		/// Gets/sets the navigate to forums.
		/// </summary>
		/// <value>The navigate to forums.</value>
		public ICommand NavigateToForums { get; private set; }

		/// <summary>
		/// Gets/sets the navigate to resources.
		/// </summary>
		/// <value>The navigate to resources.</value>
		public ICommand NavigateToResources { get; private set; }

		/// <summary>
		/// Gets/sets the navigate to my account.
		/// </summary>
		/// <value>The navigate to my account.</value>
		public ICommand NavigateToMyAccount { get; private set; }

		/// <summary>
		/// Gets/sets the navigate to logout.
		/// </summary>
		/// <value>The navigate to logout.</value>
		public ICommand NavigateToLogout { get; private set; }

		/// <summary>
		/// The navigation service.
		/// </summary>
		private IMyNavigationService navigationService;

		/// <summary>
		/// The side menu item list.
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

			// Start of command actions
			NavigateToHome = new Command (x => {
				if(navigationService.CurrentPageKey == ViewModelLocator.PeniMasterDetail) {
					return;
				}

				this.navigationService.NavigateTo(ViewModelLocator.PeniMasterDetail);
				Debug.WriteLine("SideMenuViewModel : NavigateToHome " + navigationService.CurrentPageKey);
			});

			NavigateToHealth = new Command (() => {
				//this.navigationService.NavigateTo(ViewModelLocator.HealthPageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToHealth " + navigationService.CurrentPageKey);
			});

			NavigateToForums = new Command (x => {
				// Check if we are already viewing the same page before pushing another to navigation service
				if(navigationService.CurrentPageKey == ViewModelLocator.ForumsPageKey) {
					return;
				}

				this.navigationService.NavigateTo(ViewModelLocator.ForumsPageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToForums " + navigationService.CurrentPageKey);
			});

			NavigateToResources = new Command (() => {
				Debug.WriteLine("SideMenuViewModel : NavigateToResources " + navigationService.CurrentPageKey);
			});

			NavigateToMyAccount = new Command (x => {
				if(navigationService.CurrentPageKey == ViewModelLocator.MyProfilePageKey) {
					return;
				}
				this.navigationService.NavigateTo(ViewModelLocator.MyProfilePageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToMyAccount " + navigationService.CurrentPageKey);
			});
				
			NavigateToLogout = new Command (() => {
				//this.navigationService.NavigateTo(ViewModelLocator.LogoutPageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToLayout " + navigationService.CurrentPageKey);
			});
			// End of command actions

			setupMenuNavigation ();
		}

		/// <summary>
		/// Setups the menu navigation items.
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
				Title = "Resources",
				IconSource = "ic_local_library_white_48dp.png",
				Command = NavigateToResources,
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

