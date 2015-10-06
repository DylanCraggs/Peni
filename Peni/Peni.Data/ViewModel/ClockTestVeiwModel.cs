using System;

using Xamarin.Forms;

namespace Peni.Data
{
	public class ClockTestVeiwModel : ContentPage
	{
		public ClockTestVeiwModel ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


