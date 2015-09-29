using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace Peni
{
	public class FloatingActionButtonView : View
	{
		/// <summary>
		/// The image name property.
		/// </summary>
		public static readonly BindableProperty ImageNameProperty = BindableProperty.Create<FloatingActionButtonView,string>( p => p.ImageName, string.Empty);
		public string ImageName 
		{
			get { return (string)GetValue (ImageNameProperty); } 
			set { SetValue (ImageNameProperty, value); } 
		}

		/// <summary>
		/// The color normal property.
		/// </summary>
		public static readonly BindableProperty ColorNormalProperty = BindableProperty.Create<FloatingActionButtonView,Color>( p => p.ColorNormal, Color.White);
		public Color ColorNormal 
		{
			get { return (Color)GetValue (ColorNormalProperty); } 
			set { SetValue (ColorNormalProperty, value); } 
		}

		/// <summary>
		/// The color pressed property.
		/// </summary>
		public static readonly BindableProperty ColorPressedProperty = BindableProperty.Create<FloatingActionButtonView,Color>( p => p.ColorPressed, Color.White);
		public Color ColorPressed 
		{
			get { return (Color)GetValue (ColorPressedProperty); } 
			set { SetValue (ColorPressedProperty, value); } 
		}

		/// <summary>
		/// The color ripple property.
		/// </summary>
		public static readonly BindableProperty ColorRippleProperty = BindableProperty.Create<FloatingActionButtonView,Color>( p => p.ColorRipple, Color.White);
		public Color ColorRipple 
		{
			get { return (Color)GetValue (ColorRippleProperty); } 
			set { SetValue (ColorRippleProperty, value); } 
		}

		/// <summary>
		/// The size property.
		/// </summary>
		public static readonly BindableProperty SizeProperty = BindableProperty.Create<FloatingActionButtonView,FloatingActionButtonSize>( p => p.Size, FloatingActionButtonSize.Normal);
		public FloatingActionButtonSize Size 
		{
			get { return (FloatingActionButtonSize)GetValue (SizeProperty); } 
			set { SetValue (SizeProperty, value); } 
		}

		/// <summary>
		/// The has shadow property.
		/// </summary>
		public static readonly BindableProperty HasShadowProperty = BindableProperty.Create<FloatingActionButtonView,bool>( p => p.HasShadow, true);
		public bool HasShadow 
		{
			get { return (bool)GetValue (HasShadowProperty); } 
			set { SetValue (HasShadowProperty, value); } 
		}


		public delegate void ShowHideDelegate(bool animate = true);
		public delegate void AttachToListViewDelegate(ListView listView);

		public ShowHideDelegate Show { get; set; }
		public ShowHideDelegate Hide { get; set; }
		public Action<object, EventArgs> Clicked { get; set; }
	}
}

