using System;

namespace Babylon.UI
{
	public class PhrasesPresenterIml : PhrasesPresenter
	{
		PhrasesView view;
		SoundPlayer player;
		Database db;
		int lessonNumber;

		Phrase phrase;
		ILoopedTwoWayEnumerator<Phrase> enumerator;

		public PhrasesPresenterIml (PhrasesView view, SoundPlayer player, Database db, int lessonNumber)
		{
			this.view = view;
			this.player = player;
			this.db = db;
			this.lessonNumber = lessonNumber;

			var phrases = db.GetPhrasesByLesson (lessonNumber);
			enumerator = phrases.GetLoopedTwoWayEnumerator ();
			enumerator.MoveNext ();
			Update ();
		}

		#region PhrasesPresenter implementation

		public void NextChoosen ()
		{
			enumerator.MoveNext ();
			Update ();
		}

		public void PrevChoosen ()
		{
			enumerator.MovePrevious ();
			Update ();
		}

		public void PlayChoosen ()
		{
			PlaySound ();
		}

		public void StartAutoMode ()
		{
			throw new NotImplementedException ();
		}

		public void StopAutoMode ()
		{
			throw new NotImplementedException ();
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

		/// <summary>
		/// Plays the sound.
		/// </summary>
		void PlaySound ()
		{
			player.Play (phrase.AudioFileName);
		}
	}
}