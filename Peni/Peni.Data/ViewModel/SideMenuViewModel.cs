using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Peni.Data.ViewModel;
using Xamarin.Forms;
using System.Diagnostics;

namespace Peni.Data
{
	public class SideMenuViewModel : ViewModelBase
	{

		public static ICommand NavigateToHome { get; private set; }
		public static ICommand NavigateToHealth { get; private set; }
		public static ICommand NavigateToForums { get; private set; }
		public static ICommand NavigateToResources { get; private set; }
		public static ICommand NavigateToMyAccount { get; private set; }
		public static ICommand NavigateToLogout { get; private set; }

		private IMyNavigationService navigationService;

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
		}
	}
}

