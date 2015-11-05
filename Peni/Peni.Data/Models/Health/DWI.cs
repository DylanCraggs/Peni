using System;
using SQLite.Net.Attributes;

namespace Peni
{
	public class DWI
	{

		[PrimaryKey]
		public DateTime TheDate { get; set;}
		public int WaterIntake { get; set; }

		public DWI(){
		}

		public DWI (DateTime TheDate, int WaterIntake)
		{
			this.TheDate = TheDate;
			this.WaterIntake = WaterIntake;
		}
	}
}

