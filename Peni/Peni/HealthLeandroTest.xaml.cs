using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Peni
{
	public partial class HealthLeandroTest : ContentPage
	{
		public HealthLeandroTest ()
		{
			InitializeComponent();

			Grid myGrid = new Grid();
			myGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
			myGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

			Image food = new Image
			{

				HeightRequest = 400,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.White,
				Source = "card_food_100.png"
			};


			myGrid.Children.Add (food);
			Grid.SetRow (food, 0);
			Grid.SetColumn (food, 0);

			Content = new Frame { 
				Content = myGrid
			};
		}
	}
}

