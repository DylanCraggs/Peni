using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace Peni.Data
{
	public class CloudDatabase
	{
		// Cloud Connection
		public MobileServiceClient client;

		// Databse tables
		public IMobileServiceSyncTable<Account> accountTable;
		public IMobileServiceSyncTable<Thread> threadsTable;
		public IMobileServiceSyncTable<UserComment> commentsTable;
		public IMobileServiceSyncTable<LocProfile> locationTable;
		public IMobileServiceSyncTable<ThreadFavorite> favoriteTable;

		// Connection Strings
		const string applicationURL = @"https://peni.azure-mobile.net/";
		const string applicationKey = @"KrjkaEtTeCpgBsdnXbzWfBJoEYUxju50";

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.AzureDatabase"/> class.
		/// </summary>
		public CloudDatabase () {
			Init ().Wait ();
			OnRefreshItems ();
		}

		/// <summary>
		/// Init this instance.
		/// </summary>
		public async Task Init() {
			// Assign the client a new mobile service client
			client = new MobileServiceClient (applicationURL, applicationKey);

			// Get local storage path
			var store = new MobileServiceSQLiteStore (DependencyService.Get<IAzureDatabase>().GetPath());
			store.DefineTable<Account> ();
			store.DefineTable<Thread> ();
			store.DefineTable<UserComment> ();
			store.DefineTable<LocProfile> ();
			store.DefineTable<ThreadFavorite> ();
			await client.SyncContext.InitializeAsync (store);

			// Assign out sync tables
			accountTable = client.GetSyncTable<Account> ();
			threadsTable = client.GetSyncTable<Thread> ();
			commentsTable = client.GetSyncTable<UserComment> (); 
			locationTable = client.GetSyncTable<LocProfile> ();
			favoriteTable = client.GetSyncTable<ThreadFavorite> ();
		}

		/// <summary>
		/// Syncs changes to mobile service
		/// </summary>
		/// <returns>The async.</returns>
		public async Task SyncAsync() {
			try {
				await client.SyncContext.PushAsync();
			} catch (MobileServicePushFailedException ex) {
				Debug.WriteLine ("SyncAsync Error: " + ex.ToString());
			}
		}

		/// <summary>
		/// Raises the refresh items event.
		/// </summary>
		public async Task OnRefreshItems () {
			await SyncAsync ();
		}
	}
}

