using System;

namespace XFXamlAnimations
{
	/// <summary>
	/// Animation that changes the Double type property.
	/// </summary>
	[Preserve(AllMembers = true)]
	public class DoubleAnimation : PropertyAnimation<double>
	{
		protected override Func<double, double> GetTransformFunction()
		{
			return (t) =>
				From + t * (To - From);
		}
	}
}

