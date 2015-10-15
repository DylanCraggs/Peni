﻿using System;
using SQLite.Net.Attributes;

namespace Peni.Data
{
	public class Account
	{

		[PrimaryKey, AutoIncrement]
		public Guid id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public int UserStage { get; set; }
		public string UserBio { get; set; }
		public string UserStatus { get; set; }
		public bool UserPrivacy { get; set; }

		public Account () { }

		public Account(string Email, string Password, int UserStage, 
			string UserBio, string UserStatus, bool UserPrivacy) {

			this.Email = Email;
			this.Password = Password;
			this.UserStage = UserStage;
			this.UserBio = UserBio;
			this.UserStatus = UserStatus;
			this.UserPrivacy = UserPrivacy;
		}
	}
}
