using System;
using System.IO;
using SQLite.Net;
using Peni.Data;
using Peni.Droid;

namespace Peni.Droid
{
	public class SQLiteDroid : ISQLite
	{
		public SQLiteDroid ()
		{
		}

		#region ISQLite implementation

		public SQLite.Net.SQLiteConnection GetConnection ()
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

