using System;
using SQLite.Net.Attributes;

namespace Peni
{
	public class GoalsTable
	{
		[PrimaryKey] 
		public int WaterGoal { get; set; }
		public int FoodGoal { get; set; }

		public GoalsTable() {}

		public GoalsTable (int WaterGoal, int FoodGoal) {
			this.WaterGoal = WaterGoal;
			this.FoodGoal = FoodGoal;
		}
			
	}
}

