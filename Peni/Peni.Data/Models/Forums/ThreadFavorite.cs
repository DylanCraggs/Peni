using System;
using SQLite.Net.Attributes;

namespace Peni
{
	public class ThreadFavorite
	{
		[PrimaryKey, AutoIncrement]
		public Guid id { get; set; }
		public Guid ThreadID { get; set; }
		public Guid UserID { get; set; }

		public ThreadFavorite () {}

		public ThreadFavorite(Guid ThreadID, Guid UserID) {
			this.ThreadID = ThreadID;
			this.UserID = UserID;
		}
	}
}

