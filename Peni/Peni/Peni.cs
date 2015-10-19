using System;

using Xamarin.Forms;
using Peni.Data;
using GalaSoft.MvvmLight.Ioc;
using Peni.Data.ViewModel;
using System.Diagnostics;

namespace Peni
{
    public class App : Application
    {
		private static ViewModelLocator _locator;
		private static NavigationService nav;
		public static ViewModelLocator Locator
		{
			get
			{
				return _locator ?? (_locator = new ViewModelLocator());
			}
		}

        public App()
        {
			MainPage = GetMainPage();
        }

		public Page GetMainPage()
		{
			nav = new NavigationService ();

			// If we are running in debug mode attempt to setup our inital data
			// Condition is done inside methods/function so we prevent duplicate entries
			#if DEBUG
			SetupDeveloperAccounts();
			#endif

			// Configure the page keys in ViewModelLocator with the classes
			nav.Configure (ViewModelLocator.LoginPageKey, typeof(Login));
			nav.Configure (ViewModelLocator.MainPageKey, typeof(PeniMainContet));
			nav.Configure (ViewModelLocator.PeniMasterDetail, typeof(PeniMasterDetail));
			nav.Configure (ViewModelLocator.ForumsPageKey, typeof(PeniForums));
			nav.Configure (ViewModelLocator.ForumsNewThreadPageKey, typeof(ForumsNewThread));
			nav.Configure (ViewModelLocator.MyProfilePageKey, typeof(Profile));
			nav.Configure (ViewModelLocator.ForumsViewThreadPageKey, typeof(ForumThreadPage));
			nav.Configure (ViewModelLocator.HealthPageKey, typeof(HealthDashboardMasterDetail));
			nav.Configure (ViewModelLocator.HealthTestKey, typeof(HealthDashboardTest));
			nav.Configure (ViewModelLocator.HealthSettingsKey, typeof(HealthGoalsTest));

			SimpleIoc.Default.Register<IMyNavigationService> (()=> nav, true);

			var navPage = new NavigationPage(new Login() );

			nav.Initialize (navPage);

			return navPage;
		}

		private void SetupDeveloperAccounts() {
			ProfileDatabase profileDb = new ProfileDatabase();

			profileDb.InsertProfile(new Account("dylan@admin.com", "Dylan", "password", 3, "Admin Account Bio", "Admin Account Status", true));
			profileDb.InsertProfile(new Account("sarah@admin.com", "Sarah", "password", 7, "Admin Account Bio", "Admin Account Status", true));
			profileDb.InsertProfile(new Account("yuet@admin.com", "Yuet", "password", 5, "Admin Account Bio", "Admin Account Status", true));
			profileDb.InsertProfile(new Account("leandro@admin.com", "Leandro", "password", 1, "Admin Account Bio", "Admin Account Status", false));
			profileDb.InsertProfile(new Account("michaela@admin.com", "Michaela", "password", 2, "Admin Account Bio", "Admin Account Status", false));
		}


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

	}
}

