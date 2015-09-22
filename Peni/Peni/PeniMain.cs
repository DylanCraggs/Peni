using System;
using Xamarin.Forms;
using System.Linq;
using System.Diagnostics;
using Peni.Data.ViewModel;

namespace Peni
{
    
	public class PeniMainContet : ContentPage
	{
		public PeniMainContet()
		{
            Title = "Home";
            Icon = "drawable/ic_home_white_48dp.png";
  
        Image image = new Image
            {
                // Some differences with loading images in initial release.
                Source = ImageSource.FromFile("peni_small.png"),
                HeightRequest = 300,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            StackLayout stacklayout = new StackLayout {

                BackgroundColor = Color.White,
                Padding = new Thickness(20), // change to be universal to rest of app. 

                Children = {

                    image,
	
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

    public class PeniMasterDetail : MasterDetailPage
    {
        MenuPage menuPage;

        public PeniMasterDetail()
        {
            menuPage = new MenuPage();


			menuPage.Menu.ItemSelected += (sender, e) => {
				//NavigateTo(e.SelectedItem as MenuItem);
				BindingContext = App.Locator.SideMenu;
				MenuItem item = e.SelectedItem as MenuItem;

				/*
				if(item.Command != null) {
					item.Command.Execute(item.Command);
				}

				*/
				Debug.WriteLine(item.Title.ToString());// + " " + item.Command.ToString());

				//item.BindingContext.Execute(this);
				/*
				try {
					this.Detail.BindingContext = item.BindingContext;
				} catch (Exception ex) {
					Debug.WriteLine(ex.Message.ToString());
				}

				Debug.WriteLine("ClickedItemBindingContext: " + item.BindingContext);
*/
			};

            Master = menuPage;
			Detail = new NavigationPage(new PeniMainContet());
        }

        void NavigateTo(MenuItem menu)
        {
            if (menu == null)
                return;

            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            Detail = new NavigationPage(displayPage);

            menuPage.Menu.SelectedItem = null;
            IsPresented = false;
        }
    }

}// ends namespace
					