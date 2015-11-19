using System;
using Xamarin.Forms;

namespace XFXamlAnimations
{
	[Preserve(AllMembers = true)]
	public class EasingConverter : TypeConverter
	{
		public override bool CanConvertFrom(Type sourceType)
		{
			return sourceType == typeof(string);
		}

		public override object ConvertFrom(System.Globalization.CultureInfo culture, object value)
		{
			if(value == null) { return null; }

			var str = value as string;
			if(str != null)
			{
				Easing easing = 
					str == "BounceIn"   ? Easing.BounceIn :
					str == "BounceOut"  ? Easing.BounceOut :
					str == "CubicIn"    ? Easing.CubicIn :
					str == "CubicInOut" ? Easing.CubicInOut :
					str == "CubicOut"   ? Easing.CubicOut :
					str == "Linear"     ? Easing.Linear :
					str == "SinIn"      ? Easing.SinIn :
					str == "SinInOut"   ? Easing.SinInOut :
					str == "SinOut"     ? Easing.SinOut :
					str == "SpringIn"   ? Easing.SpringIn :
					str == "SpringOut"  ? Easing.SpringOut :
					null;

				if(easing != null)
				{
					return easing;
				}
			}

			throw new InvalidOperationException(
				string.Format(@"Conversion failed: ""{0}"" into {1}", value, typeof(Easing)));
		}
	}
}
