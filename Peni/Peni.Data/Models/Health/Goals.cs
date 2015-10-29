using System;
using SQLite.Net.Attributes;

namespace Peni
{
	public class Goals
	{
		[PrimaryKey, AutoIncrement] 
		public int id { get; set; }
		public string stepGoal { get; set; }
		public string waterGoal { get; set; }

		public Goals() {}

		public Goals (string stepGoal, string waterGoal) {
			this.stepGoal = stepGoal;
			this.stepGoal = stepGoal;

		}
			
	}
}

