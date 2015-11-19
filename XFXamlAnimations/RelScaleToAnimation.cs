using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFXamlAnimations
{
	/// <summary>
	/// Scale animation using Xamarin.Forms.ViewExtensions.RelScaleTo method.
	/// </summary>
	[Preserve(AllMembers = true)]
	public class RelScaleToAnimation : Animation
	{
		#region Scale BindableProperty
		public static readonly BindableProperty ScaleProperty =
			BindableProperty.Create<RelScaleToAnimation,double>(p => p.Scale, 0,
				propertyChanged: (bindable, oldValue, newValue) =>
				((RelScaleToAnimation)bindable).Scale = newValue);

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

			return Target.RelScaleTo(Scale, Duration, Easing);
		}
	}
}

