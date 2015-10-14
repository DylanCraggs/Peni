using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Diagnostics;

namespace Peni.Data
{
	public class ProfileDatabase
	{
		const string applicationURL = @"https://peni.azure-mobile.net/";
		const string applicationKey = @"KrjkaEtTeCpgBsdnXbzWfBJoEYUxju50";

		//Mobile Service Client reference
		private MobileServiceClient client;

		private IMobileServiceSyncTable<Account> accountTable;

			/// <summary>
			/// Initializes a new instance of the <see cref="Peni.Data.ProfileDatabase"/> class.
			/// </summary>
			public ProfileDatabase () {
				client = new MobileServiceClient (applicationURL, applicationKey);
			}

			/// <summary>
			/// Pushes changes to the mobile service
			/// </summary>
			public async Task SyncAsync() {
				try {
					await client.SyncContext.PushAsync();
				} catch (MobileServicePushFailedException ex) {
					Debug.WriteLine ("SyncAsync Error: " + ex.ToString());
				}
			}

			/// <summary>
			/// Inserts the profile.
			/// </summary>
			/// <returns>The profile.</returns>
			/// <param name="Profile">Profile.</param>
			public async Task InsertProfile(Account Profile) {
				if (client == null) {
					Debug.WriteLine ("AddItem Error: Client was null.");
					return;
				}

				try {
					await accountTable.InsertAsync(Profile); // Inserts into the local database
					await SyncAsync(); // Sends to the mobile service
				} catch (Exception ex) {
					Debug.WriteLine ("AddItem Error: " + ex.ToString());
				}
			}

	}
}

