using System;
using Xamarin.Forms;

namespace XFXamlAnimations
{
	/// <summary>
	/// Animation that changes the Color type property.
	/// </summary>
	[Preserve(AllMembers = true)]
	public class ColorAnimation : PropertyAnimation<Color>
	{
		protected override Func<double, Color> GetTransformFunction()
		{
			return (t) =>
				Color.FromHsla(
					From.Hue + t * (To.Hue - From.Hue),
					From.Saturation + t * (To.Saturation - From.Saturation),
					From.Luminosity + t * (To.Luminosity - From.Luminosity),
					From.A + t * (To.A - From.A));
		}
	}
}

