using System;
using System.Threading.Tasks;

namespace Xamarin.Forms.XamlAnimations
{
	/// <summary>
	/// Rotation animation using Xamarin.Forms.ViewExtensions.RotateTo method.
	/// </summary>
	[Preserve(AllMembers = true)]
	public class RotateToAnimation : Animation
	{
		#region Rotation BindableProperty
		public static readonly BindableProperty RotationProperty =
			BindableProperty.Create<RotateToAnimation,double>(p => p.Rotation, 0,
				propertyChanged: (bindable, oldValue, newValue) =>
				((RotateToAnimation)bindable).Rotation = newValue);

		/// <summary>
		/// Gets or sets the rotation.
		/// </summary>
		public double Rotation
		{
			get { return (double)GetValue(RotationProperty); }
			set { SetValue(RotationProperty, value); } 
		}
		#endregion

		protected override Task BeginAnimation()
		{
			if(Target == null)
			{
				throw new NullReferenceException("Target property can not be null.");
			}

			return Target.RotateTo(Rotation, Duration, Easing);
		}
	}
}

