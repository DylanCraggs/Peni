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

		public ICommand NavigateToHome { get; private set; }
		public ICommand NavigateToHealth { get; private set; }
		public ICommand NavigateToForums { get; private set; }
		public ICommand NavigateToResources { get; private set; }
		public ICommand NavigateToMyAccount { get; private set; }
		public ICommand NavigateToLogout { get; private set; }

		private IMyNavigationService navigationService;

		private List<MenuItem> menuList = new List<MenuItem> ();
		public List<MenuItem> MenuList {
			get { return menuList; }
			set { ; }
		}

		public SideMenuViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;

			// Implement the commands
			NavigateToHome = new Command (() => {
				//this.navigationService.NavigateTo(ViewModelLocator.HomePageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToHome " + navigationService.CurrentPageKey);
			});

			NavigateToHealth = new Command (() => {
				//this.navigationService.NavigateTo(ViewModelLocator.HealthPageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToHealth " + navigationService.CurrentPageKey);
			});

			NavigateToForums = new Command (() => {
				this.navigationService.NavigateTo(ViewModelLocator.ForumsPageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToForums " + navigationService.CurrentPageKey);
			});

			NavigateToResources = new Command (() => {
				//this.navigationService.NavigateTo(ViewModelLocator.ResourcesPageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToResources " + navigationService.CurrentPageKey);
			});

			NavigateToMyAccount = new Command (() => {
				//this.navigationService.NavigateTo(ViewModelLocator.MyAccountPageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToMyAccount " + navigationService.CurrentPageKey);
			});

			NavigateToLogout = new Command (() => {
				//this.navigationService.NavigateTo(ViewModelLocator.LogoutPageKey);
				Debug.WriteLine("SideMenuViewModel : NavigateToLayout " + navigationService.CurrentPageKey);
			});

			setupMenuNavigation ();
		}

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

