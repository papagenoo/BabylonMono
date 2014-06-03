using System;

namespace Babylon.UI
{
	public class PhrasesPresenter
	{
		PhrasesView view;
		SoundPlayer player;
		PhrasesCollection phrases;
		ILoopedTwoWayEnumerator<Phrase> enumerator;
		Phrase phrase;

		public PhrasesPresenter (PhrasesView view, SoundPlayer player)
		{
			this.view = view;
			this.player = player;

			phrases = new PhrasesCollection () {
				new Phrase ("Das Restaurant", "Ресторан", "audio/lesson1/00_Das_Restaurant.mp3"),
				new Phrase ("Ich bin sehr mude", "Я очень устал,", "audio/lesson1/01_Ich_bin_sehr_mude.mp3"),
				new Phrase ("und ich habe Hunger", "и я голоден.", "audio/lesson1/02_und_ich_habe_Hunger.mp3"),
				new Phrase ("Dort ist ein Restaurant", "Там (есть) ресторан", "audio/lesson1/03_Dort_ist_ein_Restaurant.mp3"),
				new Phrase ("Es ist schon nicht wahr", "Он красив, не правда ли?", "audio/lesson1/04_Es_ist_schon_nicht_wahr.mp3"),
				new Phrase ("Ja aber...", "Да... но...", "audio/lesson1/05_Ja_aber.mp3"),
				new Phrase ("Haben Sie auch Hunger", "Вы (ведь) тоже голодны?", "audio/lesson1/06_Haben_Sie_auch_Hunger.mp3")
			};

			enumerator = phrases.GetLoopedTwoWayEnumerator ();
			Init ();
		}

		void Init ()
		{
			enumerator.MoveNext();
			phrase = enumerator.Current;
			UpdateView ();
		}

		public void NextChoosen()
		{
			enumerator.MoveNext();
			phrase = enumerator.Current;
			UpdateView ();
		}

		public void PrevChoosen()
		{
			enumerator.MovePrevious();
			phrase = enumerator.Current;
			UpdateView ();
		}

		void UpdateView()
		{
			view.Text = phrase.Text;
			view.Translation = phrase.Translation;
			PlaySound ();
		}

		void PlaySound()
		{
			player.Play (phrase.AudioFileName);
		}

		public void PlayChoosen()
		{
			PlaySound ();
		}
	}
}

