using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using Xamarin.Forms;
using Peni.Data.ViewModel;
using System.ComponentModel;

namespace Peni.Data
{
	public class LoginViewModel : ViewModelBase
	{

		public ICommand SubmitLoginCommand { get; private set; }

		private IMyNavigationService navigationService;

		private string username;
		public string Username
		{
			get { return username; }
			set { username = value;
				RaisePropertyChanged(() => Username); }
		}

		private string password;
		public string Password
		{
			get { return password; }
			set { password = value;
				RaisePropertyChanged(() => Password); }
		}

		private string errorMessage;
		public string ErrorMessage {
			get { return errorMessage; }
			set { ; }
		}

		public LoginViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
			SubmitLoginCommand = new Command (() => {
				if(Username == null || Password == null) {
					this.errorMessage = "Please enter a username and password.";
					RaisePropertyChanged(() => ErrorMessage);
				} else {
					this.errorMessage = null;
					RaisePropertyChanged(() => ErrorMessage);
					this.navigationService.NavigateToModal(ViewModelLocator.PeniMasterDetail);
				}
			});
		}
	}
}

