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

		public const string SideMenuPageKey = "MenuPage";
		public const string SideMenuListView = "MenuPageList";


		public const string LoginPageKey = "Login";
		public const string MainPageKey = "PeniMainContet";
		public const string PeniMasterDetail = "PeniMasterDetail";
		public const string ForumsPageKey = "PeniForums";
		public const string ForumsNewThreadPageKey = "ForumsNewThread";
		public const string MyProfilePageKey = "EditProfile";
		public const string ForumsViewThreadPageKey = "ForumThreadPage";

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

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
        }

		public ForumPageViewModel ForumsListPage {
			get {
				return ServiceLocator.Current.GetInstance<ForumPageViewModel> ();
			}
		}

		public ForumNewThreadViewModel ForumNewThread {
			get {
				return ServiceLocator.Current.GetInstance<ForumNewThreadViewModel> ();
			}
		}

		public LoginViewModel LoginPage {
			get {
				return ServiceLocator.Current.GetInstance<LoginViewModel> ();
			}
		}

		public SideMenuViewModel SideMenu {
			get {
				return ServiceLocator.Current.GetInstance<SideMenuViewModel> ();
			}
		}
			
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}