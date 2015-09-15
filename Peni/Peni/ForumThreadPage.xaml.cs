/// <summary>
/// Class for reading a thread that is on the forum
/// </summary>

using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Peni
{
	public partial class ForumThreadPage : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.ForumThreadPage"/> class.
		/// </summary>
		public ForumThreadPage (ForumThread thread) {
			InitializeComponent ();

			listingAuthorLbl.SetBinding (Label.TextProperty, "TopicAuthor");
			listingCommentsLbl.SetBinding (Label.TextProperty, "TopicComments");
			listingDateLbl.SetBinding (Label.TextProperty, "TopicCreationDate");
			listingTitleLbl.SetBinding (Label.TextProperty, "TopicName");
			listingContentLbl.SetBinding (Label.TextProperty, "TopicPostContent");

			listingAuthorLbl.BindingContext = thread;
			listingCommentsLbl.BindingContext = thread;
			listingDateLbl.BindingContext = thread;
			listingTitleLbl.BindingContext = thread;
			listingContentLbl.BindingContext = thread;

			// -- NOTES DYLAN CRAGGS -- //

			// * PostContent needs to be black text on white background instead of white on white //
			// * CommentBox needs to be in a fixed location when scrolling //
			// * Placeholder text needs to be black (currently white and on a white background you obviously can't see it..) //
		}
	}
}

