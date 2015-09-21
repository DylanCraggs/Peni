using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Xamarin.Forms;
using System.Diagnostics;
using Peni.Data.ViewModel;

namespace Peni.Data
{
	public class ForumPageViewModel : ViewModelBase
	{
		public static ICommand NewThreadCommand { get; private set; }

		private IMyNavigationService navigationService;

		public ObservableCollection<Thread> ForumList {
			get { 
				var database = new ForumsDatabase(); 
				return new ObservableCollection<Thread>(database.GetAll());
			}
		}

		public ForumPageViewModel(IMyNavigationService navigationService) {
			this.navigationService = navigationService;
			NewThreadCommand = new Command (() => {
				this.navigationService.NavigateTo(ViewModelLocator.ForumsNewThreadPageKey);
			});
		}

		public void OnAppearing(){
			RaisePropertyChanged (() => ForumList);
		}
	}
}

