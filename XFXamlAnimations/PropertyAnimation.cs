using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Xamarin.Forms.XamlAnimations
{
	/// <summary>
	/// Base class of the animation that changes a property.
	/// </summary>
	[Preserve(AllMembers = true)]
	public abstract class PropertyAnimation<T> : Animation
	{
		#region TargetPropertyName BindableProperty
		public static readonly BindableProperty TargetPropertyNameProperty =
			BindableProperty.Create<PropertyAnimation<T>,string>(p => p.TargetPropertyName, null,
				propertyChanged: (bindable, oldValue, newValue) =>
				((PropertyAnimation<T>)bindable).TargetPropertyName = newValue);

		/// <summary>
		/// Gets or sets the name of the target property.
		/// </summary>
		public string TargetPropertyName
		{
			get { return (string)GetValue(TargetPropertyNameProperty); }
			set { SetValue(TargetPropertyNameProperty, value); } 
		}
		#endregion

		#region From BindableProperty
		public static readonly BindableProperty FromProperty =
			BindableProperty.Create<PropertyAnimation<T>,T>(p => p.From, default(T),
				propertyChanged: (bindable, oldValue, newValue) =>
				((PropertyAnimation<T>)bindable).From = newValue);

		/// <summary>
		/// Gets or sets the start value of the target property.
		/// </summary>
		public T From
		{
			get { return (T)GetValue(FromProperty); }
			set { SetValue(FromProperty, value); } 
		}
		#endregion

		#region To BindableProperty
		public static readonly BindableProperty ToProperty =
			BindableProperty.Create<PropertyAnimation<T>,T>(p => p.To, default(T),
				propertyChanged: (bindable, oldValue, newValue) =>
				((PropertyAnimation<T>)bindable).To = newValue);

		/// <summary>
		/// Gets or sets the end value of the target property.
		/// </summary>
		public T To
		{
			get { return (T)GetValue(ToProperty); }
			set { SetValue(ToProperty, value); } 
		}
		#endregion

		/// <summary>
		/// Function to convert the animation progress into target property value.
		/// </summary>
		protected abstract Func<double, T> GetTransformFunction();

		protected override Task BeginAnimation()
		{
			var target = Target;
			if(target == null)
			{
				throw new NullReferenceException("Target property can not be null.");
			}

			var targetPropertyName = TargetPropertyName;
			if(targetPropertyName == null)
			{
				throw new NullReferenceException("TargetProperty property can not be null.");
			}

			var propertyInfo = target.GetType().GetRuntimeProperty(targetPropertyName);
			if(propertyInfo == null)
			{
				throw new Exception($"{target.GetType()} dose not have the {targetPropertyName} property.");
			}

			Action<T> callback =  value => {
				propertyInfo.SetValue(target, value);
			};

			return Animate(target, targetPropertyName,
				GetTransformFunction(), callback, Duration, Easing);
		}

		private static Task<bool> Animate<TPropertyType>(VisualElement view,
			string name,
			Func<double, TPropertyType> transform,
			Action<TPropertyType> callback,
			uint length,
			Easing easing)
		{
			easing = easing ?? Easing.Linear;
			var taskCompletionSource = new TaskCompletionSource<bool>();

			view.Animate<TPropertyType>(name, transform, callback, 16, length, easing, (value, canceled) =>
			{
				taskCompletionSource.SetResult(canceled);
			});

			return taskCompletionSource.Task;
		}
	}
}

