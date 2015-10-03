 using System;

using Xamarin.Forms;

namespace Peni
{
	public class HealthDashboard : ContentPage
	{
		public HealthDashboard ()
		{

			// Water !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

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
						TextColor = Color.FromHex ("002351"),
						Style = Device.Styles.SubtitleStyle 
					},

					new Label { Text = "Water Goal 8 Cups" },  // pull this from database eventually

					new Entry { Text = "? Cups" },


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
						TextColor = Color.FromHex ("002351"),
						Style = Device.Styles.TitleStyle
					},

					new BoxView {
						Color = Color.White,
						HeightRequest = 3,
					},

					gridwater,

					// weekly information
					new Label { 
						Text = "Week",
						TextColor = Color.FromHex ("002351"),
						Style = Device.Styles.SubtitleStyle
					},

					new Frame {
						// graph for the week goes here
					}

				}, // ends children

			}; // ends water-stacklayout

			// FOOD!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

			Grid gridfoodintake = new Grid {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
				},

			};

			gridfoodintake.Children.Add(new Label { Text = "Protein",  HorizontalOptions = LayoutOptions.Center},0,0);
			gridfoodintake.Children.Add(new Entry { Text = "30" },0,1);  

			gridfoodintake.Children.Add(new Label { Text = "Carbs", HorizontalOptions = LayoutOptions.Center },1,0);
			gridfoodintake.Children.Add(new Entry { Text = "30" },1,1);  

			gridfoodintake.Children.Add(new Label { Text = "Fat", HorizontalOptions = LayoutOptions.Center },2,0);
			gridfoodintake.Children.Add(new Entry { Text = "40" },2,1); 

			StackLayout foodstack1 = new StackLayout {


				Children = { // food intake

					new Label { 
						Text = "Today",
						TextColor = Color.FromHex ("002351"),
						Style = Device.Styles.SubtitleStyle 
					},

					new Image
					{
						// Will link to my fitness pal
						Source = ImageSource.FromFile("mfp_icon.jpeg"),
						VerticalOptions = LayoutOptions.Center,
						HorizontalOptions = LayoutOptions.Center,
						HeightRequest = 50,
							
					},

					//grid intake
					gridfoodintake,
					// progress bar

				}, // ends children

			}; // ends food stack 1

			StackLayout foodstack2 = new StackLayout {

				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,

				Children = {

					new Image
					{
						Source = ImageSource.FromFile("temp_piechart.jpg"),
						HeightRequest = 150,

					},

				}, // ends children

			}; // ends food stack 2

		

			Grid gridfood = new Grid {
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
				},

			}; // ends water grid
					
			gridfood.Children.Add(foodstack1,0,0); // food intake
			gridfood.Children.Add(foodstack2,1,0); // macros graph

			StackLayout stacklayoutfood = new StackLayout {

				BackgroundColor = Color.FromHex("F16379"), // pink

				Children = {

					new Label { 
						Text = "Food",
						TextColor = Color.FromHex ("002351"),
						Style = Device.Styles.TitleStyle
					},

					new BoxView {
						Color = Color.White,
						HeightRequest = 3,
					},

					gridfood,
				}, // ends children

			}; // ends Food-stacklayout

			// Exercise !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!



			StackLayout stacklayoutmon = new StackLayout {
				Orientation = StackOrientation.Horizontal,

				Children = {
					
					new Label { 
						Text = "Yoga",
						HorizontalOptions = LayoutOptions.StartAndExpand,
					},

					new Entry { 
						Text = "mins",
						HorizontalOptions = LayoutOptions.EndAndExpand,
					},
				},

			};

			StackLayout stacklayouttue = new StackLayout {
				Orientation = StackOrientation.Horizontal,

				Children = {

					new Label { 
						Text = "Running",
						HorizontalOptions = LayoutOptions.StartAndExpand,
					},

					new Entry { 
						Text = "mins",
						HorizontalOptions = LayoutOptions.EndAndExpand,
					},
				},

			};

			StackLayout stacklayoutwed = new StackLayout {
				Orientation = StackOrientation.Horizontal,

				Children = {

					new Label { 
						Text = "Yoga",
						HorizontalOptions = LayoutOptions.StartAndExpand,
					},

					new Entry { 
						Text = "mins",
						HorizontalOptions = LayoutOptions.EndAndExpand,
					},
				},

			};

			StackLayout stacklayoutthurs = new StackLayout {
				Orientation = StackOrientation.Horizontal,

				Children = {

					new Label { 
						Text = "Running",
						HorizontalOptions = LayoutOptions.StartAndExpand,
					},

					new Entry { 
						Text = "mins",
						HorizontalOptions = LayoutOptions.EndAndExpand,
					},
				},

			};

			StackLayout stacklayoutfri = new StackLayout {
				Orientation = StackOrientation.Horizontal,

				Children = {

					new Label { 
						Text = "Running",
						HorizontalOptions = LayoutOptions.StartAndExpand,
					},

					new Entry { 
						Text = "mins",
						HorizontalOptions = LayoutOptions.EndAndExpand,
					},
				},

			};

			StackLayout stacklayoutsteps = new StackLayout {
				Orientation = StackOrientation.Horizontal,

				Children = {

					new Label { 
						Text = "Current steps", // need to get this from the goal page
						HorizontalOptions = LayoutOptions.StartAndExpand,
					},

					new Entry {
						Text = "0 steps",
						HorizontalOptions = LayoutOptions.EndAndExpand,
					},

				},

			};

			ProgressBar progresssteps = new ProgressBar {

				Progress = .2,

			};

			Frame frameprogress = new Frame {

				Content = progresssteps,

			};
						

			StackLayout stacklayoutexercise = new StackLayout {


				BackgroundColor = Color.FromHex("F6905D"), // orange

				Children = {

					new Label { 
						Text = "Exercise",
						TextColor = Color.FromHex ("002351"),
						Style = Device.Styles.TitleStyle
					},

					new BoxView {
						Color = Color.White,
						HeightRequest = 3,
					},

					// today

					new Label { 
						Text = "Today",
						TextColor = Color.FromHex ("002351"),
						Style = Device.Styles.SubtitleStyle 
					},

					// DAILY STEPS GOAL

					new Label { 
						Text = "Daily Steps Goal: 10 000", // need to get this from the goal page
					},


					// INSERT PROGRESS BAR

					frameprogress,
					// INSERT CURRENT STEPS AMOUNT

					stacklayoutsteps,

					new BoxView {
						Color = Color.White,
						HeightRequest = 3,
					},

					// weekly

					new Label { 
						Text = "This Week",
						TextColor = Color.FromHex ("002351"),
						Style = Device.Styles.SubtitleStyle 
					},

					// INSERT LIST FOR WORKOUTS
					new Label { 
						Text = "Monday",
						TextColor = Color.FromHex ("002351"),
					},
					stacklayoutmon,

					new Label { 
						Text = "Tuesday",
						TextColor = Color.FromHex ("002351"),
					},
					stacklayouttue,

					new Label { 
						Text = "Wednesday",
						TextColor = Color.FromHex ("002351"),
					},
					stacklayoutwed,

					new Label { 
						Text = "Thursday",
						TextColor = Color.FromHex ("002351"),
					},
					stacklayoutthurs,

					new Label { 
						Text = "Friday",
						TextColor = Color.FromHex ("002351"),
					},
					stacklayoutfri,





					new BoxView {
						Color = Color.White,
						HeightRequest = 3,
					},

					new Image
					{
						Source = ImageSource.FromFile("temp_linegraph.jpg"),
						WidthRequest = 300,

					},


				}, // ends children

			}; // ends exersice stacklayout

			// Weight !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

			StackLayout weightstack1 = new StackLayout {

				HorizontalOptions = LayoutOptions.Center,

				Children = { // Daily Water

					new Label { 
						Text = "Weigh In",
						TextColor = Color.FromHex ("002351"),
						Style = Device.Styles.SubtitleStyle 
					},

					new Entry { Text = "? kg" },


				}, // ends children

			}; // ends weightstack 1

			StackLayout weightstack2 = new StackLayout {

				Children = { 

					new Label { 
						Text = "Goal Weight",
						TextColor = Color.FromHex ("002351"),
						Style = Device.Styles.SubtitleStyle 
					},

					new Image
					{
						Source = ImageSource.FromFile("temp_goalweight.jpg"),
						HeightRequest = 100,

					},


				}, // ends children

			}; // ends water stack 1


			Grid gridweight = new Grid {
				HorizontalOptions = LayoutOptions.CenterAndExpand,

				RowDefinitions = {
					new RowDefinition { Height = GridLength.Auto },
				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
				},

			}; // ends water grid

			gridweight.Children.Add(weightstack1,0,0);
			gridweight.Children.Add(weightstack2,1,0);

			StackLayout stacklayoutweight = new StackLayout {



				BackgroundColor = Color.FromHex("F16379"),

				Children = {

					new Label { 
						Text = "Weight",
						TextColor = Color.FromHex ("002351"),
						Style = Device.Styles.TitleStyle
					},

					new BoxView {
						Color = Color.White,
						HeightRequest = 3,
					},

					gridweight,

					new BoxView {
						Color = Color.White,
						HeightRequest = 3,
					},

					new Label { 
						Text = "Monthly Progress",
						TextColor = Color.FromHex ("002351"),
						Style = Device.Styles.SubtitleStyle 
					},

					new Image
					{
						Source = ImageSource.FromFile("temp_linegraph.jpg"),
						WidthRequest = 300,

					},


				}, // ends children

			}; // ends Food-stacklayout


			// Dashboard !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

			Frame framefood = new Frame {
				Content = stacklayoutfood,
			};

			Frame framewater = new Frame {
				Content = stacklayoutwater,
			};

			Frame frameexercise = new Frame {
				Content = stacklayoutexercise,
			};

			Frame frameweight = new Frame {
				Content = stacklayoutweight,
			};

			StackLayout stackLayout = new StackLayout { // Main Stacklayout

				BackgroundColor = Color.White,

				Children = {

					//settingsbutton, 
					// Health Dashboard
					// Water
					framewater,

					// Food
					framefood,

					// Exersice
					frameexercise,

					// Weightloss
					frameweight,



				}, // ends children


			}; // ends stacklayout 

			Content = new ScrollView { 

				Content = stackLayout 

			}; // ends content scrollveiw

		}
	}
}


