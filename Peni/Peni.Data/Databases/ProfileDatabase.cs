using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;

namespace Peni.Data
{
	public class ProfileDatabase
	{
			SQLiteConnection Connection;

			public ProfileDatabase () {
				Connection = DependencyService.Get<ISQLite> ().GetConnection ();

				// Check if Thread table exists, if not create it
				if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(UserProfile).Name)) {
					Connection.CreateTable<Thread> ();
					Connection.Commit ();
				}
			}

	}
}

