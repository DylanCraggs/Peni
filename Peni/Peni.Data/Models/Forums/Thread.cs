using System;
using SQLite.Net.Attributes;
using Xamarin.Forms;
using Peni.Data;

namespace Peni
{
	public class Thread : FavoriteImage
	{
		[PrimaryKey, AutoIncrement]
		public Guid id { get; set; }
		public string TopicName { get; set; }
		public string TopicComments { get; set; }
		public string TopicAuthor { get; set; }
		public string TopicCreationDate { get; set; }
		public string TopicPostContent { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Thread"/> class.
		/// </summary>
		public Thread() {}

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Thread"/> class.
		/// </summary>
		/// <param name="thread_id">Thread identifier.</param>
		/// <param name="thread_title">Thread title.</param>
		/// <param name="owner_id">Owner identifier.</param>
		/// <param name="owner_username">Owner username.</param>
		/// <param name="number_of_comments">Number of comments.</param>
		/// <param name="listing_date">Listing date.</param>
		public Thread (string TopicName, string TopicAuthor,
			string TopicCreationDate, string TopicPostContent) {
			this.TopicName = TopicName;
			this.TopicAuthor = TopicAuthor;
			this.TopicCreationDate = TopicCreationDate;
			this.TopicPostContent = TopicPostContent;
		}
	}
}

