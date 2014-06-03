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
			presenter = new PhrasesPresenter (this, soundPlayer);

			prevButton.Click += delegate {
				presenter.PrevChoosen();
			};

			nextButton.Click += delegate {
				presenter.NextChoosen();
			};

			listenButton.Click += delegate {
				presenter.PlayChoosen();
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