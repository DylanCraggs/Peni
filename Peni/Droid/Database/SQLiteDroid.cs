using System;
using Peni.Data;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using Peni.Droid;
using System.Threading.Tasks;

[assembly: Dependency (typeof (SQLiteDroid))]

namespace Peni.Droid
{
	public class SQLiteDroid : ISQLite
	{
		public SQLiteDroid () {}

		#region ISQLite implementation

		string DatabaseLocationPath;

		/// <summary>
		/// Gets the database connection in the Android OS
		/// </summary>
		/// <returns>The connection.</returns>
		public SQLiteConnection GetConnection ()
		{
			const string DatabaseFilename = "PeniDatabase.db3";
			var DocumentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			DatabaseLocationPath = Path.Combine (DocumentsPath, DatabaseFilename);
			var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

			//Create the connection
			var connection = new SQLiteConnection(plat, DatabaseLocationPath);

			return connection;
		}

		#endregion
	}
}

