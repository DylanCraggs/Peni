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
		/// <param name="Profile">Profile to add.</param>
		public async Task InsertProfile(Account Profile) {
			if (client == null) {
				throw base.CreateClientNullException();
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
		/// Deletes a user profile.
		/// </summary>
		/// <param name="Profile">Profile to delete.</param>
		private async Task DeleteProfile(Account Profile) {
			if (client == null) {
				throw base.CreateClientNullException();
			}

			try {
				await accountTable.DeleteAsync(Profile);
				await SyncAsync();
			} catch (Exception ex) {
				Debug.WriteLine ("DeleteProfile Error: " + ex.ToString ());
			}
		}

		/// <summary>
		/// Attempts the delete profile.
		/// </summary>
		/// <returns>True if profile was delete, false otherwise.</returns>
		/// <param name="email">Email to search for.</param>
		/// <param name="password">Password to search for.</param>
		public async Task<bool> AttemptDeleteProfile(string email, string password) {
			if (client == null) {
				throw base.CreateClientNullException ();
			}
				
			List<Account> AccToDelete = new List<Account> (await AttemptLogin (email, password));

			// No account was found to delete
			if (AccToDelete.Count == 0)
				return false;

			await DeleteProfile (AccToDelete [0]);

			// Attempt to get the profile (should return nothing)
			AccToDelete = new List<Account> (await AttemptLogin (email, password));
			if (AccToDelete.Count != 0 || AccToDelete != null)
				return false;

			// Nothing was returned
			return true;
		}

		/// <summary>
		/// Gets the thread comments.
		/// </summary>
		/// <returns>The thread comments.</returns>
		/// <param name="ThreadID">Thread I.</param>
		public async Task<List<Account>> AttemptLogin(string email, string password) {
			if (client == null) {
				return null;
			}
			var account = await client.GetTable<Account>().Where(x => x.Email == email && x.Password == password).ToListAsync();
			return account;
		}

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <returns>The all.</returns>
		private async Task<List<Account>> GetAll() {
			if (client == null) {
				throw base.CreateClientNullException();
			}

			var result = await client.GetTable<Account>().ToListAsync();
			return result;
		}

		/// <summary>
		/// Checks if there are any existing users.
		/// </summary>
		/// <returns>True if matched either or all parameters, false otherwise.</returns>
		/// <param name="email">Email to match.</param>
		/// <param name="username">Username to match.</param>
		private async Task<bool> ExistingUser(string email, string username) {
			if (client == null) {
				throw base.CreateClientNullException();
			}

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
			if (client == null) {
				throw base.CreateClientNullException();
			}

			List<Account> accs = new List<Account> (await AttemptLogin(email, password));

			if (accs.Count == 1) {
				Globals.UserSession = accs[0];
				return true;
			}
			
				
			return false;
		}
	}
}

