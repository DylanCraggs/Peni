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
		public ForumThreadPage (Thread thread) {
			InitializeComponent ();
			BindingContext = thread;

			// -- NOTES DYLAN CRAGGS -- //

			// * PostContent needs to be black text on white background instead of white on white //
			// * CommentBox needs to be in a fixed location when scrolling //
			// * Placeholder text needs to be black (currently white and on a white background you obviously can't see it..) //
		}
	}
}

