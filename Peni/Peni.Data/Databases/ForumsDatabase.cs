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

			// Check if Thread table exists, if not create it
			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(Thread).Name)) {
				Connection.CreateTable<Thread> ();
				Connection.Commit ();
			}

			// Check if UserComment table exists, if not create it
			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(UserComment).Name)) {
				Connection.CreateTable<UserComment> ();
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

		/// <summary>
		/// Inserts the or update thread.
		/// </summary>
		/// <returns>true if successful, false otherwise.</returns>
		/// <param name="thread">Thread.</param>
		public int InsertOrUpdateThread(Thread thread) {
			return Connection.Table<Thread> ().Where (x => x.id == thread.id).Count () > 0 
				? Connection.Update (thread) : Connection.Insert (thread);
		}

		/// <summary>
		/// Inserts a comment relative to a thread.
		/// </summary>
		/// <returns>true if successful, false otherwise.</returns>
		/// <param name="comment">Comment.</param>
		public int InsertComment(UserComment comment) {
			/*return Connection.Table<UserComment> ().Where (x => x.id == comment.id).Count () > 0
				? Connection.Update (comment) : Connection.Insert (comment);
				*/
			return Connection.Insert (comment);

		}

		/// <summary>
		/// Gets the thread comments.
		/// </summary>
		/// <returns>A list of user comments.</returns>
		/// <param name="ThreadID">Thread ID of comments to retrieve</param>
		public List<UserComment> GetThreadComments(int ThreadID) {
			var comments = Connection.Table<UserComment> ().Where (x => x.ThreadID == ThreadID).ToList();
			return comments;
		}
	}
}

