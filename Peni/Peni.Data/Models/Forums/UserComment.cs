using System;
using SQLite.Net.Attributes;

namespace Peni.Data
{
	public class UserComment
	{
		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		public int ThreadID { get; set; }
		public string Username { get; set; }
		public string Comment { get; set; }
		public string Date { get; set; }

		public UserComment (int ThreadID, string Username, string Comment, string Date)
		{
			this.ThreadID = ThreadID;
			this.Username = Username;
			this.Comment = Comment;
			this.Date = Date;
		}

		public UserComment() { }
	}
}

