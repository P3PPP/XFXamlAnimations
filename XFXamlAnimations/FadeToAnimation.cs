using System;
using System.Threading.Tasks;

namespace Xamarin.Forms.XamlAnimations
{
	/// <summary>
	/// Opacity animation using Xamarin.Forms.ViewExtensions.FadeTo method.
	/// </summary>
	[Preserve(AllMembers = true)]
	public class FadeToAnimation : Animation
	{
		#region Opacity BindableProperty
		public static readonly BindableProperty OpacityProperty =
			BindableProperty.Create<FadeToAnimation,double>(p => p.Opacity, 0,
				propertyChanged: (bindable, oldValue, newValue) =>
				((FadeToAnimation)bindable).Opacity = newValue);

		/// <summary>
		/// Gets or sets the opacity.
		/// </summary>
		public double Opacity
		{
			get { return (double)GetValue(OpacityProperty); }
			set { SetValue(OpacityProperty, value); } 
		}
		#endregion

		protected override Task BeginAnimation()
		{
			if(Target == null)
			{
				throw new NullReferenceException("Target property can not be null.");
			}

			return Target.FadeTo(Opacity, Duration, Easing);
		}
	}
}

