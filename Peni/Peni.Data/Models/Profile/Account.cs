using System;
using SQLite.Net.Attributes;

namespace Peni.Data
{
	public class Account
	{

		[PrimaryKey, AutoIncrement]
		public string id { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public int UserStage { get; set; }
		public string UserBio { get; set; }
		public string UserStatus { get; set; }
		public bool UserPrivacy { get; set; }

		public Account () { }

		public Account(string Email, string Username, string Password, int UserStage, 
			string UserBio, string UserStatus, bool UserPrivacy) {

			this.Email = Email.ToLower();
			this.Username = Username;
			this.Password = Password.ToLower();
			this.UserStage = UserStage;
			this.UserBio = UserBio;
			this.UserStatus = UserStatus;
			this.UserPrivacy = UserPrivacy;
		}
	}
}

