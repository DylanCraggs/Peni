using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Diagnostics;
using Geolocator;

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

			map.MoveToRegion (new MapSpan (new Position (36.9628066,-122.0194722), 360, 360) );


			//Geocoder geocoder = new Geocoder (this);
			var position = new Position(36.9628066,-122.0194722); // Latitude, Longitude
			var pin = new Pin {
				Type = PinType.Place,
				//Resource = "",
				Position = position,
				Label = "Santa Cruz",
				Address = "custom detail info"
			};
			map.Pins.Add(pin);

			/*/ create map style buttons
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


			// for debugging output only
			map.PropertyChanged += (sender, e) => {
				Debug.WriteLine(e.PropertyName + " just changed!");
				if (e.PropertyName == "VisibleRegion" && map.VisibleRegion != null)
					CalculateBoundingCoordinates (map.VisibleRegion);
			};
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



		/// <summary>
		/// In response to this forum question http://forums.xamarin.com/discussion/22493/maps-visibleregion-bounds
		/// Useful if you need to send the bounds to a web service or otherwise calculate what
		/// pins might need to be drawn inside the currently visible viewport.
		/// </summary>
		static void CalculateBoundingCoordinates (MapSpan region)
		{
			// WARNING: I haven't tested the correctness of this exhaustively!
			var center = region.Center;
			var halfheightDegrees = region.LatitudeDegrees / 2;
			var halfwidthDegrees = region.LongitudeDegrees / 2;

			var left = center.Longitude - halfwidthDegrees;
			var right = center.Longitude + halfwidthDegrees;
			var top = center.Latitude + halfheightDegrees;
			var bottom = center.Latitude - halfheightDegrees;

			// Adjust for Internation Date Line (+/- 180 degrees longitude)
			if (left < -180) left = 180 + (180 + left);
			if (right > 180) right = (right - 180) - 180;
			// I don't wrap around north or south; I don't think the map control allows this anyway

			Debug.WriteLine ("Bounding box:");
			Debug.WriteLine ("                    " + top);
			Debug.WriteLine ("  " + left + "                " + right);
			Debug.WriteLine ("                    " + bottom);
		}
	}
}
