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
	public class JournalEntryViewModel : ViewModelBase
	{
		private IMyNavigationService navigationService;

		public ICommand ImaHappy { get; private set; }
		public ICommand ImaNothing { get; private set; }
		public ICommand ImaSad { get; private set; }
		public ICommand SaveEntryCommand {get; private set; }
		public ICommand CancelCommand {get; private set; }

		public string StringTimeStamp { 
			get {
				var pa = DateTime.Now.DayOfWeek.ToString ();
				var pb = DateTime.Now.Day.ToString ();
				var pc = DateTime.Now.Month.ToString ();
				var pd = DateTime.Now.Year.ToString ();
				switch (pc) {
				case "1":
					pc = " January ";
					break;
				case "2":
					pc = " Febuary ";
					break;
				case "3":
					pc = " March ";
					break;
				case "4":
					pc = " April ";
					break;
				case "5":
					pc = " May ";
					break;
				case "6":
					pc = " June ";
					break;
				case "7":
					pc = " July ";
					break;
				case "8":
					pc = " August ";
					break;
				case "9":
					pc = " September ";
					break;
				case "10":
					pc = " October ";
					break;
				case "11":
					pc = " November ";
					break;
				case "12":
					pc = " December ";
					break;
				}
				return pa + ", " + pb + pc + pd;
			} 
			set { RaisePropertyChanged (() => StringTimeStamp); } 
		}

			private string entryFromEntry;
			public string EntryFromEntry { 
				get { return entryFromEntry;}
				set { entryFromEntry = value;
				RaisePropertyChanged (() => EntryFromEntry);
			}
			}

		private string feelingOMeter;

		public Xamarin.Forms.Color HappyBackground {
			get {
				switch (feelingOMeter) {
				case "happy.png":
					return Xamarin.Forms.Color.Black ;
				default:
					return Xamarin.Forms.Color.White ;
				}
			}
			set { RaisePropertyChanged (() => HappyBackground); }

		}

		public Xamarin.Forms.Color NothingBackground {
			get {
				switch (feelingOMeter) {
				case "nullface.png":
					return Xamarin.Forms.Color.Black;
				default:
					return Xamarin.Forms.Color.White;
				}
			}
			set { RaisePropertyChanged (() => NothingBackground); }
		}

		public Xamarin.Forms.Color SadBackground {
			get {
				switch (feelingOMeter) {
				case "sad.png":
					return Xamarin.Forms.Color.Black;
				default:
					return Xamarin.Forms.Color.White;
				}
			}
			set { RaisePropertyChanged (() => SadBackground); }
		}

		public JournalEntryViewModel (IMyNavigationService navigationService)
		{
			var database = new HealthDatabase();

			this.navigationService = navigationService;

			feelingOMeter = "nullface.png";

			ImaHappy = new Command (() => {
				feelingOMeter = "happy.png";
				RaisePropertyChanged (() => HappyBackground);
				RaisePropertyChanged (() => NothingBackground);
				RaisePropertyChanged (() => SadBackground);
			});
			ImaNothing= new Command (() => {
				feelingOMeter = "nullface.png";
				RaisePropertyChanged (() => HappyBackground);
				RaisePropertyChanged (() => NothingBackground);
				RaisePropertyChanged (() => SadBackground);
			});
			ImaSad= new Command (() => {
				feelingOMeter = "sad.png";
				RaisePropertyChanged (() => HappyBackground);
				RaisePropertyChanged (() => NothingBackground);
				RaisePropertyChanged (() => SadBackground);
			});

			CancelCommand = new Command (() => {
				this.navigationService.NavigateToModal(ViewModelLocator.JournalKey);
			});


			// Saves stuff in the database
			SaveEntryCommand = new Command (() => {
				database.NewJournalEntry(StringTimeStamp, feelingOMeter, entryFromEntry);
				feelingOMeter="nullface.png";
				RaisePropertyChanged (() => HappyBackground);
				RaisePropertyChanged (() => NothingBackground);
				RaisePropertyChanged (() => SadBackground);
				EntryFromEntry="";
				this.navigationService.NavigateToModal(ViewModelLocator.JournalKey);
			} );


		}
	}
}

