using System;

using Xamarin.Forms;

namespace Peni
{
	public class HealthDashboard : ContentPage
	{
		public HealthDashboard ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


