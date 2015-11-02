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
				IsShowingUser = true,
				HeightRequest = 100,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			// You can use MapSpan.FromCenterAndRadius 
//			map.MoveToRegion (MapSpan.FromCenterAndRadius (
//				new Position (37, -122), Distance.FromMiles (0.3)));
			// or create a new MapSpan object directly
			map.MoveToRegion (MapSpan.FromCenterAndRadius (new Xamarin.Forms.Maps.Position (-27.471011, 153.023449), Distance.FromMiles (4.2)));
			//map.MoveToRegion (new MapSpan (new Xamarin.Forms.Maps.Position (-27.3971367,153.0194722), 500, 360) );

			var position = new Xamarin.Forms.Maps.Position(-27.471011, 153.023449); // Latitude, Longitude
			var userPin = new Pin {
				Type = PinType.Generic,
				//Resource = "",
				Position = position,
				Label = "This user",
				Address = "Stage 3"
			};
			map.Pins.Add(userPin);


			var latitudeUser = userPin.Position.Latitude;
			var longitudeUser = userPin.Position.Longitude;
			var km = 5;
			var longitudeMin = longitudeUser - (km/111.321);
			var longitudeMax = longitudeUser + (km/111.321);
			var latitudeMin = latitudeUser - (km/111.0);
			var latitudeMax = latitudeUser + (km/111.0);
			Pin[] pinSet = {
				new Pin {
					Type = PinType.Generic,
					//Resource = "",
					Position = new Xamarin.Forms.Maps.Position(-27.468931, 153.028457),
					Label = "User Name 1 ",
					Address = "Stage 3"
				},
				new Pin {
					Type = PinType.Generic,
					//Resource = "",
					Position = new Xamarin.Forms.Maps.Position(-27.474642, 153.019316),
					Label = "User Name 2",
					Address = "Stage 3"
				},
				new Pin {
					Type = PinType.Generic,
					//Resource = "",
					Position = new Xamarin.Forms.Maps.Position(-27.482866, 153.032877),
					Label = "User Name 3",
					Address = "Stage 3"
				},
				new Pin {
					Type = PinType.Generic,
					//Resource = "",
					Position = new Xamarin.Forms.Maps.Position(-27.451866, 153.043585),
					Label = "User Name 4",
					Address = "Stage 3"
				}

			};
			foreach (var myPin in pinSet) {
				if(((myPin.Position.Latitude >= latitudeMin) && (myPin.Position.Latitude <= latitudeMax)) && ((myPin.Position.Longitude >= longitudeMin) && (myPin.Position.Longitude <= longitudeMax)))
					map.Pins.Add(myPin);
			}
			

			/* create map style buttons
			var street = new Button { Text = "Street" };
			var hybrid = new Button { Text = "Hybrid" };
			var satellite = new Button { Text = "Satellite" };
			street.Clicked += HandleClicked;
			hybrid.Clicked += HandleClicked;
			satellite.Clicked += HandleClicked;
			var segments = new StackLayout { Spacing = 30,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal, 
				Children = {street, hybrid, satellite}
			};*/


			// put the page together
			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add(map);
			//stack.Children.Add (segments);
			Content = stack;


			/* for debugging output only
			map.PropertyChanged += (sender, e) => {
				Debug.WriteLine(e.PropertyName + " just changed!");
				if (e.PropertyName == "VisibleRegion" && map.VisibleRegion != null)
					CalculateBoundingCoordinates (map.VisibleRegion);
			};*/
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
	
	}

	public class MapPageMasterDetail : MasterDetailPage
	{
		public MapPageMasterDetail()
		{
			Title = "Peni Garden";
			MenuPage menuPage = new MenuPage();
			Master = menuPage;
			Detail = new MapPage();

			PrintPosition ();

			menuPage.Menu.ItemTapped += (sender, e) => {
				menuPage.Menu.SelectedItem = null;
				this.IsPresented = false;
			};
		}

		private async void PrintPosition() {
			Debug.WriteLine ("Latitude: " + await DependencyService.Get<ILocation> ().GetLat());
			Debug.WriteLine ("Longitude: " + await DependencyService.Get<ILocation> ().GetLng());
		}

		private async void InsertUsersLocationToDatabase() {
			LocProfile location = new LocProfile (Globals.UserSession, await DependencyService.Get<ILocation> ().GetLat (), await DependencyService.Get<ILocation> ().GetLng ());
			LocationDatabase database = new LocationDatabase();
			await database.InsertRecord(location);
		}

		private async Task<List<LocProfile>> GetAll() {
			LocationDatabase database = new LocationDatabase();
			return await database.GetAll ();
		}
	}
}
