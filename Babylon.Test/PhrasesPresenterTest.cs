using System;
using NUnit.Framework;
using Babylon.UI;
using System.Threading;

namespace Babylon.Test
{
	public class PhrasesPresenterTest
	{
		class PhrasesViewMock : PhrasesView
		{
			#region PhrasesView implementation

			public string Text { get; set; }
			public string Translation  { get; set; }

			#endregion
		}

		class SoundPlayerMock : SoundPlayerBase
		{
			public string PlayingFileName { get; private set; }
			public int PlayCounter { get; private set; }

			#region SoundPlayer implementation

			public override void Play (string filename)
			{
				PlayingFileName = filename;
				PlayCounter++;
			}

			#endregion
		}

		PhrasesViewMock view;
		SoundPlayerMock player;
		Database db;
		int lessonNumber = 1;

		PhrasesPresenter presenter;

		[TestFixtureSetUp ()]
		public void SetUpOnce ()
		{
			Logger.Instance = new LoggerIml ();
		}

		[SetUp ()]
		public void SetUpEach ()
		{
			view = new PhrasesViewMock ();
			player = new SoundPlayerMock ();

			db = new InMemoryDatabase ();

			new PopulateInMemoryDatabaseWithSampleDataCmd (db as InMemoryDatabase)
				.Execute ();

			presenter = new PhrasesPresenterIml (view, player, db, lessonNumber);
		}

		[Test ()]
		public void InitialStateTest()
		{
			Assert.AreEqual (1, player.PlayCounter);
			Assert.AreEqual ("Das Restaurant", view.Text);
			Assert.AreEqual ("Ресторан", view.Translation);
			Assert.AreEqual ("audio/lesson1/00_Das_Restaurant.mp3", player.PlayingFileName);
		}
		
		[Test ()]
		public void PlayChoosenTest()
		{
			Assert.AreEqual (1, player.PlayCounter);
			presenter.PlayChoosen ();
			Assert.AreEqual (2, player.PlayCounter);
			presenter.PlayChoosen ();
			Assert.AreEqual (3, player.PlayCounter);
			Assert.AreEqual ("Das Restaurant", view.Text);
			Assert.AreEqual ("Ресторан", view.Translation);
			Assert.AreEqual ("audio/lesson1/00_Das_Restaurant.mp3", player.PlayingFileName);
		}
		
		[Test ()]
		public void NextChoosenTest()
		{
			Assert.AreEqual ("Das Restaurant", view.Text);
			Assert.AreEqual ("Ресторан", view.Translation);
			Assert.AreEqual ("audio/lesson1/00_Das_Restaurant.mp3", player.PlayingFileName);
			Assert.AreEqual (1, player.PlayCounter);
			presenter.NextChoosen ();
			Assert.AreEqual (2, player.PlayCounter);
			Assert.AreEqual ("Ich bin sehr mude", view.Text);
			Assert.AreEqual ("Я очень устал,", view.Translation);
			Assert.AreEqual ("audio/lesson1/01_Ich_bin_sehr_mude.mp3", player.PlayingFileName);
			presenter.NextChoosen ();
			Assert.AreEqual (3, player.PlayCounter);
			Assert.AreEqual ("und ich habe Hunger", view.Text);
			Assert.AreEqual ("и я голоден.", view.Translation);
			Assert.AreEqual ("audio/lesson1/02_und_ich_habe_Hunger.mp3", player.PlayingFileName);
		}
		
		[Test ()]
		public void PrevChoosenTest()
		{
			Assert.AreEqual ("Das Restaurant", view.Text);
			Assert.AreEqual ("Ресторан", view.Translation);
			Assert.AreEqual ("audio/lesson1/00_Das_Restaurant.mp3", player.PlayingFileName);
			Assert.AreEqual (1, player.PlayCounter);
			presenter.PrevChoosen ();
			Assert.AreEqual ("Haben Sie auch Hunger", view.Text);
			Assert.AreEqual ("Вы (ведь) тоже голодны?", view.Translation);
			Assert.AreEqual ("audio/lesson1/06_Haben_Sie_auch_Hunger.mp3", player.PlayingFileName);
			Assert.AreEqual (2, player.PlayCounter);
		}
		
		[Test ()]
		public void SoundPlayerMockTest()
		{
			SoundPlayerMock player = new SoundPlayerMock ();
			bool playingFinishedWired = false;
			bool playingFinishedWired1 = false;

			player.PlayingFinished += (object sender, EventArgs e) => {
				playingFinishedWired = true;
			};			

			player.PlayingFinished += (object sender, EventArgs e) => {
				playingFinishedWired1 = true;
			};

			player.RaseFinishPlayingEvent ();

			Assert.That (playingFinishedWired, Is.True);
			Assert.That (playingFinishedWired1, Is.True);
		}
	}
}

