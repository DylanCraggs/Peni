using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using Peni.Data;
using Peni.Data.ViewModel;
using Peni;

namespace Peni.Data
{
	public class MenuItem
	{
		public string Title { get; set; }
		public string IconSource { get; set; }
		public ICommand Command { get; set; }
	}
}

