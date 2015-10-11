using System;
using SQLite.Net;

namespace Peni.Data
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
		void DatabaseSetup();
		string GetPath();
	}
}

