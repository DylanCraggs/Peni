using System;
using SQLite.Net.Attributes;

namespace Peni
{
	public class JournalTable
	{
		[PrimaryKey, AutoIncrement]
		public int DBID { get; set; }
		public string EntryDate { get; set;}
		public string Rank { get; set; }
		public string JournalEntry { get ; set; }
		public DateTime RecentEntry { get; set; }

		public JournalTable(){
		}

		public JournalTable (string EntryDate, string Rank, string JournalEntry, DateTime RecentEntry)
		{
			this.EntryDate = EntryDate;
			this.Rank = Rank;
			this.JournalEntry = JournalEntry;
			this.RecentEntry = RecentEntry;
		}
	}
}

