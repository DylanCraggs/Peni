 using System;

using Xamarin.Forms;

namespace Peni
{
	public class HealthDashboard : ContentPage
	{
		public HealthDashboard ()
		{
			var layout = new RelativeLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 125,
				Padding = new Thickness(0)
			};

			var cardBackground = new Image () { 
				Source = "card_food_100.png",
				Aspect = Aspect.Fill
			};

			layout.Children.Add (
				cardBackground,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height);
				})
			);

			Content = new ScrollView { 
				Content = layout 
			};

//			// Water !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//
//			int numbercups = 0;
//
//			//BUTTONS ARGH
//			Button addWater = new Button {
//				Text = "+",
//				HorizontalOptions = LayoutOptions.Center
//			};
//
//			Button removeWater = new Button {
//				Text = "-",
//				HorizontalOptions = LayoutOptions.Center
//			};
//
//			StackLayout stacklayouttodaywater = new StackLayout {
//				Orientation = StackOrientation.Horizontal,
//
//				Children = { // Daily Water
//
//					new Label { 
//						Text = "Today",
//						TextColor = Color.Black,
//						Style = Device.Styles.SubtitleStyle 
//					},
//
//					new Label { 
//						Text = "Water Goal 8 Cups",
//						HorizontalOptions = LayoutOptions.EndAndExpand,
//						TextColor = Color.Black,
//					},  // pull this from database eventually
//						
//				}, // ends children
//
//			};
//
//
//			Label labelcups = new Label 
//			{
//				Text = numbercups.ToString(),
//				TextColor = Color.Black,
//				Style = Device.Styles.TitleStyle,
//
//			};
//
//
//			StackLayout waterstack2 = new StackLayout {
//
//				Orientation = StackOrientation.Horizontal,
//				HorizontalOptions = LayoutOptions.Center, 
//
//				Children = { // Water Counter
//
//					addWater,
//					labelcups,
//					removeWater,
//
//					//removeWater,
//
//				}, // ends children
//
//			}; // ends water stack 1
//
//			addWater.Clicked += (sender, EventArgs) => {
//				numbercups += 1;
//				labelcups.Text = numbercups.ToString();
//
//			};
//
//			removeWater.Clicked += (sender, EventArgs) => {
//				numbercups -= 1;
//				labelcups.Text = numbercups.ToString();
//
//			};
//
//
//			StackLayout stacklayoutwater = new StackLayout {
//
//				BackgroundColor = Color.White, // orange
//
//				Children = {
//
//					new BoxView {
//						Color = Color.FromHex("F16379"),
//						HeightRequest = 2,
//					},
//
//					new Label { 
//						Text = "Water",
//						TextColor = Color.Black,
//						Style = Device.Styles.TitleStyle,
//						FontAttributes = FontAttributes.Bold,
//					},
//
//					new BoxView {
//						Color = Color.FromHex("F16379"),
//						HeightRequest = 2,
//					},
//
//					stacklayouttodaywater,
//
//					new BoxView {
//						Color = Color.FromHex("F6905D"), // orange
//						HeightRequest = 2,
//					},
//
//					waterstack2,
//
//					// weekly information
//					new Label { 
//						Text = "Week",
//						TextColor = Color.Black,
//						Style = Device.Styles.SubtitleStyle
//					},
//
//					new BoxView {
//						Color = Color.FromHex("F6905D"), // orange
//						HeightRequest = 2,
//					},
//
//					new Image
//					{
//						Source = ImageSource.FromFile("temp_linegraph.jpg"),
//						WidthRequest = 300,
//
//					},
//
//				}, // ends children
//
//			}; // ends water-stacklayout
//
//			// FOOD!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//
//			Grid gridfoodintake = new Grid {
//				VerticalOptions = LayoutOptions.Center,
//				HorizontalOptions = LayoutOptions.Center,
//				RowDefinitions = {
//					new RowDefinition { Height = GridLength.Auto },
//					new RowDefinition { Height = GridLength.Auto },
//					new RowDefinition { Height = GridLength.Auto },
//				},
//				ColumnDefinitions = {
//					new ColumnDefinition { Width = GridLength.Auto },
//					new ColumnDefinition { Width = GridLength.Auto },
//
//				},
//
//			};
//
//			gridfoodintake.Children.Add(new Label { Text = "Protein", 
//				HorizontalOptions = LayoutOptions.Center,
//				TextColor = Color.Black,
//				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),},0,0);
//			
//			gridfoodintake.Children.Add(new Entry { Text = "30", TextColor = Color.Black,},1,0);  
//
//			gridfoodintake.Children.Add(new Label { Text = "Carbs", HorizontalOptions = LayoutOptions.Center,
//				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
//				TextColor = Color.Black,
//			},0,1);
//
//			gridfoodintake.Children.Add(new Entry { Text = "30",TextColor = Color.Black, },1,1);  
//
//			gridfoodintake.Children.Add(new Label { Text = "Fat", HorizontalOptions = LayoutOptions.Center,
//				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
//				TextColor = Color.Black,
//			},0,2);
//
//			gridfoodintake.Children.Add(new Entry { Text = "40", TextColor = Color.Black, },1,2); 
//
//
//			StackLayout stacklayouttodayfood = new StackLayout {
//				Orientation = StackOrientation.Horizontal,
//
//				Children = {
//
//					new Label { 
//						Text = "Today",
//						TextColor = Color.Black,
//						Style = Device.Styles.SubtitleStyle 
//					},
//
//					new Image
//					{
//						// Will link to my fitness pal
//						Source = ImageSource.FromFile("mfp_icon.jpeg"),
//						HorizontalOptions = LayoutOptions.EndAndExpand,
//						HeightRequest = 25,
//
//					},
//				},
//
//			};
//
//			StackLayout foodstack1 = new StackLayout {
//
//
//				Children = { // food intake
//
//					//grid intake
//					gridfoodintake,
//
//				}, // ends children
//
//			}; // ends food stack 1
//
//			StackLayout foodstack2 = new StackLayout {
//
//				VerticalOptions = LayoutOptions.Center,
//				HorizontalOptions = LayoutOptions.Center,
//
//				Children = {
//
//					new Image
//					{
//						Source = ImageSource.FromFile("temp_piechart.jpg"),
//						HeightRequest = 150,
//
//					},
//
//				}, // ends children
//
//			}; // ends food stack 2
//
//		
//
//			Grid gridfood = new Grid {
//				VerticalOptions = LayoutOptions.FillAndExpand,
//				RowDefinitions = {
//					new RowDefinition { Height = GridLength.Auto },
//				},
//				ColumnDefinitions = {
//					new ColumnDefinition { Width = GridLength.Auto },
//					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
//				},
//
//			}; // ends water grid
//					
//			gridfood.Children.Add(foodstack1,0,0); // food intake
//			gridfood.Children.Add(foodstack2,1,0); // macros graph
//
//			StackLayout stacklayoutfood = new StackLayout {
//
//				BackgroundColor = Color.White, //Color.FromHex("F16379"), // pink
//
//				Children = {
//
//					new BoxView {
//						Color = Color.FromHex("F16379"),
//						HeightRequest = 2,
//					},
//
//					new Label { 
//						Text = "Food Intake",
//						TextColor = Color.Black,
//						Style = Device.Styles.TitleStyle,
//						FontAttributes = FontAttributes.Bold,
//					},
//
//					new BoxView {
//						Color = Color.FromHex("F16379"),
//						HeightRequest = 2,
//					},
//
//					stacklayouttodayfood,
//
//					new BoxView {
//						Color = Color.FromHex("F6905D"), // orange
//						HeightRequest = 2,
//					},
//
//					gridfood,
//				}, // ends children
//
//			}; // ends Food-stacklayout
//
//			// Exercise !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//
//			// Weekly !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//
//			StackLayout stacklayoutmon = new StackLayout {
//				Orientation = StackOrientation.Horizontal,
//
//				Children = {
//					
//					new Label { 
//						Text = "Yoga",
//						TextColor = Color.Black,
//						HorizontalOptions = LayoutOptions.StartAndExpand,
//						Style = Device.Styles.SubtitleStyle,
//					},
//
//					new Entry { 
//						Text = "mins",
//						HorizontalOptions = LayoutOptions.EndAndExpand,
//						TextColor = Color.Black,
//					},
//				},
//
//			};
//
//			StackLayout stacklayouttue = new StackLayout {
//				Orientation = StackOrientation.Horizontal,
//
//				Children = {
//
//					new Label { 
//						Text = "Running",
//						TextColor = Color.Black,
//						HorizontalOptions = LayoutOptions.StartAndExpand,
//						Style = Device.Styles.SubtitleStyle,
//					},
//
//					new Entry { 
//						Text = "mins",
//						HorizontalOptions = LayoutOptions.EndAndExpand,
//						TextColor = Color.Black,
//					},
//				},
//
//			};
//
//			StackLayout stacklayoutwed = new StackLayout {
//				Orientation = StackOrientation.Horizontal,
//
//				Children = {
//
//					new Label { 
//						Text = "Yoga",
//						TextColor = Color.Black,
//						HorizontalOptions = LayoutOptions.StartAndExpand,
//						Style = Device.Styles.SubtitleStyle,
//					},
//
//					new Entry { 
//						Text = "mins",
//						HorizontalOptions = LayoutOptions.EndAndExpand,
//						TextColor = Color.Black,
//					},
//				},
//
//			};
//
//			StackLayout stacklayoutthurs = new StackLayout {
//				Orientation = StackOrientation.Horizontal,
//
//				Children = {
//
//					new Label { 
//						Text = "Running",
//						TextColor = Color.Black,
//						HorizontalOptions = LayoutOptions.StartAndExpand,
//						Style = Device.Styles.SubtitleStyle,
//					},
//
//					new Entry { 
//						Text = "mins",
//						HorizontalOptions = LayoutOptions.EndAndExpand,
//						TextColor = Color.Black,
//					},
//
//				},
//
//			};
//
//			StackLayout stacklayoutfri = new StackLayout {
//				Orientation = StackOrientation.Horizontal,
//
//				Children = {
//
//					new Label { 
//						Text = "Running",
//						TextColor = Color.Black,
//						HorizontalOptions = LayoutOptions.StartAndExpand,
//						Style = Device.Styles.SubtitleStyle
//					},
//
//					new Entry { 
//						Placeholder = "mins",
//						HorizontalOptions = LayoutOptions.EndAndExpand,
//						TextColor = Color.Black,
//					},
//				},
//
//			};
//
//			StackLayout stacklayoutsteps = new StackLayout {
//				Orientation = StackOrientation.Horizontal,
//
//				Children = {
//
//					new Label { 
//						Text = "Current steps", // need to get this from the goal page
//						HorizontalOptions = LayoutOptions.StartAndExpand,
//						TextColor = Color.Black,
//					},
//
//					new Entry {
//						Text = "0 steps",
//						TextColor = Color.Black,
//						HorizontalOptions = LayoutOptions.EndAndExpand,
//					},
//
//				},
//
//			};
//
//			StackLayout stacklayouttodaysteps = new StackLayout {
//				Orientation = StackOrientation.Horizontal,
//
//				Children = {
//
//					new Label { 
//						Text = "Today",
//						TextColor = Color.Black,
//						Style = Device.Styles.SubtitleStyle 
//					},
//
//					new Label { 
//						Text = "Daily Steps Goal: 10 000",
//						TextColor = Color.Black,
//						HorizontalOptions = LayoutOptions.EndAndExpand
//					},
//
//				},
//
//			};
//
//
//			ProgressBar progresssteps = new ProgressBar {
//
//				Progress = .2,
//
//			};
//
//			Frame frameprogress = new Frame {
//
//				Content = progresssteps,
//
//			};
//						
//
//			StackLayout stacklayoutexercise = new StackLayout {
//				
//				BackgroundColor = Color.White, //Color.FromHex("F6905D"), // orange
//
//				Children = {
//
//					new BoxView {
//						Color = Color.FromHex("F16379"),
//						HeightRequest = 2,
//					},
//
//					new Label { 
//						Text = "Exercise",
//						TextColor = Color.Black,
//						Style = Device.Styles.TitleStyle,
//						FontAttributes = FontAttributes.Bold,
//					},
//
//					new BoxView {
//						Color = Color.FromHex("F16379"),
//						HeightRequest = 2,
//					},
//
//					// needs to go in a stack layout
//
//					stacklayouttodaysteps,
//
//					new BoxView {
//						Color = Color.FromHex("F6905D"), // orange
//						HeightRequest = 2,
//					},
//
//
//					// INSERT PROGRESS BAR
//
//					frameprogress,
//					// INSERT CURRENT STEPS AMOUNT
//
//					stacklayoutsteps,
//
//					new BoxView {
//						Color = Color.White,
//						HeightRequest = 3,
//					},
//
//					// weekly
//
//					new Label { 
//						Text = "This Week",
//						TextColor = Color.Black,
//						Style = Device.Styles.SubtitleStyle 
//					},
//
//					new BoxView {
//						Color = Color.FromHex("F6905D"), // orange
//						HeightRequest = 2,
//					},
//
//
//					// INSERT LIST FOR WORKOUTS
//					new Label { 
//						Text = "Monday",
//						TextColor = Color.Black,
//						FontAttributes = FontAttributes.Bold,
//					},
//
//					stacklayoutmon,
//
//					new BoxView {
//						Color = Color.FromHex ("002351"),
//						HeightRequest = 2,
//					},
//
//
//					new Label { 
//						Text = "Tuesday",
//						TextColor = Color.Black,
//						FontAttributes = FontAttributes.Bold,
//					},
//					stacklayouttue,
//
//					new BoxView {
//						Color = Color.FromHex ("002351"),
//						HeightRequest = 2,
//					},
//
//					new Label { 
//						Text = "Wednesday",
//						TextColor = Color.Black,
//						FontAttributes = FontAttributes.Bold,
//					},
//					stacklayoutwed,
//
//					new BoxView {
//						Color = Color.FromHex ("002351"),
//						HeightRequest = 2,
//					},
//
//					new Label { 
//						Text = "Thursday",
//						TextColor = Color.Black,
//						FontAttributes = FontAttributes.Bold,
//					},
//					stacklayoutthurs,
//
//					new BoxView {
//						Color = Color.FromHex ("002351"),
//						HeightRequest = 2,
//					},
//
//					new Label { 
//						Text = "Friday",
//						TextColor = Color.Black,
//						FontAttributes = FontAttributes.Bold,
//					},
//
//					stacklayoutfri,
//
//					new BoxView {
//						Color = Color.FromHex("F6905D"), // orange
//						HeightRequest = 2,
//					},
//
//					new Image
//					{
//						Source = ImageSource.FromFile("temp_linegraph.jpg"),
//						WidthRequest = 300,
//
//					},
//
//
//				}, // ends children
//
//			}; // ends exersice stacklayout
//
//			// Weight !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//
//			StackLayout weightstack1 = new StackLayout {
//
//				Children = { // Daily Water
//
//
//
//					new Label { 
//						Text = "Weigh In",
//						TextColor = Color.Black,
//						Style = Device.Styles.SubtitleStyle 
//					},
//
//					new BoxView {
//						Color = Color.FromHex("F6905D"), // orange
//						HeightRequest = 2,
//					},
//							
//					new Entry { 
//						VerticalOptions = LayoutOptions.Center,
//						HorizontalOptions = LayoutOptions.Center,
//							
//						Text = "? kg",
//						TextColor = Color.Black,
//							
//					
//					}, // make this big
//					// and enter button
//
//				}, // ends children
//
//			}; // ends weightstack 1
//
//			StackLayout weightstack2 = new StackLayout {
//
//				Children = { 
//
//					new Label { 
//						Text = "Goal Weight",
//						TextColor = Color.Black,
//						Style = Device.Styles.SubtitleStyle 
//					},
//							
//					new BoxView {
//						Color = Color.FromHex("F6905D"), // orange
//						HeightRequest = 2,
//					},
//
//					new Image
//					{
//						Source = ImageSource.FromFile("temp_goalweight.jpg"),
//						HeightRequest = 100,
//
//					},
//
//
//				}, // ends children
//
//			}; // ends water stack 1
//
//
//			Grid gridweight = new Grid {
//				HorizontalOptions = LayoutOptions.CenterAndExpand,
//
//				RowDefinitions = {
//					new RowDefinition { Height = GridLength.Auto },
//				},
//
//				ColumnDefinitions = {
//					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
//					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
//				},
//
//			}; // ends water grid
//
//			gridweight.Children.Add(weightstack1,0,0);
//			gridweight.Children.Add(weightstack2,1,0);
//
//			StackLayout stacklayoutweight = new StackLayout {
//
//
//
//				BackgroundColor = Color.White,
//
//				Children = {
//
//					new BoxView {
//						Color =  Color.FromHex("F16379"), // pink
//						HeightRequest = 2,
//					},
//
//					new Label { 
//						Text = "Weight",
//						TextColor = Color.Black,
//						Style = Device.Styles.TitleStyle,
//						FontAttributes = FontAttributes.Bold,
//					},
//
//					new BoxView {
//						Color =  Color.FromHex("F16379"), // pink
//						HeightRequest = 2,
//					},
//
//					gridweight,
//
//					new Label { 
//						Text = "Monthly Progress",
//						TextColor = Color.Black,
//						Style = Device.Styles.SubtitleStyle 
//					},
//
//					new BoxView {
//						Color = Color.FromHex("F6905D"), // orange
//						HeightRequest = 2,
//					},
//
//					new Image
//					{
//						Source = ImageSource.FromFile("temp_linegraph.jpg"),
//						WidthRequest = 300,
//
//					},
//
//
//				}, // ends children
//
//			}; // ends weight
//
//
//			// Dashboard !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//
//			StackLayout stackLayout = new StackLayout { // Main Stacklayout
//
//				BackgroundColor = Color.White,
//				Padding = new Thickness (10),
//
//				Children = {
//
//					//settingsbutton, 
//					// Health Dashboard
//					// Water
//					stacklayoutwater,
//
//					// Food
//					stacklayoutfood,
//
//					// Exersice
//					stacklayoutexercise,
//
//					// Weightloss
//					stacklayoutweight,
//
//
//
//				}, // ends children
//
//
//			}; // ends stacklayout 
//
//			Content = new ScrollView { 
//
//				Content = stackLayout 
//
//			}; // ends content scrollveiw
//
		}
	}

	public class HealthDashboardMasterDetail : MasterDetailPage
	{
		public HealthDashboardMasterDetail()
		{
			Title = "Health";
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			Detail = new HealthDashboard();

			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}
	}

}


