using System;
using System.Drawing;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Babylon.UI;

namespace Babylon.iOS
{

	public partial class Babylon_iOSViewController : UIViewController, PhrasesView
	{
		PhrasesPresenter presenter;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public Babylon_iOSViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SoundPlayer soundPlayer = new SoundPlayerIml ();
			presenter = new PhrasesPresenter (this, soundPlayer);

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		SoundPlayer player = new SoundPlayerIml();

		partial void PlaySoundButtonClicked (NSObject sender)
		{
			presenter.PlayChoosen();
//			var filename = Path.Combine("Audio", "2.mp3");
//			player.Play(filename);
		}

		partial void NextButtonClicked (NSObject sender)
		{
			presenter.NextChoosen();
		}

		partial void PrevButtonClicked (NSObject sender)
		{
			presenter.PrevChoosen();
		}

		#endregion

		#region PhrasesView implementation

		public string Text {
			set {
				TextLabel.Text = value;
			}
		}

		public string Translation {
			set {
				TranslationLabel.Text = value;
			}
		}

		#endregion
	}
}

