// I AM THE QUEEN OF SQL
// BOW DOWN BITCHES
// #FLAWLESS

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

		// Initializes a new instance of the <see cref="Peni.Data.HealthDatabase"/> class.
		public HealthDatabase () {
			Connection = DependencyService.Get<ISQLite> ().GetConnection ();

			// Check if the DWI (DailyWaterIntake) table exists, if not create it
			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(DWI).Name)) {
				Connection.CreateTable<DWI> ();
				Connection.Commit ();
			}

			// Check if the JournalTable exists, if not create it
			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(JournalTable).Name)) {
				Connection.CreateTable<JournalTable> ();
				Connection.Commit ();
			}

			// Check if the FoodTable exists, if not create it
			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(FoodTable).Name)) {
				Connection.CreateTable<FoodTable> ();
				Connection.Commit ();
			}

			// Check if the Goals table exists, if not create it
			if (Connection.TableMappings.All(t => t.MappedType.Name != typeof(GoalsTable).Name)) {
				Connection.CreateTable<GoalsTable> ();
				Connection.Commit ();
			}

			// Stuff and things
			database = DependencyService.Get<ISQLite> ().GetConnection ();

		}
// Water functions
		// Instead of using the update function, I have chosen to use Delete and Insert
		// SQL and Xamarin are behind the times (literally) with DateTime, and store all dates
		// and times at 1400 for the previous date. WTF you guys?! Don't you learn this shit in primary school?!
		// This correlates with checking that the dates are the same in the VM.
		// #queenofSQL
		public void UpdateDateUp (int waterintakeagain) {
			database.Query<DWI> ("Delete from DWI where TheDate is ?", DateTime.Now.Date);
			var newrecord = new DWI { TheDate=DateTime.Now.AddHours(10), WaterIntake=waterintakeagain };
			database.Insert (newrecord);
		}

		// Creates a new record in the DWI Table
		public void NewDay () {
			var newrecord = new DWI { TheDate=DateTime.Now.AddHours(10), WaterIntake=0 };
			database.Insert (newrecord);
		}

		// Returns how much you drunk on the last day you were drinking.
		// This would be cooler if it was called TequilaDrunk
		public List<DWI> WaterDrunk(){
			return database.Query<DWI> ("Select TheDate, WaterIntake from DWI Order by TheDate DESC Limit 1").ToList ();
		}

// Food Functions
		public void FoodUpdate (int infoodintake) {
			database.Query<FoodTable> ("Delete from FoodTable where FoodDate is ?", DateTime.Now.Date);
			var newrecord = new FoodTable { FoodDate=DateTime.Now.AddHours(10), CalorieIntake=infoodintake };
			database.Insert (newrecord);
		}

		// Creates a new record in the DWI Table
		public void NewFoodDay () {
			var newrecord = new FoodTable { FoodDate=DateTime.Now.AddHours(10), CalorieIntake=0 };
			database.Insert (newrecord);
		}

		// Returns how much you drunk on the last day you were drinking.
		// This would be cooler if it was called TequilaDrunk
		public List<FoodTable> FoodQuery(){
			return database.Query<FoodTable> ("Select FoodDate, CalorieIntake from FoodTable Order by FoodDate DESC Limit 1").ToList ();
		}


// Feelings Functions

		public List<JournalTable> AllEntries(){
			var items = database.Table<JournalTable> ().ToList<JournalTable>();
			return items;
		}

		public void NewJournalEntry (string stringDate, string inRank, string inEntry) {
			var newentry = new JournalTable { EntryDate=stringDate, Rank=inRank, JournalEntry=inEntry, RecentEntry=DateTime.Now.AddHours(10) };
			database.Insert (newentry);
		}

		public List<JournalTable> AvgFeeling(){
			return database.Query<JournalTable> ("Select Rank from JournalTable Order by DBID DESC").ToList ();
		}

		public List<JournalTable> LastEntry(){
			return database.Query<JournalTable> ("Select RecentEntry from JournalTable Order by RecentEntry DESC Limit 1").ToList ();
		}

	

//Goals Functions
		public void NewGoals () {
			var newgoalrecord = new GoalsTable { WaterGoal=2000, FoodGoal=1200 };
			database.Insert (newgoalrecord);
		}

		public List<GoalsTable> GoalsQuery(){
			return database.Query<GoalsTable> ("Select WaterGoal, FoodGoal from GoalTable").ToList ();
		}
	}
}

