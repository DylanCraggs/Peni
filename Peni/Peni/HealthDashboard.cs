using System;

using Xamarin.Forms;

namespace Peni
{
	public class HealthDashboard : ContentPage
	{
		public HealthDashboard ()
		{


			int numbercups = 0;

			//BUTTONS ARGH
			Button addWater = new Button {
				Text = "+",
				HorizontalOptions = LayoutOptions.Center
			};

			Button removeWater = new Button {
				Text = "-",
				HorizontalOptions = LayoutOptions.Center
			};


			StackLayout waterstack1 = new StackLayout {


				Children = { // Daily Water

					new Label { 
						Text = "Today",
						TextColor = Color.Blue,
						Style = Device.Styles.SubtitleStyle 
					},

					new Label { Text = "Water Goal 8 Cups" },  // pull this from database eventually

					new Entry { Text = "? Cups" },

					// progress bar

				}, // ends children

			}; // ends water stack 1

			Label labelcups = new Label 
			{
				Text = numbercups.ToString(),
			};


			StackLayout waterstack2 = new StackLayout {


				Children = { // Water Counter

					addWater,
					labelcups,
					removeWater,

					//removeWater,

				}, // ends children

			}; // ends water stack 1

			addWater.Clicked += (sender, EventArgs) => {
				numbercups += 1;
				labelcups.Text = numbercups.ToString();

			};

			removeWater.Clicked += (sender, EventArgs) => {
				numbercups -= 1;
				labelcups.Text = numbercups.ToString();

			};

			Grid gridwater = new Grid {
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Auto },
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
				},

			}; // ends water grid

			gridwater.Children.Add(waterstack1,0,0);
			gridwater.Children.Add(waterstack2,1,0);

			StackLayout stacklayoutwater = new StackLayout {

				BackgroundColor = Color.FromHex("F6905D"), // orange

				Children = {

					new Label { 
						Text = "Water",
						TextColor = Color.Blue,
						Style = Device.Styles.TitleStyle
					},
					// title

					gridwater,

					// weekly information
					new Label { 
						Text = "Week",
						TextColor = Color.Blue,
						Style = Device.Styles.SubtitleStyle
					},

					new Frame {
						// graph for the week goes here
					}

				}, // ends children

			}; // ends water-stacklayout

			// FOOD!!!

			StackLayout foodstack1 = new StackLayout {


				Children = { // Daily Water

					new Label { 
						Text = "Today",
						TextColor = Color.Blue,
						Style = Device.Styles.SubtitleStyle 
					},

					new Label { Text = "Protein" },  

					new Entry { Text = "30" },

					new Label { Text = "Carbs" },  

					new Entry { Text = "30" },

					new Label { Text = "Fat" },  

					new Entry { Text = "40" },
					// progress bar

				}, // ends children

			}; // ends food stack 1

			StackLayout foodstack2 = new StackLayout {


				Children = {
					new Label { Text = "beautiful macro graph" }, 
				}, // ends children

			}; // ends food stack 2

			Grid gridfood = new Grid {
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Auto },
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
				},

			}; // ends water grid

			gridfood.Children.Add(foodstack1,0,0);
			gridfood.Children.Add(foodstack2,1,0);

			StackLayout stacklayoutfood = new StackLayout {

				BackgroundColor = Color.FromHex("F16379"), // pink

				Children = {

					new Label { 
						Text = "Food",
						TextColor = Color.Blue,
						Style = Device.Styles.TitleStyle
					},

					gridfood,
				}, // ends children

			}; // ends Food-stacklayout

			StackLayout stacklayoutexercise = new StackLayout {


				BackgroundColor = Color.FromHex("F6905D"), // orange

				Children = {

					new Label { 
						Text = "Exercise",
						TextColor = Color.Blue,
						Style = Device.Styles.TitleStyle
					},

					// today

					new Label { 
						Text = "Today",
						TextColor = Color.Blue,
						Style = Device.Styles.SubtitleStyle 
					},

					// weekly

					new Label { 
						Text = "This Week",
						TextColor = Color.Blue,
						Style = Device.Styles.SubtitleStyle 
					},

				}, // ends children

			}; // ends Food-stacklayout
			StackLayout stackLayout = new StackLayout { // Main Stacklayout

				BackgroundColor = Color.White,

				Children = {

					// Health Dashboard
					// Water
					stacklayoutwater,

					// Food
					stacklayoutfood,

					// Exersice
					stacklayoutexercise,

				}, // ends children


			}; // ends stacklayout 

			// Water Stacklayout



			Content = new ScrollView { 

				Content = stackLayout 

			}; // ends content scrollveiw

		}
	}
}


