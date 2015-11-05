using System;
using GalaSoft.MvvmLight;

namespace Peni.Data
{
	public class ProfilePageViewModel : ViewModelBase
	{

		private IMyNavigationService navigationService;

		private string username;
		public string Username {
			get { return username; }
			set { 
				username = value;
				RaisePropertyChanged (() => Username);
			}
		}

		private string stage;
		public string Stage {
			get { return stage; }
			set {
				stage = value;
				RaisePropertyChanged (() => Stage);
			}
		}

		private string bio;
		public string Bio {
			get { return bio; }
			set {
				bio = value;
				RaisePropertyChanged (() => Bio);
			}
		}

		private bool privateProfile;
		public bool PrivateProfile {
			get { return privateProfile; }
			set {
				privateProfile = value;
				RaisePropertyChanged (() => PrivateProfile);
			}
		}

		public ProfilePageViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
			SetupValues ();
		}

		private void SetupValues() {
			this.Username = Globals.UserSession.Username;
			this.Stage = Globals.UserSession.UserStage.ToString ();
			this.Bio = Globals.UserSession.UserBio;
			this.PrivateProfile = Globals.UserSession.UserPrivacy;
		}
	}
}

