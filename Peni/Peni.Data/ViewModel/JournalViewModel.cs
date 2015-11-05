using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using System.Diagnostics;
using Peni.Data.ViewModel;
using System.Collections.Generic;

using Peni.Data;
using Microsoft.Practices.ServiceLocation;

namespace Peni.Data
{
	public class JournalViewModel : ViewModelBase
	{

		private IMyNavigationService navigationService;


		public ICommand AddNewEntryPage { get ; set ; }

		public static ICommand NewThreadCommand { get; private set; }

		public static ICommand GoToThreadCommand { get; private set; }

		public static ICommand LeaveCommentCommand { get; private set; }

		public List<JournalTable> AllDeEntries {
			get { 
				var database = new HealthDatabase();
				return new List<JournalTable> (database.AllEntries ());
			}
			set { 
				RaisePropertyChanged (() => AllDeEntries);
			}
		}


		public JournalViewModel (IMyNavigationService navigationService)
		{
			this.navigationService = navigationService;


			AddNewEntryPage = new Command (() => {
				this.navigationService.NavigateToModal (ViewModelLocator.NewJournalKey);
			});
				
	}
				
				}
}
