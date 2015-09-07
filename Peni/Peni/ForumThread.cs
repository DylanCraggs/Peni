using System;
using Xamarin.Forms.Xaml;

namespace Peni
{
	public class ForumThread
	{
		public int TopicID { get; set; }
		public string TopicFavorite { get; set; }
		public string TopicName { get; set; }
		public string TopicComments { get; set; }
		public string TopicAuthor { get; set; }
		public string TopicCreationDate { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.ForumThread"/> class.
		/// </summary>
		/// <param name="TopicName">The name of a thread.</param>
		/// <param name="TopicComments">Number of comments on a thread.</param>
		/// <param name="TopicAuthor">The author of a thread.</param>
		/// <param name="TopicCreationDate">The creation date of a thread.</param>
		public ForumThread (int TopicID, string TopicName, int TopicComments, string TopicAuthor, string TopicCreationDate)
		{
			this.TopicID = TopicID;
			// This obviously needs to be replaced with the proper image
			this.TopicFavorite = "http://i.imgur.com/q7cu36s.png";
			this.TopicName = TopicName;
			this.TopicComments = TopicComments + " Comments";
			this.TopicAuthor = TopicAuthor;
			this.TopicCreationDate = TopicCreationDate;
		}
	}
}

