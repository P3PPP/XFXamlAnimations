using System;
using System.Threading.Tasks;

namespace Xamarin.Forms.XamlAnimations
{
	/// <summary>
	/// RotationX animation using Xamarin.Forms.ViewExtensions.RotateXTo method.
	/// </summary>
	[Preserve(AllMembers = true)]
	public class RotateXToAnimation : Animation
	{
		#region Rotation BindableProperty
		public static readonly BindableProperty RotationProperty =
			BindableProperty.Create<RotateXToAnimation,double>(p => p.Rotation, 0,
				propertyChanged: (bindable, oldValue, newValue) =>
				((RotateXToAnimation)bindable).Rotation = newValue);

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

			return Target.RotateXTo(Rotation, Duration, Easing);
		}
	}
}

