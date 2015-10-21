using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;

namespace Peni.Data
{
	public class HealthDatabase
	{
		
<<<<<<< HEAD
		SQLiteConnection Connection;
=======
		SQLiteConnection database;
>>>>>>> 57bb616c261a9ee8a359512da4ec7cff02f58de2

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.HealthDatabase"/> class.
		/// </summary>
		/// 
		public HealthDatabase () {
<<<<<<< HEAD
			Connection = DependencyService.Get<ISQLite> ().GetConnection ();

			// Check if Thread table exists, if not create it
			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(DailyWaterIntake).Name)) {
				Connection.CreateTable<DailyWaterIntake> ();
				Connection.Commit ();
			}

			// Check if UserComment table exists, if not create it
			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(Goals).Name)) {
				Connection.CreateTable<Goals> ();
				Connection.Commit ();
			}
=======
			database = DependencyService.Get<ISQLite> ().GetConnection ();

			// Check if Thread table exists, if not create it
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(DWI).Name)) {
				database.CreateTable<DWI> ();
				database.Commit ();
			}
		}

		public int InsertOrUpdateDWI(DWI log){
			return database.Table<DWI> ().Where (x => x.TheDate == DateTime.Today).Any() 
				? database.Update (log) : database.Insert (log);
>>>>>>> 57bb616c261a9ee8a359512da4ec7cff02f58de2
		}

		/// <summary>
		/// Gets water intake
		/// </summary>
		/// <returns>Water Intake</returns>
			//public List<DailyWaterIntake> GetIntake(DateTime date) {
			//var value = Connection.Query<DailyWaterIntake> ("Select * from DailyWaterIntake where DateTime like ?", date).ToList();
				//return value;
		//}

		/// <summary>
		/// Inserts water intake
		/// </summary>
		/// <returns>true if successful, false otherwise.</returns>
		/// <param name="thread">Thread.</param>
			//public int InsertWaterIntake(DailyWaterIntake intake) {
			//return Connection.Table<DailyWaterIntake> ().Where (x => x.date == intake.date).Any() 
				//? Connection.Update (intake) : Connection.Insert (intake);
		//}



<<<<<<< HEAD
		//
		public int InsertGoals(Goals goals) {
			return Connection.Insert (goals);
		}

		public List<Goals> GetGoals() {
			var items = Connection.Table<Goals>().ToList();
			return items;
		}
=======

>>>>>>> 57bb616c261a9ee8a359512da4ec7cff02f58de2




	}
}

