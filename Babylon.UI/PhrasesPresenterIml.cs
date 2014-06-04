using System;

namespace Babylon.UI
{
	public class PhrasesPresenterIml : PhrasesPresenter
	{
		PhrasesView view;
		SoundPlayer player;
		Database db;
		int lessonNumber;

		PhrasesStateMachine state;

		Phrase phrase;
		ILoopedTwoWayEnumerator<Phrase> enumerator;

		public PhrasesPresenterIml (PhrasesView view, SoundPlayer player, Database db, int lessonNumber)
		{
			this.view = view;
			this.player = player;
			this.db = db;
			this.lessonNumber = lessonNumber;

			state = new PhrasesStateMachine (this);

			var phrases = db.GetPhrasesByLesson (lessonNumber);
			enumerator = phrases.GetLoopedTwoWayEnumerator ();
			enumerator.MoveNext ();
			Update ();
		}

		#region PhrasesPresenter implementation


		public void NextChosen ()
		{
			state.Handle (PhrasesPresenterEvent.MoveNext);
		}

		public void PreviousChosen ()
		{
			state.Handle (PhrasesPresenterEvent.MovePrevious);
		}

		public void PlaySoundChosen ()
		{
			state.Handle (PhrasesPresenterEvent.PlaySound);
		}

		public void EnterAutoModeChosen ()
		{
			state.Handle (PhrasesPresenterEvent.EnterAutoMode);
		}

		public void ExitAutoModeChosen ()
		{
			state.Handle (PhrasesPresenterEvent.ExitAutoMode);
		}

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
		public void PlaySound ()
		{
			player.Play (phrase.AudioFileName);
		}

		public void EnterAutoMode ()
		{
		}

		public void ExitAutoMode ()
		{
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
			PlaySound ();
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