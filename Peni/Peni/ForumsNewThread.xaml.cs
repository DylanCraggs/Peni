using System;
using System.Collections.Generic;

using Peni.Data;
using Xamarin.Forms;

namespace Peni
{
	public partial class ForumsNewThread : ContentPage
	{
		Forums forums;
		public ForumsNewThread (Forums page) {
			InitializeComponent ();
			this.forums = page;
		}

		protected void AddNewThread(object sender, EventArgs e) {
			var Database = new ForumsDatabase ();
			Database.InsertOrUpdateThread(new Thread(Title.Text.ToString(), "Anonymous", DateTime.Now.ToString(), Content.Text.ToString()));
			forums.UpdateList ();
			base.Navigation.RemovePage (this);
		}
	}
}

