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
			threads.Add (new ForumThread ("Hello World", 5, "Dylan", "23 Aug 2015"));
			threads.Add (new ForumThread ("Hello Bob", 9, "Robot", "13 Sep 2015"));

			ForumListView.ItemsSource = threads;
		}
	}
}

