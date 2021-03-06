﻿using System;

namespace Babylon.UI
{
	public class PhrasesPresenterIml : PhrasesPresenter
	{
		PhrasesView view;
		SoundPlayer player;
		Database db;
		int lessonNumber;

		StateMachine stateMachine;

		Phrase phrase;
		ILoopedTwoWayEnumerator<Phrase> enumerator;

		public PhrasesPresenterIml (PhrasesView view, SoundPlayer player, Database db, int lessonNumber)
			: this (view, player, db, lessonNumber, AwaitingInManualState.Instance)
		{
		}

		public PhrasesPresenterIml (PhrasesView view, SoundPlayer player, Database db, int lessonNumber, State initialState)
		{
			this.view = view;
			this.player = player;
			this.db = db;
			this.lessonNumber = lessonNumber;

			player.PlayingFinished += (s, e) =>
			{
				HandlePlaySoundStopEvent ();
//				new DelayedAction (() => {
//					//	HandleNextEvent ();
//				}, 5000);
				HandleTimeoutEvent ();
			};

			stateMachine = new StateMachine (this, initialState);

			var phrases = db.GetPhrasesByLesson (lessonNumber);

			enumerator = phrases.GetLoopedTwoWayEnumerator ();
			HandleNextEvent ();
		}
			
		#region PhrasesPresenter implementation

		public void MoveNext ()
		{
			enumerator.MoveNext ();
			Update ();
		}

		public void MovePrevious ()
		{
			enumerator.MovePrevious ();
			Update ();
		}

		/// <summary>
		/// Plays the sound.
		/// </summary>
		public void PlaySoundStart ()
		{
			Logger.Write ("PlaySoundStart");
			player.Play (phrase.AudioFileName);
		}


		public void PlaySoundStop ()
		{
		}

		public void EnterAutoMode ()
		{
			view.EnableManualModeButton ();
			view.DisableAutoModeButton ();

		}

		public void EnterManualMode ()
		{
			view.DisableManualModeButton ();
			view.EnableAutoModeButton ();
		}

		public void DelayAndRaseNextEvent ()
		{
			//throw new NotImplementedException ();
		}


		#endregion

		#region PhrasesPresenter implementation

		public void HandleNextEvent ()
		{
			stateMachine.RaseNextEvent ();
		}

		public void HandlePreviousEvent ()
		{
			stateMachine.RasePreviousEvent ();
		}

		public void HandlePlaySoundStartEvent ()
		{
			stateMachine.RasePlaySoundStartEvent ();
		}

		public void HandlePlaySoundStopEvent ()
		{
			stateMachine.RasePlaySoundStopEvent ();
		}

		public void HandleEnterAutoModeEvent ()
		{
			stateMachine.RaseEnterAutoModeEvent ();
		}

		public void HandleEnterManualModeEvent ()
		{
			stateMachine.RaseEnterManualModeEvent ();
		}

		public void HandleTimeoutEvent ()
		{
			stateMachine.RaseTimeoutEvent ();
		}

		#endregion
		
		/// <summary>
		/// Updates the presentator state: 
		/// updates the views and plays the sound
		/// </summary>
		void Update ()
		{
			phrase = enumerator.Current;
			UpdateView ();
			//PlaySoundStart ();
		}

		/// <summary>
		/// Updates the view.
		/// </summary>
		void UpdateView ()
		{
			view.Text = phrase.Text;
			view.Translation = phrase.Translation;
		}

	}
}