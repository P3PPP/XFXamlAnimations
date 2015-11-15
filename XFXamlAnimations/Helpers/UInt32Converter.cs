using System;

namespace Xamarin.Forms.XamlAnimations
{
	[Preserve(AllMembers = true)]
	public class UInt32Converter : TypeConverter
	{
		public override bool CanConvertFrom(Type sourceType)
		{
			return sourceType == typeof(string);
		}

		public override object ConvertFrom(System.Globalization.CultureInfo culture, object value)
		{
			try
			{
				return UInt32.Parse(value as string);
			}
			catch(Exception ex)
			{
				throw new InvalidOperationException(
					string.Format(@"Conversion failed: ""{0}"" into {1}", value, typeof(UInt32)), ex);
			}
		}
	}
}

