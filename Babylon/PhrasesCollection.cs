using System;

namespace Babylon.Test
{
	public class PhrasesCollection
	{
		ArrayList collection = new ArrayList();

		int index = 0;

		public PhrasesCollection()
		{
			Add (new Phrase("Das Restaurant", "audio/lesson1/00_Das_Restaurant.mp3"));
			Add (new Phrase("Ich bin sehr mude", "audio/lesson1/01_Ich_bin_sehr_mude.mp3"));
			Add (new Phrase("und ich habe Hunger", "audio/lesson1/02_und_ich_habe_Hunger.mp3"));
			Add (new Phrase("Dort ist ein Restaurant", "audio/lesson1/03_Dort_ist_ein_Restaurant.mp3"));
			Add (new Phrase("Es ist schon nicht wahr", "audio/lesson1/04_Es_ist_schon_nicht_wahr.mp3"));
			Add (new Phrase("Ja aber...", "audio/lesson1/05_Ja_aber.mp3"));
			Add (new Phrase("Haben Sie auch Hunger", "audio/lesson1/06_Haben_Sie_auch_Hunger.mp3"));
		}

		public void Add(Phrase phrase) 
		{
			collection.Add (phrase);
		}

		int NextIndex
		{
			get 
			{
				if (index == collection.Count - 1)
					index = 0;
				return index++;
			}
		}

		int PrevIndex
		{
			get 
			{
				if (index == 0)
					index = collection.Count - 1;
				return index--;
			}
		}

		public Phrase Next
		{
			get
			{
				return collection [NextIndex] as Phrase;
			}
		}

		public Phrase Prev
		{
			get
			{
				return collection [PrevIndex] as Phrase;
			}
		}

	}
}

