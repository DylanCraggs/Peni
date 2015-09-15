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

			var menuLabel = new ContentView {
				Padding = new Thickness (10, 36, 0, 5),
				Content = new Label {
					TextColor = Color.FromHex ("FFFFFF"),
					Text = "Young Women's Wellness App", 
				}
			};

            var embeddedImage = new Image { Aspect = Aspect.AspectFit };
            embeddedImage.Source = ImageSource.FromResource("circle_flower.png");

            var layout = new StackLayout { 
				Spacing = 0, 
				VerticalOptions = LayoutOptions.FillAndExpand
			};
            layout.Children.Add(menuLabel);
            layout.Children.Add(embeddedImage);

            layout.Children.Add (Menu);

			Content = layout;
		}
	}
}