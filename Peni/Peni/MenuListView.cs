using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Peni.Data.ViewModel;
using Peni.Data;
using System.Diagnostics;

namespace Peni
{
	/// <summary>
	/// Creates the menu list items view
	/// </summary>
	public class MenuListView : ListView
	{
		public MenuListView ()
		{

			Binding item_src_binder = new Binding ("MenuList") {
				Source = App.Locator.SideMenu
			};

			SetBinding (ItemsSourceProperty, item_src_binder);

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