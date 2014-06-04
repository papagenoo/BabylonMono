using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;
using Android.Content.Res;
using System.Collections.Generic;
using System.Collections;
using Babylon.UI;

namespace Babylon.Android
{
	[Activity (Label = "Babylon.Android", MainLauncher = true)]
	public class MainActivity : Activity, PhrasesView
	{
		TextView phraseTextView;
		TextView translationTextView;
		PhrasesPresenter presenter;
		Database db;
		int lessonNumber = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			Button prevButton = FindViewById<Button> (Resource.Id.prevButton);
			Button nextButton = FindViewById<Button> (Resource.Id.nextButton);
			Button listenButton = FindViewById<Button> (Resource.Id.listenButton);

			phraseTextView = FindViewById<TextView> (Resource.Id.phraseTextView);
			translationTextView = FindViewById<TextView> (Resource.Id.translationTextView);

			SoundPlayer soundPlayer = new SoundPlayerIml (Assets);

			db = new InMemoryDatabase ();

			new PopulateInMemoryDatabaseWithSampleDataCmd (db as InMemoryDatabase)
				.Execute ();

			presenter = new PhrasesPresenterIml (this, soundPlayer, db, lessonNumber);

			prevButton.Click += delegate {
				presenter.PreviousChosen();
			};

			nextButton.Click += delegate {
				presenter.NextChosen();
			};

			listenButton.Click += delegate {
				presenter.PlaySoundChosen();
			};
		}

		public string Text {
			set {
				phraseTextView.Text = value;
			}
		}

		public string Translation {
			set {
				translationTextView.Text = value;
			}
		}
	}
}