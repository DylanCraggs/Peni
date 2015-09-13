using System;

using Xamarin.Forms;

namespace Peni
{
	public class PeniMain : ContentPage
	{
		public PeniMain ()
		{



			// put the content for the page here

			StackLayout stacklayout = new StackLayout {

				Padding = new Thickness(20), // change to be universal to rest of app. 

				Children = {

					new Frame {

						OutlineColor = Color.Pink,

						Content = new Label {
							Text = "Peni will be here",
							HorizontalOptions = LayoutOptions.Center,
							HeightRequest = 400,





						},

					},

					///////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!////////
					// currenty puting menu items here utill the menu will be added //

					// put link to the forums

					new Button() {
						Text = "forums",
						Command = new Command (() => Navigation.PushAsync (new Forums ()))
					},
					// put a link to health(water) settings

					new Button() {
						Text = "Set Health Goals",
						Command = new Command (() => Navigation.PushAsync (new HealthGoalSettings ()))
					},
							
					new Frame {  // The Water Info Card

						// housekeeping
						
						OutlineColor = Color.Blue, //// makes this the blue from the color scheme

						// Title Text

						Content = new Label {
							Text = "Daily Water",

							HorizontalOptions = LayoutOptions.Start,
							VerticalOptions = LayoutOptions.Start
						}

						// display current amount of water drank

						// buttons to increase/ decrease amount of water drunk



					},



					new Frame {

						OutlineColor = Color.Blue,

						Content = new Label {
							Text = "Exercise stuff will go here",
							HorizontalOptions = LayoutOptions.Center
						}

					},

					new Frame {

						OutlineColor = Color.Blue,

						Content = new Label {
							Text = "Food Stuff will go here",


							HorizontalOptions = LayoutOptions.Center
						}

					}



				} // ends children
					

			}; // ends stacklayout

				Content = new ScrollView { 

				// call all the content for the scroll view here

				Content = stacklayout

			};


		} // ends pibli

	}// ends public class

}// ends namespace
					