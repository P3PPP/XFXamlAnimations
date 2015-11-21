using System;

using Xamarin.Forms;

namespace Sample
{
	public class App : Application
	{
		public App()
		{
			XFXamlAnimations.XamlAnimations.Init();
			MainPage = new TabbedPage {
				Children = {
					new ViewExtentionsAnimationPage {
						Title = "ViewExtentions animaton"
					},
					new PropertynAnimationPage {
						Title = "Property animation"
					},
				},
			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

