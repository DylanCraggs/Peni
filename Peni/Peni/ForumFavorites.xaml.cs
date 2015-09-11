using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Peni
{
	public partial class ForumFavorites : ContentPage
	{
		public ForumFavorites ()
		{
			InitializeComponent ();

			var threads = new List<ForumThread> ();
			for (int i = 0; i < 5; ++i) {
				threads.Add (new ForumThread (i, "Topic Title", i + 1, "Dylan", "8 Sept 2015"));
			}

			FavoritesListView.ItemsSource = threads;
		}
	}
}

