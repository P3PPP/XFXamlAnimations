using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFXamlAnimations
{
	/// <summary>
	/// A StoryBoard coordinates a set of timelines.
	/// </summary>
	[Preserve(AllMembers = true)]
	[ContentProperty("Children")]
	public abstract class StoryBoard : Timeline
	{
		/// <summary>
		/// Gets the child Timelines.
		/// </summary>
		public List<Timeline> Children
		{
			get;
		} = new List<Timeline>();
	}
}

