/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Peni.Data"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Peni.Data.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {

		// Side Menu Page Keys
		public const string SideMenuPageKey = "MenuPage";
		public const string SideMenuListView = "MenuPageList";

		// Forum Page Keys
		public const string ForumsPageKey = "PeniForums"; // wat
		public const string ForumsNewThreadPageKey = "ForumsNewThread"; //this one
		public const string ForumsViewThreadPageKey = "ForumThreadPage";

		// Login Page Keys
		public const string LoginPageKey = "Login";

		// Main Screen Keys
		public const string MainPageKey = "PeniMainContet";
		public const string PeniMasterDetail = "PeniMasterDetail";

		// Health Screen Keys
		public const string HealthPageKey = "HealthDashboard";
		public const string HealthSettingsKey = "HealthGoalsTest";
		public const string HealthTestKey = "HealthDashboardTest";


		// Profile Page Keys
		public const string MyProfilePageKey = "Profile";

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			// Register our view models
			SimpleIoc.Default.Register<ForumPageViewModel>(() => 
			{
				return new ForumPageViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService>()
				);
			});

			SimpleIoc.Default.Register<ForumNewThreadViewModel> (() => {
				return new ForumNewThreadViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService>()
				);
			});

			SimpleIoc.Default.Register<LoginViewModel> (() => {
				return new LoginViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService>()
				);
			});

			SimpleIoc.Default.Register<SideMenuViewModel> (() => {
				return new SideMenuViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService>()
				);
			});

			// Health Pages 

			SimpleIoc.Default.Register<HealthTestViewModel> (() => {
				return new HealthTestViewModel(
					SimpleIoc.Default.GetInstance<IMyNavigationService>()
				);
			});

        }



		/// <summary>
		/// Gets the ForumPage View Model
		/// </summary>
		public ForumPageViewModel ForumsListPage {
			get {
				return ServiceLocator.Current.GetInstance<ForumPageViewModel> ();
			}
		}

		/// <summary>
		/// Gets the ForumNewThread View Model.
		/// </summary>
		public ForumNewThreadViewModel ForumNewThread {
			get {
				return ServiceLocator.Current.GetInstance<ForumNewThreadViewModel> ();
			}
		}

		/// <summary>
		/// Gets the Login View Model
		/// </summary>
		public LoginViewModel LoginPage {
			get {
				return ServiceLocator.Current.GetInstance<LoginViewModel> ();
			}
		}

		/// <summary>
		/// Gets the side menu view model
		/// </summary>
		/// <value>The side menu.</value>
		public SideMenuViewModel SideMenu {
			get {
				return ServiceLocator.Current.GetInstance<SideMenuViewModel> ();
			}
		}

		/// <summary>
		/// Gets the new step goal.
		/// </summary>
		/// <value>The new step goal.</value>
		public HealthTestViewModel NewStepGoal{
			get {
				return ServiceLocator.Current.GetInstance<HealthTestViewModel> ();
			}
		}


		/// <summary>
		/// Gets the display goals.
		/// </summary>
		/// <value>The display goals.</value>
		//public HealthVeiwGoalsModel DisplayGoals {
			//get {
				//return ServiceLocator.Current.GetInstance<HealthVeiwGoalsModel> ();
			//}
		//}

		/// <summary>
		/// Cleanup this instance.
		/// </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}