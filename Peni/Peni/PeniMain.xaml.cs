
﻿using System;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using Peni.Data.ViewModel;

namespace Peni
{

	public partial class PeniMainContet : ContentPage
	{
		public PeniMainContet()
		{
			InitializeComponent();
			//this.BindingContext = App.Locator.MainPage;

			Grid myGrid = new Grid();
			myGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
			myGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

			Image peni = new Image
			{

				HeightRequest = 420,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.White
			};



			Button mapIcon = new Button
			{

				HeightRequest = 80,
				WidthRequest = 100,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.End,
				BackgroundColor = Color.Transparent,
				Image = "maps_icon.png",

			};

			mapIcon.Clicked+= async (sender, e) => 
			{
				await Navigation.PushAsync(new MapPageMasterDetail());
			};

			//Logic to change peni expression (img). Must be finished after implementing health database and logic
			//1 == Defaul expression (Happy)/ 2 == thirsty / 3 == Hungry / 4 == Feelings (Journal)
			int expression = 1;
			Random randomValue = new Random();
			expression = randomValue.Next(1,5); 


			switch (expression) {
			case 1:
				peni.Source = "peni_happy.png";
				break;
			case 2:
				peni.Source = "peni_thirsty.png";
				break;
			case 3:
				peni.Source = "peni_hungry.png";
				break;
			case 4:
				peni.Source = "peni_feelings.png";
				break;
			default:
				peni.Source = "peni_happy.png";
				break;
			}

			myGrid.Children.Add (peni);
			Grid.SetRow (peni, 1);
			Grid.SetColumn (peni, 0);
			Grid.SetColumnSpan (peni, 3);

			myGrid.Children.Add (mapIcon);
			Grid.SetRow (mapIcon, 1);
			Grid.SetColumn (mapIcon, 2);

			//If there's water notification, then display image. Must be finished the logic with the database
			if (App.Locator.MainPage.WaterNeeded==true) {
				Button waterNotification = new Button
				{

					HeightRequest = 100,
					VerticalOptions = LayoutOptions.End,
					HorizontalOptions = LayoutOptions.End,
					BackgroundColor = Color.Transparent,
					Image = "cloud_water.png",
					Command = (Command)App.Locator.MainPage.BeamToWater
				};
				/*
				waterNotification.Clicked+= async (sender, e) => 
				{
					await Navigation.PushAsync(new AddWaterPage());
				};
*/
				myGrid.Children.Add (waterNotification);
				Grid.SetRow (waterNotification, 0);
				Grid.SetColumn (waterNotification, 0);
			}

			//If there's food notification, then display image. Must be finished the logic with the database
			if (App.Locator.MainPage.FoodNeeded==true) {
				Button foodNotification = new Button
				{

					HeightRequest = 100,
					VerticalOptions = LayoutOptions.End,
					HorizontalOptions = LayoutOptions.End,
					BackgroundColor = Color.Transparent,
					Image = "cloud_food.png",
					Command = (Command)App.Locator.MainPage.BeamToFood
				};



				myGrid.Children.Add (foodNotification);
				Grid.SetRow (foodNotification, 0);
				Grid.SetColumn (foodNotification, 2);
			}

			//If there's other notification, then display image. Must be finished the logic with the database
			if (true) {
				Button feelingsNotification = new Button
				{

					HeightRequest = 100,
					VerticalOptions = LayoutOptions.End,
					HorizontalOptions = LayoutOptions.End,
					BackgroundColor = Color.Transparent,
					Image = "cloud_feelings.png",
					Command = (Command)App.Locator.MainPage.BeamToFeels

				};
						
				myGrid.Children.Add (feelingsNotification);
				Grid.SetRow (feelingsNotification, 0);
				Grid.SetColumn (feelingsNotification, 1);
			}


			Content = new Frame { 
				Content = myGrid
			};
		}
	}// ends public class

	public class PeniMasterDetail : MasterDetailPage
	{
		public PeniMasterDetail()
		{
			Title = "Home";
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			Detail = new PeniMainContet();

			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}
	}
}
// ends namespace