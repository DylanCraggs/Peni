using System;

/// <summary>
/// Location database.
/// </summary>
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;


namespace Peni.Data
{
	public class LocationDatabase : CloudDatabase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.LocationDatabase"/> class.
		/// </summary>
		public LocationDatabase ()
		{
			base.Init ();
		}

		/// <summary>
		/// Gets all stored in the LocProfile table.
		/// </summary>
		/// <returns>All the location profiles.</returns>
		public async Task<List<LocProfile>> GetAll() {
			var items = await client.GetTable<LocProfile>().ToListAsync ();
			return items;
		}

		/// <summary>
		/// Inserts a new record into the location profile table.
		/// </summary>
		/// <returns></returns>
		/// <param name="record">The record to add.</param>
		public async Task InsertRecord(LocProfile record) {
			if (client == null) {
				Debug.WriteLine ("Couldn't connect to the client.");
				return;
			}

			bool updating = false;

			if (await UserLocExists (record)) {
				updating = true;
			}

			try {
				if(updating)
					await locationTable.UpdateAsync(record);
				else
					await locationTable.InsertAsync(record);
				await SyncAsync();
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message.ToString ());
			}
		}

		private async Task<bool> UserLocExists(LocProfile profile) {
			List<LocProfile> accs = new List<LocProfile> (await client.GetTable<LocProfile> ().Where(x => x.UserID == profile.UserID).ToListAsync ());

			if (accs == null || accs.Count == 0) {
				return false;
			} else {
				return true;
			}
		
		}
	}
}

