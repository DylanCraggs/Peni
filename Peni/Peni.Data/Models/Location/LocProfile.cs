using System;
using SQLite.Net.Attributes;

namespace Peni.Data
{
	public class LocProfile
	{
		[PrimaryKey, AutoIncrement]
		public Guid id { get; set; }
		public Account Account { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public LocProfile() { }

		public LocProfile(Account Account, double Latitude, double Longitude) 
		{ 
			this.Account = Account;
			this.Latitude = Latitude;
			this.Longitude = Longitude;
		}
	}
}

