using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFXamlAnimations
{
	/// <summary>
	/// Bounds animation using Xamarin.Forms.ViewExtensions.LayoutTo method.
	/// </summary>
	[Preserve(AllMembers = true)]
	public class LayoutToAnimation : Animation
	{
		#region Bounds BindableProperty
		public static readonly BindableProperty BoundsProperty =
			BindableProperty.Create<LayoutToAnimation,Rectangle>(p => p.Bounds, default(Rectangle),
				propertyChanged: (bindable, oldValue, newValue) =>
				((LayoutToAnimation)bindable).Bounds = newValue);

		/// <summary>
		/// Gets or sets the bounds.
		/// </summary>
		public Rectangle Bounds
		{
			get { return (Rectangle)GetValue(BoundsProperty); }
			set { SetValue(BoundsProperty, value); } 
		}
		#endregion

		protected override Task BeginAnimation()
		{
			if(Target == null)
			{
				throw new NullReferenceException("Target property can not be null.");
			}

			return Target.LayoutTo(Bounds, Duration, Easing);
		}
	}
}

