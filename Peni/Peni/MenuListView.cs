using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Peni
{

	public class MenuListView : ListView
	{
		public MenuListView ()
		{
			BindingContext = App.Locator.SideMenu;
			List<MenuItem> data = new MenuListData ();

			ItemsSource = data;
			VerticalOptions = LayoutOptions.FillAndExpand;
			BackgroundColor = Color.Transparent;
			SeparatorVisibility = SeparatorVisibility.None;

			var cell = new DataTemplate (typeof(MenuCell));
			cell.SetBinding (MenuCell.TextProperty, "Title");
			cell.SetBinding (MenuCell.ImageSourceProperty, "IconSource");
			cell.SetBinding (MenuCell.CommandProperty, "Command");

			ItemTemplate = cell;
		}
	}
}