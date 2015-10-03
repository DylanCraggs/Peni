using System;
using SQLite.Net.Attributes;

namespace Peni
{
	public class UserProfile
	{
		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		public string LocalUsername { get; set; }
		public int UserStage { get; set; }
		public string UserBio { get; set; }
		public string UserStatus { get; set; }
		public bool UserPrivacy { get; set; } 

		public UserProfile() {}

		public UserProfile (string LocalUsername, int UserStage,
			string UserBio)
		{
			this.LocalUsername = LocalUsername;
			this.UserStage = UserStage;
			this.UserBio = UserBio;
			this.UserStatus = UserStatus;
			this.UserPrivacy = UserPrivacy;

		}

	}
}

