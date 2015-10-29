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
		
		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.HealthDatabase"/> class.
		/// </summary>
		/// 
		public HealthDatabase () {
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
			
		public List<DWI> WaterDrunk() {
			return database.Query<DWI> ("Select WaterIntake from DWI where TheDate is ?", DateTime.Now.Date).ToList();
		}

		public List<DWI> AnyWaterToday() {
			return database.Query<DWI> ("Select a1.TheDate TheDate from DWI a1 inner join (select max(TheDate) TheDate from DWI) ij on a1.TheDate = ij.TheDate").ToList();
		}

		public List<DWI> AnyWaterTodayDB() {
			return database.Query<DWI> ("Select a1.TheDate from DWI a1 inner join (Select max(TheDate) as TheDate from DWI) ij on a1.TheDate = ij.TheDate").ToList();
		}



	}
}

