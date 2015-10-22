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
		
		SQLiteConnection Connection;
		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.HealthDatabase"/> class.
		/// </summary>
		/// 
		public HealthDatabase () {
			Connection = DependencyService.Get<ISQLite> ().GetConnection ();

			// Check if Thread table exists, if not create it
			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(DWI).Name)) {
				Connection.CreateTable<DWI> ();
				Connection.Commit ();
			}

			// Check if UserComment table exists, if not create it
			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(Goals).Name)) {
				Connection.CreateTable<Goals> ();
				Connection.Commit ();
			}
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



		//
		public int InsertGoals(Goals goals) {
			return Connection.Insert (goals);
		}

		public List<Goals> GetGoals() {
			var items = Connection.Table<Goals>().ToList();
			return items;
		}
	}
}

