// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Babylon.iOS
{
	[Register ("Babylon_iOSViewController")]
	partial class Babylon_iOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton AutoButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ManualButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton NextButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton PlayButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton PrevButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel TextLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel TranslationLabel { get; set; }

		[Action ("NextButtonClicked:")]
		partial void NextButtonClicked (MonoTouch.Foundation.NSObject sender);

		[Action ("playButtonClicked:")]
		partial void playButtonClicked (MonoTouch.Foundation.NSObject sender);

		[Action ("PlaySoundButtonClicked:")]
		partial void PlaySoundButtonClicked (MonoTouch.Foundation.NSObject sender);

		[Action ("PrevButtonClicked:")]
		partial void PrevButtonClicked (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (AutoButton != null) {
				AutoButton.Dispose ();
				AutoButton = null;
			}

			if (ManualButton != null) {
				ManualButton.Dispose ();
				ManualButton = null;
			}

			if (TextLabel != null) {
				TextLabel.Dispose ();
				TextLabel = null;
			}

			if (TranslationLabel != null) {
				TranslationLabel.Dispose ();
				TranslationLabel = null;
			}

			if (PrevButton != null) {
				PrevButton.Dispose ();
				PrevButton = null;
			}

			if (NextButton != null) {
				NextButton.Dispose ();
				NextButton = null;
			}

			if (PlayButton != null) {
				PlayButton.Dispose ();
				PlayButton = null;
			}
		}
	}
}
