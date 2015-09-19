using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;

namespace Peni.Data
{
	public class ForumsDatabase
	{
		
		SQLiteConnection Connection;

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.ForumsDatabase"/> class.
		/// </summary>
		public ForumsDatabase () {
			Connection = DependencyService.Get<ISQLite> ().GetConnection ();

			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(Thread).Name)) {
				Connection.CreateTable<Thread> ();
				Connection.Commit ();
			}
		}

		/// <summary>
		/// Gets all forum threads in the database
		/// </summary>
		/// <returns>A List of Threads</returns>
		public List<Thread> GetAll() {
			var items = Connection.Table<Thread>().ToList();
			return items;
		}

		public int InsertOrUpdateThread(Thread thread) {
			return Connection.Table<Thread> ().Where (x => x.TopicName == thread.TopicName).Count () > 0 
				? Connection.Update (thread) : Connection.Insert (thread);
		}
	}
}

