using System;

using Xamarin.Forms;

namespace Peni
{
	public class MenuPage : ContentPage
	{
		public ListVeiw MenuItem { get; set; }

		public MenuPage ()
		{
			Icon = "Settings.png";
			Title = "menu"; // the title property must be set
			BackgroundColor = Color.FromHex ("333333");

			Menu = new MenuListVeiw ();

			var menuLabel = new ContentPageView {
				Padding = new Thickness (10, 36, 0, 5),
				Content = new Label {
					TextColor = Color.FromHex ("AAAAAA"),
					Text = "MENU"
				}
			};

			var layout = new StackLayout { 
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			Layout.Children.Add (menuLabel);
			layout.Children.Add (Menu);

			Content = layout;

		}
	}
}


