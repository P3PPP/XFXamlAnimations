using System;
using System.Linq;
using System.Threading.Tasks;

namespace XFXamlAnimations
{
	/// <summary>
	/// ParallelStoryBoard plays children in parallel.
	/// </summary>
	public class ParallelStoryBoard : StoryBoard
	{
		protected override Task BeginAnimation()
		{
			var tasks =  Children.Select(x => x.Begin()).ToList();
			return Task.WhenAll(tasks);
		}
	}
}

