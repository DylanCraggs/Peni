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

			/// Profile page table!!!!!!!!
			// Check if Thread table exists, if not create it
		//	if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(userProfileDB).Name)) {
		//		Connection.CreateTable<userProfileDB> ();
		//		Connection.Commit ();
		//	}
		}

		/// <summary>
		/// Gets all results in the Thread table and returns a list of threads
		/// </summary>
		/// <returns>A List of Threads</returns>
		public List<Thread> GetAll() {
			var items = Connection.Table<Thread>().ToList();
			return items;
		}

		/// <summary>
		/// Inserts a thread into the database
		/// </summary>
		/// <returns>true if successful, false otherwise.</returns>
		/// <param name="thread">Thread.</param>
		public int InsertThread(Thread thread) {
			return Connection.Insert (thread);
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
		/// Gets all comments left on a given thread id
		/// </summary>
		/// <returns>A list of user comments relating to the threadid parsed.</returns>
		/// <param name="ThreadID">The ID of the thread to get the comments from</param>
		public List<UserComment> GetThreadComments(int ThreadID) {
			var comments = Connection.Table<UserComment> ().Where (x => x.ThreadID == ThreadID).ToList();
			return comments;

		
	//	public int updateUserBio 
	//			return Connection.Table<UserComment> ().Where (x => x.id == comment.id).Count () > 0
	//			? Connection.Update (comment) : Connection.Insert (comment);
				
	//			return Connection.Insert (entrySuccessful);


		


		}
	}
}

