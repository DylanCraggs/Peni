using System;

namespace Peni
{
	public class Thread
	{
		private int thread_id;
		public string thread_title;

		private int owner_id;
		public string owner_username;

		public int number_of_comments;
		public DateTime listing_date;

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Thread"/> class.
		/// </summary>
		/// <param name="thread_id">Thread identifier.</param>
		/// <param name="thread_title">Thread title.</param>
		/// <param name="owner_id">Owner identifier.</param>
		/// <param name="owner_username">Owner username.</param>
		/// <param name="number_of_comments">Number of comments.</param>
		/// <param name="listing_date">Listing date.</param>
		public Thread (int thread_id, string thread_title, int owner_id, string owner_username, int number_of_comments, DateTime listing_date)
		{
			this.thread_id = thread_id;
			this.thread_title = thread_title;
			this.owner_id = owner_id;
			this.owner_username = owner_username;
			this.number_of_comments = number_of_comments;
			this.listing_date = DateTime.Now;
		}
	}
}

