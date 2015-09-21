using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Windows.Input;

namespace Peni
{

	public class MenuItem
	{
		public string Title { get; set; }

		public string IconSource { get; set; }

		public Type TargetType { get; set; }

		public object BindingContext { get; set; }
	}
	
}