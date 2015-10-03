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

					new Label { Text = "this is the home page!!!!!!!!!!!" }
	
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
					