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
using System.Threading.Tasks;
using System.Collections.Generic; 


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
	
		private async void addPins(Map map) {

			var myPosition = new Xamarin.Forms.Maps.Position (await DependencyService.Get<ILocation> ().GetLat (), await DependencyService.Get<ILocation> ().GetLng ());
			map.MoveToRegion (MapSpan.FromCenterAndRadius (myPosition, Distance.FromMiles (2.2)));

			InsertUsersLocationToDatabase();

			var userPin = new Pin {
				Type = PinType.Generic,
				Position = myPosition,
				Label = "Hey "+Globals.UserSession.Username.ToString()+", you are here",
				Address = "Your current stage: "+Globals.UserSession.UserStage.ToString()
			};


			map.Pins.Add(userPin);
			await addNearbyUsersPin(userPin);
			//Peni.Data.LocProfile location = new Peni.Data.LocProfile (Globals.UserSession,-27.4667, 153.0333);
			//LocationDatabase database = new LocationDatabase();

		}

		private async Task addNearbyUsersPin(Pin userPin) {
			var latitudeUser = userPin.Position.Latitude;
			var longitudeUser = userPin.Position.Longitude;
			var km = 15;
			var longitudeMin = longitudeUser - (km/111.321);
			var longitudeMax = longitudeUser + (km/111.321);
			var latitudeMin = latitudeUser - (km/111.0);
			var latitudeMax = latitudeUser + (km/111.0);

			LocationDatabase database = new LocationDatabase();
			var locatioProfiles = await database.GetAll ();
			foreach (var aUserLocation in locatioProfiles) {
				if (((aUserLocation.Latitude >= latitudeMin) && (aUserLocation.Latitude <= latitudeMax)) && ((aUserLocation.Longitude >= longitudeMin) && (aUserLocation.Longitude <= longitudeMax)) && !(string.Equals(aUserLocation.Username.ToString(), Globals.UserSession.Username.ToString()))) {// 
					Pin aUserPin = 
						new Pin {
							Type = PinType.Generic,
							Position = new Xamarin.Forms.Maps.Position (aUserLocation.Latitude, aUserLocation.Longitude),
						Label =  aUserLocation.Username.ToString()+" is around this area. Click here to send her a message",
						Address =  "Her Stage: "+aUserLocation.Stage.ToString(),
						}
					;
					aUserPin.Clicked += async (sender, e) =>
					{
						Command messagingCmd = (Command)await App.Locator.MessagingMain.GetNavigateToConversation(Guid.Parse(aUserLocation.id), aUserLocation.Username);
						if(messagingCmd.CanExecute(this)){
							messagingCmd.Execute(this);
						}

					};
					map.Pins.Add(aUserPin);
				}
			}

		}


		private async void InsertUsersLocationToDatabase() {
			LocProfile location = new LocProfile (Guid.Parse(Globals.UserSession.id), Globals.UserSession.Username, Globals.UserSession.UserStage,await DependencyService.Get<ILocation> ().GetLat (), await DependencyService.Get<ILocation> ().GetLng ());
			LocationDatabase database = new LocationDatabase();
			await database.InsertRecord(location);
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



		private async void PrintPosition() {
			Debug.WriteLine ("Latitude: " + await DependencyService.Get<ILocation> ().GetLat());
			Debug.WriteLine ("Longitude: " + await DependencyService.Get<ILocation> ().GetLng());
		}


	}
}
