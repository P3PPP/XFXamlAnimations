using System;
using Xamarin.Forms;

namespace XFXamlAnimations
{
	/// <summary>
	/// Base class of animation that changes the property of the target.
	/// </summary>
	[Preserve(AllMembers = true)]
	public abstract class Animation : Timeline
	{
		#region Target BindableProperty
		public static readonly BindableProperty TargetProperty =
			BindableProperty.Create<Animation,VisualElement>(p => p.Target, null,
				propertyChanged: (bindable, oldValue, newValue) =>
				((Animation)bindable).Target = newValue);

		/// <summary>
		/// Gets or sets the target object.
		/// </summary>
		public VisualElement Target
		{
			get { return (VisualElement)GetValue(TargetProperty); }
			set { SetValue(TargetProperty, value); } 
		}
		#endregion

		#region Duration BindableProperty
		public static readonly BindableProperty DurationProperty =
			BindableProperty.Create<Animation,uint>(p => p.Duration, 250,
				propertyChanged: (bindable, oldValue, newValue) =>
				((Animation)bindable).Duration = newValue);

		/// <summary>
		/// Gets or sets the duration(millisecond) of the animation.
		/// </summary>
		[TypeConverter(typeof(UInt32Converter))]
		public uint Duration
		{
			get { return (uint)GetValue(DurationProperty); }
			set { SetValue(DurationProperty, value); } 
		}
		#endregion

		// Easing
		#region Easing BindableProperty
		public static readonly BindableProperty EasingProperty =
			BindableProperty.Create<Animation,Easing>(p => p.Easing, null,
				propertyChanged: (bindable, oldValue, newValue) =>
				((Animation)bindable).Easing = newValue);

		/// <summary>
		/// Gets or sets the easing.
		/// </summary>
		[TypeConverter(typeof(EasingConverter))]
		public Easing Easing
		{
			get { return (Easing)GetValue(EasingProperty); }
			set { SetValue(EasingProperty, value); } 
		}
		#endregion
	}
}

