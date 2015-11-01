using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Peni;
using Peni.Droid;
using Android.App;
using Android.Locations;
using Android.OS;
using Android.Util;
using Android.Widget;
using Geolocator.Plugin;
using System.Threading.Tasks;

[assembly: Dependency (typeof (Peni.Droid.Location))]
namespace Peni.Droid
{
	public class Location : Peni.Data.ILocation
	{

		/// <summary>
		/// Gets the latitude.
		/// </summary>
		/// <returns>Double containing users latitude.</returns>
		public async Task<double> GetLat() {
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 5000; // 5km accurate
			var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
			return position.Latitude;
		}

		/// <summary>
		/// Gets the longitude.
		/// </summary>
		/// <returns>Double containing users longitude.</returns>
		public async Task<double> GetLng() {
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 5000; // 5km accurate
			var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
			return position.Longitude;
		}
	}
}