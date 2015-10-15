using System;
using Peni.Data;
using System.IO;
using SQLite.Net;
using Xamarin.Forms;
using Peni.Droid;

[assembly: Dependency (typeof (AzureDatabase))]
namespace Peni.Droid
{
	public class AzureDatabase : IAzureDatabase {

		public AzureDatabase () {}

		/// <summary>
		/// Gets the database path.
		/// </summary>
		/// <returns>String containing the location of the database</returns>
		public string GetPath() {
			const string DatabaseFilename = "PeniDatabase.db3";
			var DocumentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			return Path.Combine (DocumentsPath, DatabaseFilename);
		}
	}
}

