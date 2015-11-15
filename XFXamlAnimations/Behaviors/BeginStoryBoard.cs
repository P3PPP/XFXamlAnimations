using System;

namespace Xamarin.Forms.XamlAnimations
{
	/// <summary>
	/// TriggerAction for beginning the StoryBoard.
	/// </summary>
	[Preserve(AllMembers = true)]
	public class BeginStoryBoard : TriggerAction<VisualElement>
	{
		/// <summary>
		/// Gets or sets the story board.
		/// </summary>
		public StoryBoard StoryBoard
		{
			get;
			set;
		}

		/// <summary>
		/// Begins the StoryBoard if it is not running.
		/// </summary>
		protected override void Invoke(VisualElement sender)
		{
			if(StoryBoard != null && !StoryBoard.IsRunning)
			{
				StoryBoard.Begin();
			}
		}
	}
}

