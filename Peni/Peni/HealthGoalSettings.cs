using System;

using Xamarin.Forms;

namespace Peni
{
	public class HealthGoalSettings : ContentPage
	{
		public HealthGoalSettings ()
		{
            Title = "Health";
            Icon = "drawable/ic_favorite_white_48dp.png";

            Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


