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
			set { ; }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.LoginViewModel"/> class.
		/// </summary>
		/// <param name="navigationService">Navigation service.</param>
		public LoginViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
			SubmitLoginCommand = new Command (x => {
				if(Username == null || Password == null) {
					this.errorMessage = "Please enter a username and password.";
					RaisePropertyChanged(() => ErrorMessage);
				} else {
					this.errorMessage = null;
					RaisePropertyChanged(() => ErrorMessage);
					this.navigationService.NavigateTo(ViewModelLocator.PeniMasterDetail);
				}
			});
		}
	}
}

