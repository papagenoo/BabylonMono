﻿using System;
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
		Database db;
		int lessonNumber = 1;

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

			db = new InMemoryDatabase ();

			new PopulateInMemoryDatabaseWithSampleDataCmd (db as InMemoryDatabase)
				.Execute ();

			this.Title = "Custom Title";
			presenter = new PhrasesPresenterIml (this, soundPlayer, db, lessonNumber);

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
			presenter.PlaySoundChosen ();
//			var filename = Path.Combine("Audio", "2.mp3");
//			player.Play(filename);
		}

		partial void NextButtonClicked (NSObject sender)
		{
			presenter.NextChosen();
		}

		partial void PrevButtonClicked (NSObject sender)
		{
			presenter.PreviousChosen();
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

