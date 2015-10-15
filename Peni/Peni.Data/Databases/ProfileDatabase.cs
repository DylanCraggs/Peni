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
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace Peni.Data
{
	public class ProfileDatabase
	{
		const string applicationURL = @"https://peni.azure-mobile.net/";
		const string applicationKey = @"KrjkaEtTeCpgBsdnXbzWfBJoEYUxju50";

		//Mobile Service Client reference
		private MobileServiceClient client;

		private IMobileServiceSyncTable<Account> accountTable;
		// Mobile Service Sync Table Used To Access Data
		private IMobileServiceSyncTable<Thread> threadsTable;
		// Mobile Service Sync Table Used To Access Data
		private IMobileServiceSyncTable<UserComment> commentsTable;

		SQLiteConnection Connection;

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.ProfileDatabase"/> class.
		/// </summary>
		public ProfileDatabase () {
			Connection = DependencyService.Get<ISQLite>().GetConnection();

			client = new MobileServiceClient (applicationURL, applicationKey);

			Init().Wait();

			// Get the mobile service sync table instaces to use
			accountTable = client.GetSyncTable<Account> ();
			threadsTable = client.GetSyncTable<Thread> ();
			commentsTable = client.GetSyncTable<UserComment> ();       

			// Refresh Items
			OnRefreshItems();
		}

		/// <summary>
		/// Raises the refresh items event.
		/// </summary>
		public async Task OnRefreshItems () {
			await SyncAsync ();
		}

		/// <summary>
		/// Init this instance.
		/// </summary>
		public async Task Init() {
			var store = new MobileServiceSQLiteStore (DependencyService.Get<ISQLite> ().GetPath ());
			store.DefineTable<Account> ();
			store.DefineTable<Thread> ();
			store.DefineTable<UserComment> ();
			await client.SyncContext.InitializeAsync (store);
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

		/// <summary>
		/// Gets the thread comments.
		/// </summary>
		/// <returns>The thread comments.</returns>
		/// <param name="ThreadID">Thread I.</param>
		public async Task<List<Account>> AttemptLogin(string email, string password) {
			var comments = await client.GetTable<Account>().Where(x => x.Email == email && x.Password == password).ToListAsync();
			if (comments.Capacity <= 0)
				return null;
			else
				return comments;
		}

	}
}

