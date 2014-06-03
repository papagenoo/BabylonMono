using System;
using System.Collections.Generic;

namespace Babylon
{
	public class InMemoryDatabase : Database
	{
		IDictionary<int, IList<Phrase>> phrases = new Dictionary<int, IList<Phrase>>();

		#region Database implementation

		public IList<Phrase> GetPhrasesByLesson (int lessonNumber)
		{
			return phrases.ContainsKey (lessonNumber) ?
				phrases [lessonNumber] : new List<Phrase> ();
		}

		public void AddPhrase (int lessonNumber, Phrase phrase)
		{
			if (!phrases.ContainsKey (lessonNumber))
				phrases.Add (lessonNumber, new List<Phrase> ());
			phrases[lessonNumber].Add (phrase);
		}

		#endregion
	}
}

