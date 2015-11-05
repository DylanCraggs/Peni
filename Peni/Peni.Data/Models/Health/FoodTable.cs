using System;
using SQLite.Net.Attributes;

namespace Peni
{
	public class FoodTable
	{

		[PrimaryKey]
		public DateTime FoodDate { get; set;}
		public int CalorieIntake { get; set; }

		public FoodTable(){
		}

		public FoodTable (DateTime FoodDate, int CalorieIntake)
		{
			this.FoodDate = FoodDate;
			this.CalorieIntake = CalorieIntake;
		}
	}
}

