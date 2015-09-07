using System;
using System.Collections.Generic;

using Xamarin.Forms;


namespace Peni
{
	public partial class Forums : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Forums"/> class.
		/// </summary>
		public Forums ()
		{
			InitializeComponent ();

			var threads = new List<ForumThread> ();
			for (int i = 0; i < 10; ++i) {
				threads.Add (new ForumThread (i, "Hello World", i, "Dylan", "23 Aug 2015"));
			}

			ForumListView.ItemsSource = threads;
		}
	}
}

