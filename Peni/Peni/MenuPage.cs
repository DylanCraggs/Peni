using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Peni
{
	public class MenuPage : ContentPage
	{
		public ListView Menu { get; set; }

		public MenuPage ()
		{
			Icon = "settings.png";
			Title = "menu"; // The Title property must be set.
			BackgroundColor = Color.FromHex ("002351");

			Menu = new MenuListView ();

            Image image = new Image
            {
                // Some differences with loading images in initial release.
                Source = ImageSource.FromFile("drawable/icon.png"),
                HeightRequest = 110,
                VerticalOptions = LayoutOptions.Start
            };


            var whiteMenuFrame = new ContentView
            {
                Padding = new Thickness(2, 15, 2, 15),
                BackgroundColor = Color.White,
                Content = new Image
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Source = ImageSource.FromFile("drawable/app_large_icon.png"),
                    HeightRequest = 90,
                    VerticalOptions = LayoutOptions.Start
                }

            };
            var layout = new StackLayout { 
				Spacing = 0, 
				VerticalOptions = LayoutOptions.FillAndExpand
			};
            
            layout.Children.Add(whiteMenuFrame);
            layout.Children.Add (Menu);

			Content = layout;
		}
	}
}