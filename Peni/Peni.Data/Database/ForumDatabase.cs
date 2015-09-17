using Peni;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;


namespace Peni.Data
{
	/// <summary>
	/// Forum database functions implementation
	/// </summary>
	public class ForumDatabase
	{
		private SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.ForumDatabase"/> class.
		/// </summary>
		public ForumDatabase ()
		{
			database = DependencyService.Get<ISQLite>().GetConnection ();

			if (database.TableMappings.All (t => t.MappedType.Name != typeof(ForumThread).Name)) {
				database.CreateTable<ForumThread>();
				database.Commit ();
			}
		}

		/// <summary>
		/// Gets all threads in the database
		/// </summary>
		/// <returns>List of all threads in the database.</returns>
		public List<ForumThread> GetAll() {
			return database.Table<ForumThread>().ToList<ForumThread>();
		}

		/// <summary>
		/// Inserts or updates the parsed thread.
		/// </summary>
		/// <returns>The or update.</returns>
		/// <param name="thread">Thread.</param>
		public int InsertOrUpdate(ForumThread thread) {
			return database.Table<ForumThread> ().Where (x => x.TopicID == thread.TopicID).Count () > 0
				? database.Update (thread) : database.Insert (thread);
			// What does the int this returns actually represent?
		}

		/// <summary>
		/// Gets the thread corresponding to the parsed id
		/// </summary>
		/// <returns>The thread.</returns>
		/// <param name="id">Thread Identifier to retreive</param>
		public ForumThread GetThread(int id) {
			return database.Table<ForumThread> ().First (t => t.TopicID == id);
		}
	}
}