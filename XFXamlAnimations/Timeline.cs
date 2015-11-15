using System;
using System.Threading.Tasks;

namespace Xamarin.Forms.XamlAnimations
{
	/// <summary>
	/// Baseclass for animatable.
	/// </summary>
	[Preserve(AllMembers = true)]
	public abstract class Timeline : BindableObject
	{
		#region Delay BindableProperty
		public static readonly BindableProperty DelayProperty =
			BindableProperty.Create<Timeline,uint>(p => p.Delay, 0,
				propertyChanged: (bindable, oldValue, newValue) =>
				((Timeline)bindable).Delay = newValue);

		/// <summary>
		/// Gets or sets the delay(millisecond) before the start of the animation.
		/// </summary>
		[TypeConverter(typeof(UInt32Converter))]
		public uint Delay
		{
			get { return (uint)GetValue(DelayProperty); }
			set { SetValue(DelayProperty, value); } 
		}
		#endregion

		/// <summary>
		/// Gets a value indicating whether the animation is running.
		/// </summary>
		public bool IsRunning
		{
			get;
			private set;
		} = false;

		/// <summary>
		/// Occurs when animation completed.
		/// </summary>
		public event EventHandler Completed;

		/// <summary>
		/// Sets IsRunning to false and Raises the completed event.
		/// </summary>
		protected virtual void OnCompleted()
		{
			IsRunning = false;
			Completed?.Invoke(this, new EventArgs());
		}

		/// <summary>
		/// Subclass must begin own specific animation.
		/// </summary>
		protected abstract Task BeginAnimation();

		/// <summary>
		/// Begins animation after this instance's delay.
		/// </summary>
		public Task Begin()
		{
			return Begin(Delay);
		}

		/// <summary>
		/// Begins animation after the specified delay(millisecond).
		/// </summary>
		public async Task Begin(uint delay)
		{
			IsRunning = true;
			
			if(delay > 0)
			{
				await Task.Delay(TimeSpan.FromMilliseconds(delay));
			}

			await BeginAnimation();
			OnCompleted();
		}
	}
}

