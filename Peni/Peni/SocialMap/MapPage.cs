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
			addPins (map);

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

		private async void addPins(Map map) {

			var myPosition = new Xamarin.Forms.Maps.Position (await DependencyService.Get<ILocation> ().GetLat (), await DependencyService.Get<ILocation> ().GetLng ());
			map.MoveToRegion (MapSpan.FromCenterAndRadius (myPosition, Distance.FromMiles (4.2)));

			var userPin = new Pin {
				Type = PinType.Generic,
				Position = myPosition,
				Label = "Hey "+Globals.UserSession.Username.ToString()+", you are here",
				Address = "Your current stage: "+Globals.UserSession.UserStage.ToString()
			};
			map.Pins.Add(userPin);
			addNearbyUsersPin(userPin);
			Peni.Data.LocProfile location = new Peni.Data.LocProfile (Globals.UserSession,-27.4667, 153.0333);
			LocationDatabase database = new LocationDatabase();
			database.InsertRecord(location);

		}

		private async void addNearbyUsersPin(Pin userPin) {
			var latitudeUser = userPin.Position.Latitude;
			var longitudeUser = userPin.Position.Longitude;
			var km = 15;
			var longitudeMin = longitudeUser - (km/111.321);
			var longitudeMax = longitudeUser + (km/111.321);
			var latitudeMin = latitudeUser - (km/111.0);
			var latitudeMax = latitudeUser + (km/111.0);

			LocationDatabase database = new LocationDatabase();
			var locatioProfiles = await database.GetAll ();
			Debug.WriteLine ("Oiee");
			Debug.WriteLine ("Tchauu: "+locatioProfiles.ToArray().ToString());
			foreach (var aUserLocation in locatioProfiles) {
				Debug.WriteLine ("A user: "+aUserLocation.ToString ());
				if (((aUserLocation.Latitude >= latitudeMin) && (aUserLocation.Latitude <= latitudeMax)) && ((aUserLocation.Longitude >= longitudeMin) && (aUserLocation.Longitude <= longitudeMax))) {
					Pin aUserPin = 
						new Pin {
							Type = PinType.Generic,
							Position = new Xamarin.Forms.Maps.Position (aUserLocation.Latitude, aUserLocation.Longitude),
							Label =  aUserLocation.Account.Username.ToString(),
							Address =  "Stage: "+aUserLocation.Account.UserStage.ToString(),
						}
					;
					map.Pins.Add(aUserPin);
				}
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
