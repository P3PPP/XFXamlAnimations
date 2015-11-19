using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFXamlAnimations
{
	/// <summary>
	/// TranslationX and TranslationY animation using Xamarin.Forms.ViewExtensions.TranslateTo method.
	/// </summary>
	[Preserve(AllMembers = true)]
	public class TranslateToAnimation : Animation
	{
		#region X BindableProperty
		public static readonly BindableProperty XProperty =
			BindableProperty.Create<TranslateToAnimation,double>(p => p.X, 0,
				propertyChanged: (bindable, oldValue, newValue) =>
				((TranslateToAnimation)bindable).X = newValue);

		/// <summary>
		/// Gets or sets the x.
		/// </summary>
		public double X
		{
			get { return (double)GetValue(XProperty); }
			set { SetValue(XProperty, value); } 
		}
		#endregion

		#region Y BindableProperty
		public static readonly BindableProperty YProperty =
			BindableProperty.Create<TranslateToAnimation,double>(p => p.Y, 0,
				propertyChanged: (bindable, oldValue, newValue) =>
				((TranslateToAnimation)bindable).Y = newValue);

		/// <summary>
		/// Gets or sets the y.
		/// </summary>
		public double Y
		{
			get { return (double)GetValue(YProperty); }
			set { SetValue(YProperty, value); } 
		}
		#endregion

		protected override Task BeginAnimation()
		{
			if(Target == null)
			{
				throw new NullReferenceException("Target property can not be null.");
			}

			return Target.TranslateTo(X, Y, Duration, Easing);
		}
	}
}

