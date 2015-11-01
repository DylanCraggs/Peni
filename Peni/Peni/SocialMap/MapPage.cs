using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using Geolocator;
using XLabs.Platform.Device;
using XLabs.Platform;
using XLabs.Ioc;
using XLabs.Platform.Services.Geolocation;
using Peni.Data; 


namespace Peni
{
	public class MapPage : ContentPage
	{
		Map map;

		public MapPage ()
		{
			
			map = new Map { 
				MapType = MapType.Hybrid,
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			map.MoveToRegion (MapSpan.FromCenterAndRadius (new Xamarin.Forms.Maps.Position (-27.4667, 153.0333), Distance.FromMiles (4.2)));
			addPin (map);

			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add(map);
			Content = stack;

		}

		void HandleClicked (object sender, EventArgs e)
		{
			var b = sender as Button;
			switch (b.Text) {
			case "Street":
				map.MapType = MapType.Street;
				break;
			case "Hybrid":
				map.MapType = MapType.Hybrid;
				break;
			case "Satellite":
				map.MapType = MapType.Satellite;
				break;
			}
		}

		private async void addPin(Map map) {
			map.MoveToRegion (MapSpan.FromCenterAndRadius (new Xamarin.Forms.Maps.Position (await DependencyService.Get<ILocation> ().GetLat(),  await DependencyService.Get<ILocation> ().GetLng()), Distance.FromMiles (4.2)));

			var position = new Xamarin.Forms.Maps.Position(await DependencyService.Get<ILocation> ().GetLat(), await DependencyService.Get<ILocation> ().GetLng()); // Latitude, Longitude
			var userPin = new Pin {
				Type = PinType.Generic,
				Position = position,
				Label = "This user",
				Address = "Stage 3"
			};
			map.Pins.Add(userPin);

			var latitudeUser = userPin.Position.Latitude;
			var longitudeUser = userPin.Position.Longitude;
			var km = 15;
			var longitudeMin = longitudeUser - (km/111.321);
			var longitudeMax = longitudeUser + (km/111.321);
			var latitudeMin = latitudeUser - (km/111.0);
			var latitudeMax = latitudeUser + (km/111.0);
			Pin[] pinSet = {
				new Pin {
					Type = PinType.Generic,
					Position = new Xamarin.Forms.Maps.Position(-27.468931, 153.028457),
					Label = "User Name 1 ",
					Address = "Stage 3",

				},
				new Pin {
					Type = PinType.Generic,
					Position = new Xamarin.Forms.Maps.Position(-27.474642, 153.019316),
					Label = "User Name 2",
					Address = "Stage 3"
				},
				new Pin {
					Type = PinType.Generic,
					Position = new Xamarin.Forms.Maps.Position(-27.482866, 153.032877),
					Label = "User Name 3",
					Address = "Stage 3"
				},
				new Pin {
					Type = PinType.Generic,
					Position = new Xamarin.Forms.Maps.Position(-27.451866, 153.043585),
					Label = "User Name 4",
					Address = "Stage 3"
				}

			};
			foreach (var myPin in pinSet) {
				if(((myPin.Position.Latitude >= latitudeMin) && (myPin.Position.Latitude <= latitudeMax)) && ((myPin.Position.Longitude >= longitudeMin) && (myPin.Position.Longitude <= longitudeMax)))
					map.Pins.Add(myPin);
			}
		}
	
	}

	public class MapPageMasterDetail : MasterDetailPage
	{
		public MapPageMasterDetail()
		{
			Title = "Peni Garden";
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			Detail = new MapPage();

			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}


	}
}
