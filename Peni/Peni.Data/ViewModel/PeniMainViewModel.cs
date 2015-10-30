using System;

namespace Peni.Data
{
	public class PeniMainViewModel
	{

		private IMyNavigationService navigationService;

		public PeniMainViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;
		}
	}
}

