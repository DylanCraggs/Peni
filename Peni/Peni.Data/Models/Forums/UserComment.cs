using System;
using SQLite.Net.Attributes;

namespace Peni
{
	public class UserComment
	{
		[PrimaryKey, AutoIncrement]
		public Guid id { get; set; }
		public Guid ThreadID { get; set; }
		public string Username { get; set; }
		public string Comment { get; set; }
		public string Date { get; set; }

		public UserComment (Guid ThreadID, string Username, string Comment, string Date)
		{
			this.ThreadID = ThreadID;
			this.Username = Username;
			this.Comment = Comment;
			this.Date = Date;
		}

		public UserComment() { }
	}
}

