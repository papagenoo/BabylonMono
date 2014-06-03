using System;
using System.Collections.Generic;

namespace Babylon
{
	public interface Database
	{
		IList<Phrase> GetPhrasesByLesson(int number);
		void AddPhrase (int lessonNumber, Phrase phrase);
	}
}