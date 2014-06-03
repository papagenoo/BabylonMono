using System;

namespace Babylon
{
	public class PopulateInMemoryDatabaseWithSampleDataCmd : Cmd
	{
		InMemoryDatabase db;

		public PopulateInMemoryDatabaseWithSampleDataCmd (InMemoryDatabase db)
		{
			this.db = db;
		}

		#region Transaction implementation

		public void Execute ()
		{
			int lessonNumber = 1;
			db.AddPhrase (lessonNumber, new Phrase ("Das Restaurant", "Ресторан", "audio/lesson1/00_Das_Restaurant.mp3"));
			db.AddPhrase (lessonNumber, new Phrase ("Ich bin sehr mude", "Я очень устал,", "audio/lesson1/01_Ich_bin_sehr_mude.mp3"));
			db.AddPhrase (lessonNumber, new Phrase ("und ich habe Hunger", "и я голоден.", "audio/lesson1/02_und_ich_habe_Hunger.mp3"));
			db.AddPhrase (lessonNumber, new Phrase ("Dort ist ein Restaurant", "Там (есть) ресторан", "audio/lesson1/03_Dort_ist_ein_Restaurant.mp3"));
			db.AddPhrase (lessonNumber, new Phrase ("Es ist schon nicht wahr", "Он красив, не правда ли?", "audio/lesson1/04_Es_ist_schon_nicht_wahr.mp3"));
			db.AddPhrase (lessonNumber, new Phrase ("Ja aber...", "Да... но...", "audio/lesson1/05_Ja_aber.mp3"));
			db.AddPhrase (lessonNumber, new Phrase ("Haben Sie auch Hunger", "Вы (ведь) тоже голодны?", "audio/lesson1/06_Haben_Sie_auch_Hunger.mp3"));
		}

		#endregion
	}
}

