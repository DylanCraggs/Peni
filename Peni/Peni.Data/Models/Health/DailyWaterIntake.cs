using System;
using SQLite.Net.Attributes;

namespace Peni
{
	public class DailyWaterIntake
	{

		[PrimaryKey]
		public DateTime date { get; set; }
		public float dailyIntake { get; set; }

		public DailyWaterIntake ()
		{
		}

		public DailyWaterIntake (float dailyIntake)
		{
			this.date = DateTime.Now;
			this.dailyIntake = dailyIntake;
		}
	}
}

