using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xamarin.Forms.XamlAnimations
{
	/// <summary>
	/// A StoryBoard coordinates a set of timelines. StroryBoard plays children in parallel.
	/// </summary>
	[Preserve(AllMembers = true)]
	[ContentProperty("Children")]
	public class StoryBoard : Timeline
	{
		/// <summary>
		/// Gets the child Timelines.
		/// </summary>
		public List<Timeline> Children
		{
			get;
		} = new List<Timeline>();

		protected override Task BeginAnimation()
		{
			var tasks =  Children.Select(x => x.Begin()).ToList();
			return Task.WhenAll(tasks);
		}
	}
}

