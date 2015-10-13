using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Peni.Data
{
	public class ForumsDatabase
	{

		const string applicationURL = @"https://peni.azure-mobile.net/";
		const string applicationKey = @"KrjkaEtTeCpgBsdnXbzWfBJoEYUxju50";

		//Mobile Service Client reference
		private MobileServiceClient client;

		// Mobile Service Sync Table Used To Access Data
		private IMobileServiceSyncTable<Thread> threadsTable;
		// Mobile Service Sync Table Used To Access Data
		private IMobileServiceSyncTable<UserComment> commentsTable;


		SQLiteConnection Connection;

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.ForumsDatabase"/> class.
		/// </summary>
		public ForumsDatabase () {
			Connection = DependencyService.Get<ISQLite>().GetConnection();

			// Create the mobile service client instance using the provided url and key
			client = new MobileServiceClient (applicationURL, applicationKey);
			Task task = Init ();
			task.Wait ();

			// Get the mobile service sync table instaces to use
			threadsTable = client.GetSyncTable<Thread> ();
			commentsTable = client.GetSyncTable<UserComment> ();                                                                                           

			// Check if Thread table exists, if not create it
			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(Thread).Name)) {
				Connection.CreateTable<Thread> ();
				Connection.Commit ();
			}

			// Check if UserComment table exists, if not create it
			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(UserComment).Name)) {
				Connection.CreateTable<UserComment> ();
				Connection.Commit ();
			}

			OnRefreshItems ();
				
		}

		/// <summary>
		/// Raises the refresh items event.
		/// </summary>
		public async Task OnRefreshItems () {
			await SyncAsync ();
		}

		/// <summary>
		/// Initalises the Azure Services
		/// </summary>
		public async Task Init() {
			var store = new MobileServiceSQLiteStore (DependencyService.Get<ISQLite>().GetPath());
			store.DefineTable<Thread> ();
			store.DefineTable<UserComment> ();

			await client.SyncContext.InitializeAsync (store, new MobileServiceSyncHandler());
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
		/// Gets all results in the Thread table and returns a list of threads
		/// </summary>
		/// <returns>A List of Threads</returns>
		public async Task<List<Thread>> GetAll() {
			var items = await threadsTable.ToListAsync();
			return items;
		}

		/// <summary>
		/// Inserts a thread into the database
		/// </summary>
		/// <returns>true if successful, false otherwise.</returns>
		/// <param name="thread">Thread.</param>
		public async Task InsertThread(Thread thread) {
			if (client == null) {
				Debug.WriteLine ("AddItem Error: Client was null.");
				return;
			}

			try {
				await threadsTable.InsertAsync(thread); // Inserts into the local database
				await SyncAsync(); // Sends to the mobile service
			} catch (Exception ex) {
				Debug.WriteLine ("AddItem Error: " + ex.ToString());
			}
		}

		/// <summary>
		/// Inserts a comment relative to a thread.
		/// </summary>
		/// <returns>true if successful, false otherwise.</returns>
		/// <param name="comment">Comment.</param>
		public async Task InsertComment(UserComment comment) {
			if (client == null) {
				Debug.WriteLine ("AddItem Error: Client was null.");
				return;
			}

			try {
				await commentsTable.InsertAsync(comment); // Inserts into the local database
				await SyncAsync(); // Sends to the mobile service
			} catch (Exception ex) {
				Debug.WriteLine ("AddItem Error: " + ex.ToString());
			}
		}

		/// <summary>
		/// Gets all comments left on a given thread id
		/// </summary>
		/// <returns>A list of user comments relating to the threadid parsed.</returns>
		/// <param name="ThreadID">The ID of the thread to get the comments from</param>
		public async Task<List<UserComment>> GetThreadComments(Guid ThreadID) {
			var comments = await commentsTable.Where(x => x.ThreadID == ThreadID).ToListAsync();
			return comments;
		}
	}
}

