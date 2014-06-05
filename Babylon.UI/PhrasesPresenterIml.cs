using System;

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
		{
			this.view = view;
			this.player = player;
			this.db = db;
			this.lessonNumber = lessonNumber;

			stateMachine = new StateMachine (this);

			var phrases = db.GetPhrasesByLesson (lessonNumber);
			enumerator = phrases.GetLoopedTwoWayEnumerator ();
			enumerator.MoveNext ();
			Update ();
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
			player.Play (phrase.AudioFileName);
		}

		public void EnterAutoMode ()
		{
		}

		public void EnterManualMode ()
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
			PlaySoundStart ();
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