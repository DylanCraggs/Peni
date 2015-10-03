using System;

using Xamarin.Forms;

namespace Peni
{
	public class HealthGoalSettings : ContentPage
	{
		public HealthGoalSettings ()

		{

			Grid bodygrid = new Grid {
				
				RowDefinitions = {
					new RowDefinition { Height = GridLength.Auto },

				},
				ColumnDefinitions = {
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
				},

			}; // ends water grid

			bodygrid.Children.Add( new Label {
				Text = "Age",
			},0,0);

			bodygrid.Children.Add( new Entry {
				Placeholder = "years",
			},0,1);

			Grid goalgrid = new Grid {
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

			goalgrid.Children.Add( new Label {
				Text = "Daily Water Goal",
			},0,0);

			goalgrid.Children.Add( new Entry {
				Placeholder = "cups",
			},1,0);

			goalgrid.Children.Add( new Label {
				Text = "Daily Step Goal",
			},0,1);

			goalgrid.Children.Add( new Entry {
				Placeholder = "cups",
			},1,1);



			StackLayout stacklayout = new StackLayout {

				Children = {

					new Label { 
						
						Text = "Body",
						TextColor = Color.Blue,
						Style = Device.Styles.TitleStyle,
					},

					bodygrid,

					new Label { 
						Text = "Goals",
						TextColor = Color.Blue,
						Style = Device.Styles.TitleStyle 
					},

					goalgrid,

					new Label { 
						Text = "Data Binding Tests",
						TextColor = Color.Blue,
						Style = Device.Styles.TitleStyle 
					},

				},
		

			};




			Content = new ScrollView { 

				Content = stacklayout 

			}; 
		}
	}
}




