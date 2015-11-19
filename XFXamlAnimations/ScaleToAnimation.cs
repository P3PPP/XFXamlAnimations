using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFXamlAnimations
{
	/// <summary>
	/// Scale animation using Xamarin.Forms.ViewExtensions.ScaleTo method.
	/// </summary>
	[Preserve(AllMembers = true)]
	public class ScaleToAnimation : Animation
	{
		#region Scale BindableProperty
		public static readonly BindableProperty ScaleProperty =
			BindableProperty.Create<ScaleToAnimation,double>(p => p.Scale, 0,
				propertyChanged: (bindable, oldValue, newValue) =>
				((ScaleToAnimation)bindable).Scale = newValue);

		/// <summary>
		/// Gets or sets the scale.
		/// </summary>
		public double Scale
		{
			get { return (double)GetValue(ScaleProperty); }
			set { SetValue(ScaleProperty, value); } 
		}
		#endregion

		protected override Task BeginAnimation()
		{
			if(Target == null)
			{
				throw new NullReferenceException("Target property can not be null.");
			}

			return Target.ScaleTo(Scale, Duration, Easing);
		}
	}
}

