using System;
using Xamarin.Forms;
using GalaSoft.MvvmLight;

namespace Peni.Data
{
	public class FavoriteImage : ViewModelBase
	{
		private ImageSource favIcon;
		public ImageSource FavIcon { 
			get { return favIcon; } 
			set { favIcon = value;
				RaisePropertyChanged (() => FavIcon);
			}
		}

		private bool isFav;
		public bool IsFav {
			get { return isFav; }
			set { 
				isFav = value;
				RaisePropertyChanged (() => IsFav);
			}
		}
	}
}

