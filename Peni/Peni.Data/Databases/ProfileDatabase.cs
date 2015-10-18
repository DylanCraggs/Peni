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
using System.Collections.ObjectModel;

namespace Peni.Data
{
	public class ProfileDatabase : CloudDatabase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.ProfileDatabase"/> class.
		/// </summary>
		public ProfileDatabase () {
			base.Init ();
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

			if (await ExistingUser (Profile.Email, Profile.Password)) {
				Debug.WriteLine ("Username or email already in use.");
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
		private async Task<List<Account>> AttemptLogin(string email, string password) {
			var account = await client.GetTable<Account>().Where(x => x.Email == email && x.Password == password).ToListAsync();
			return account;
		}

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>The all.</returns>
		private async Task<List<Account>> GetAll() {
			var result = await client.GetTable<Account>().ToListAsync();
			return result;
		}

		private async Task<bool> ExistingUser(string email, string username) {
			List<Account> accs = new List<Account> (await client.GetTable<Account> ().Where (x => x.Email.ToLower () == email).ToListAsync ());

			if (accs == null || accs.Count == 0)
				return false;
			else
				return true;
		}

		/// <summary>
		/// Attempts to create a Globals.UserSession using the supplied parameters
		/// </summary>
		/// <returns>True if username and password was valid, false otherwise.</returns>
		/// <param name="email">Email Address.</param>
		/// <param name="password">Password.</param>
		public async Task<bool> AttemptLoginAuth(string email, string password) {
			List<Account> accs = new List<Account> (await AttemptLogin(email, password));

			if (accs.Count == 1) {
				Globals.UserSession = accs[0];
				Debug.WriteLine (Globals.UserSession.Username);
				return true;
			}
			
				
			return false;
		}
	}
}

