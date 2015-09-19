using System;
using Peni.Data;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using Peni.Droid;

[assembly: Dependency (typeof (SQLiteDroid))]

namespace Peni.Droid
{
	public class SQLiteDroid : ISQLite
	{
		public SQLiteDroid () {}

		#region ISQLite implementation

		public SQLiteConnection GetConnection ()
		{
			const string DatabaseFilename = "PeniDatabase.db3";
			var DocumentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var DatabaseLocationPath = Path.Combine (DocumentsPath, DatabaseFilename);
			var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

			//Create the connection
			var connection = new SQLiteConnection(plat, DatabaseLocationPath);

			return connection;
		}

		#endregion
	}
}

