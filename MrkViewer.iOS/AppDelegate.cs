using Foundation;
using UIKit;
using MrkViewer.Core;

namespace MrkViewer.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		MrkViewerApp _app;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			_app = new MrkViewerApp ();
			LoadApplication(_app);

			// https://dzone.com/articles/ios-file-association-preview

			return base.FinishedLaunching(app, options);
		}

		public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{

			string filePath = url.AbsoluteString.Substring (7);
			string fileName = url.PathComponents [url.PathComponents.Length - 1];

			string fileContent = System.IO.File.ReadAllText (filePath);

			_app.SetExternDocument(new Core.Services.MarkdownFile()
				{
					FileName = fileName,
					Content = fileContent
				});

			// Clean-up
			System.IO.File.Delete(filePath);

			return true;
		}

	
	}
}


