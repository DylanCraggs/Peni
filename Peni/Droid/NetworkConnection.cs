using System;
using Peni.Data;
using Android.Net;
using Android.App;
using Android.Content;
using Peni.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]
namespace Peni.Droid
{
	public class NetworkConnection : INetworkConnection
	{
		public bool IsConnected { get; set; }

		public void CheckNetworkConnection()
		{
			var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
			var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
			if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
			{
				IsConnected = true;
			}
			else
			{
				IsConnected = false;
			}
		}
	}

}

