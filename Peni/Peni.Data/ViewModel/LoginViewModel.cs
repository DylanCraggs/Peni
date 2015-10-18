using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using Peni.Data.ViewModel;
using System.ComponentModel;
using System.Diagnostics;

namespace Peni.Data
{
	public class LoginViewModel : ViewModelBase
	{

		/// <summary>
		/// Gets/sets the submit login command.
		/// </summary>
		/// <value>The submit login command.</value>
		public ICommand SubmitLoginCommand { get; private set; }

		/// <summary>
		/// The navigation service.
		/// </summary>
		private IMyNavigationService navigationService;

		/// <summary>
		/// The username of person.
		/// </summary>
		private string username;
		public string Username
		{
			get { return username; }
			set { username = value;
				RaisePropertyChanged(() => Username); }
		}

		/// <summary>
		/// The password of person.
		/// </summary>
		private string password;
		public string Password
		{
			get { return password; }
			set { password = value;
				RaisePropertyChanged(() => Password); }
		}

		/// <summary>
		/// The error message if login fails.
		/// </summary>
		private string errorMessage;
		public string ErrorMessage {
			get { return errorMessage; }
			set { 
				errorMessage = value;
				RaisePropertyChanged (() => ErrorMessage);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.LoginViewModel"/> class.
		/// </summary>
		/// <param name="navigationService">Navigation service.</param>
		public LoginViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
			SubmitLoginCommand = new Command (x => {
				AttemptLogin();
			});
		}

		/// <summary>
		/// Attempts the login using supplied username and password.
		/// </summary>
		private async void AttemptLogin() {
			// Check input has been entered 
			if (Username == null || Password == null) {
				ErrorMessage = "Please enter a username and password.";
				return;
			}

			// Validate details that were entered
			ProfileDatabase database = new ProfileDatabase ();
			if (await database.AttemptLoginAuth (Username, Password)) {
				ErrorMessage = null;
				this.navigationService.NavigateToModal(ViewModelLocator.PeniMasterDetail);
			} else {
				ErrorMessage = "Invalid username or password.";
			}
		}
	}
}

