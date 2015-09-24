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
		/// <summary>
		/// Gets/sets the new thread command.
		/// </summary>
		/// <value>The new thread command.</value>
		public static ICommand NewThreadCommand { get; private set; }

		/// <summary>
		/// The navigation service.
		/// </summary>
		private IMyNavigationService navigationService;

		/// <summary>
		/// Gets/sets the forum list.
		/// </summary>
		/// <value>The forum list.</value>
		public ObservableCollection<Thread> ForumList {
			get { 
				var database = new ForumsDatabase(); 
				return new ObservableCollection<Thread>(database.GetAll());
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Data.ForumPageViewModel"/> class.
		/// </summary>
		/// <param name="navigationService">Navigation service.</param>
		public ForumPageViewModel(IMyNavigationService navigationService) {
			this.navigationService = navigationService;
			NewThreadCommand = new Command (() => {
				this.navigationService.NavigateTo(ViewModelLocator.ForumsNewThreadPageKey);
			});
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		public void OnAppearing(){
			RaisePropertyChanged (() => ForumList);
		}
	}
}

