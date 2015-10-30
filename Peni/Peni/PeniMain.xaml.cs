using System;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using Peni.Data.ViewModel;
using Peni.Data;

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
				
				HeightRequest = 400,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				BackgroundColor = Color.White
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

			//If there's water notification, then display image. Must be finished the logic with the database
			if (true) {
				Image waterNotification = new Image {
					Source = ImageSource.FromFile ("cloud_water.png"),
					HeightRequest = 100,
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.Center,
					BackgroundColor = Color.White
				};

				myGrid.Children.Add (waterNotification);
				Grid.SetRow (waterNotification, 0);
				Grid.SetColumn (waterNotification, 0);
			}

			//If there's food notification, then display image. Must be finished the logic with the database
			if (true) {
				Image foodNotification = new Image {
					Source = ImageSource.FromFile ("cloud_food.png"),
					HeightRequest = 100,
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.Center,
					BackgroundColor = Color.White
				};


				myGrid.Children.Add (foodNotification);
				Grid.SetRow (foodNotification, 0);
				Grid.SetColumn (foodNotification, 2);
			}

			//If there's other notification, then display image. Must be finished the logic with the database
			if (true) {
				Image otherNotification = new Image {
					Source = ImageSource.FromFile ("cloud_feelings.png"),
					HeightRequest = 100,
					VerticalOptions = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.Center,
					BackgroundColor = Color.White
				};

				myGrid.Children.Add (otherNotification);
				Grid.SetRow (otherNotification, 0);
				Grid.SetColumn (otherNotification, 1);
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

}// ends namespace
