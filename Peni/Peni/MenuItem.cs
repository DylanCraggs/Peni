using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;
using Peni.Data;
using Peni.Data.ViewModel;
using Peni;

namespace Peni
{

	public class MenuItem
	{
		public string Title { get; set; }

		public string IconSource { get; set; }

		public Type TargetType { get; set; }

		public ICommand Command { get; set; }
	}
}