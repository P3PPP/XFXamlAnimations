using System;
using System.Linq;
using System.Threading.Tasks;

namespace XFXamlAnimations
{
	/// <summary>
	/// SequentialStoryBoard plays children in sequential.
	/// </summary>
	public class SequentialStoryBoard : StoryBoard
	{
		protected override async Task BeginAnimation()
		{
			foreach(var child in Children)
			{
				await child.Begin();
			}
		}
	}
}

