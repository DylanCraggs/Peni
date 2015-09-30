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

			// Configure rest of apps navigation
			nav.Configure (ViewModelLocator.LoginPageKey, typeof(Login));
			nav.Configure (ViewModelLocator.MainPageKey, typeof(PeniMainContet));
			nav.Configure (ViewModelLocator.PeniMasterDetail, typeof(PeniMasterDetail));
			nav.Configure (ViewModelLocator.ForumsPageKey, typeof(PeniForums));
			nav.Configure (ViewModelLocator.ForumsNewThreadPageKey, typeof(ForumsNewThread));
			nav.Configure (ViewModelLocator.MyProfilePageKey, typeof(EditProfile));
			nav.Configure (ViewModelLocator.ForumsViewThreadPageKey, typeof(ForumThreadPage));
			SimpleIoc.Default.Register<IMyNavigationService> (()=> nav, true);

			var navPage = new NavigationPage(new Profile());
			nav.Initialize (navPage);
			return navPage;
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

