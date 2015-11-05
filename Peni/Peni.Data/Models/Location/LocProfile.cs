using System;
using SQLite.Net.Attributes;

namespace Peni.Data
{
	public class LocProfile
	{
		[PrimaryKey, AutoIncrement]

		public string id { get; set; }
		public Guid UserID { get; set; }
		public string Username { get; set; }
		public int Stage { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public LocProfile() { }

		public LocProfile(Guid UserID, string Username, int stage, double Latitude, double Longitude) 
		{ 
			this.UserID = UserID;
			this.Username = Username;
			this.Stage = stage;
			this.Latitude = Latitude;
			this.Longitude = Longitude;
		}
	}
}

