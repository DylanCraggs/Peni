using System;
using SQLite.Net.Attributes;

namespace Peni
{
	public class DWI
	{

		[PrimaryKey]
		public DateTime TheDate { get; set;}
		public int CurrIntake { get; set; }

		public DWI(){
		}

		public DWI (DateTime TheDate, int CurrIntake)
		{
			this.TheDate = DateTime.Now.Date;
			this.CurrIntake = CurrIntake;
		}
	}
}

