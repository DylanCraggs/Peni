/* Reference http://chrisriesgo.com/material-design-fab-in-xamarin-forms/ */

using System;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Xamarin.Forms;
using Peni;
using Peni.Droid;
using com.refractored.fab;
using Android.Views;
using System.IO;
using System.Windows.Input;

[assembly: ExportRenderer (typeof (FloatingActionButtonView), typeof (FloatingActionButtonViewRenderer))]

namespace Peni.Droid
{
	public class FloatingActionButtonViewRenderer : ViewRenderer<FloatingActionButtonView, FrameLayout>
	{
		private const int MARGIN_DIPS = 20;
		private const int FAB_HEIGHT_NORMAL = 56;
		private const int FAB_HEIGHT_MINI = 40;
		private const int FAB_FRAME_HEIGHT_WITH_PADDING = (MARGIN_DIPS * 2) + FAB_HEIGHT_NORMAL;
		private const int FAB_FRAME_WIDTH_WITH_PADDING = (MARGIN_DIPS * 2) + FAB_HEIGHT_NORMAL;
		private const int FAB_MINI_FRAME_HEIGHT_WITH_PADDING = (MARGIN_DIPS * 2) + FAB_HEIGHT_MINI;
		private const int FAB_MINI_FRAME_WIDTH_WITH_PADDING = (MARGIN_DIPS * 2) + FAB_HEIGHT_MINI;
		private readonly Android.Content.Context context;
		private readonly FloatingActionButton fab;

		/// <summary>
		/// Initializes a new instance of the <see cref="Peni.Droid.FloatingActionButtonViewRenderer"/> class.
		/// </summary>
		public FloatingActionButtonViewRenderer()
		{
			context = Xamarin.Forms.Forms.Context;

			float d =  context.Resources.DisplayMetrics.Density;
			var margin = (int)(MARGIN_DIPS * d); // margin in pixels

			fab = new FloatingActionButton(context);
			var lp = new FrameLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
			lp.Gravity = GravityFlags.CenterVertical | GravityFlags.CenterHorizontal;
			lp.LeftMargin = margin;
			lp.TopMargin = margin;
			lp.BottomMargin = margin;
			lp.RightMargin = margin;
			fab.LayoutParameters = lp;
		}

		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="e">E.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<FloatingActionButtonView> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
				return;

			if (e.OldElement != null)
				e.OldElement.PropertyChanged -= HandlePropertyChanged;

			if (this.Element != null) {
				//UpdateContent ();
				this.Element.PropertyChanged += HandlePropertyChanged;
			}

			Element.Show = Show;
			Element.Hide = Hide;

			SetFabImage(Element.ImageName);
			SetFabSize(Element.Size);

			fab.ColorNormal = Element.ColorNormal.ToAndroid();
			fab.ColorPressed = Element.ColorPressed.ToAndroid();
			fab.ColorRipple = Element.ColorRipple.ToAndroid();
			fab.HasShadow = Element.HasShadow;
			fab.Click += Fab_Click;

			var frame = new FrameLayout(context);
			frame.RemoveAllViews();
			frame.AddView(fab);

			SetNativeControl (frame);
		}

		/// <summary>
		/// Show the specified animate.
		/// </summary>
		/// <param name="animate">If set to <c>true</c> animate.</param>
		public void Show(bool animate = true)
		{
			fab.Show(animate);
		}

		/// <summary>
		/// Hide the specified animate.
		/// </summary>
		/// <param name="animate">If set to <c>true</c> animate.</param>
		public void Hide(bool animate = true)
		{
			fab.Hide(animate);
		}

		/// <summary>
		/// Handles the property changed.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void HandlePropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Content") {
				Tracker.UpdateLayout ();
			} 
			else if (e.PropertyName == FloatingActionButtonView.ColorNormalProperty.PropertyName) 
			{
				fab.ColorNormal = Element.ColorNormal.ToAndroid();
			} 
			else if (e.PropertyName == FloatingActionButtonView.ColorPressedProperty.PropertyName) 
			{
				fab.ColorPressed = Element.ColorPressed.ToAndroid();
			} 
			else if (e.PropertyName == FloatingActionButtonView.ColorRippleProperty.PropertyName) 
			{
				fab.ColorRipple = Element.ColorRipple.ToAndroid();
			}
			else if (e.PropertyName == FloatingActionButtonView.ImageNameProperty.PropertyName) 
			{
				SetFabImage(Element.ImageName);
			}
			else if (e.PropertyName == FloatingActionButtonView.SizeProperty.PropertyName) 
			{
				SetFabSize(Element.Size);
			}
			else if (e.PropertyName == FloatingActionButtonView.HasShadowProperty.PropertyName) 
			{
				fab.HasShadow = Element.HasShadow;
			}
		}

		/// <summary>
		/// Sets the fab image.
		/// </summary>
		/// <param name="imageName">Image name.</param>
		void SetFabImage(string imageName)
		{
			if(!string.IsNullOrWhiteSpace(imageName))
			{
				try
				{
					var drawableNameWithoutExtension = Path.GetFileNameWithoutExtension(imageName);
					var resources = context.Resources;
					var imageResourceName = resources.GetIdentifier(drawableNameWithoutExtension, "drawable", context.PackageName);
					fab.SetImageBitmap(Android.Graphics.BitmapFactory.DecodeResource(context.Resources, imageResourceName));
				}
				catch(Exception ex)
				{
					throw new FileNotFoundException("There was no Android Drawable by that name.", ex);
				}
			}
		}

		/// <summary>
		/// Sets the size of the fab.
		/// </summary>
		/// <param name="size">Size.</param>
		void SetFabSize(FloatingActionButtonSize size)
		{
			if(size == FloatingActionButtonSize.Mini)
			{
				fab.Size = FabSize.Mini;
				Element.WidthRequest = FAB_MINI_FRAME_WIDTH_WITH_PADDING;
				Element.HeightRequest = FAB_MINI_FRAME_HEIGHT_WITH_PADDING;
			}
			else
			{
				fab.Size = FabSize.Normal;
				Element.WidthRequest = FAB_FRAME_WIDTH_WITH_PADDING;
				Element.HeightRequest = FAB_FRAME_HEIGHT_WITH_PADDING;
			}
		}

		/// <summary>
		/// Fabs the click.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void Fab_Click (object sender, EventArgs e)
		{
			var clicked = Element.Clicked;
			if(Element != null && clicked != null)
			{
				clicked(sender, e);
			}
		}
	}
}

