using System;
using NUnit.Framework;

namespace Babylon.Test
{
	public class InMemoryPhrasesDatabaseTest
	{
		InMemoryDatabase db;

		Phrase phrase1;
		Phrase phrase2;
		Phrase phrase3;

		[TestFixtureSetUp ()]
		public void SetUpOnce ()
		{
			Logger.Instance = new LoggerIml ();
		}

		[SetUp ()]
		public void SetUpEach ()
		{
			db = new InMemoryDatabase ();
			phrase1 = new Phrase ("Das Restaurant", "Ресторан", "audio/lesson1/00_Das_Restaurant.mp3");
			phrase2 = new Phrase ("Ich bin sehr mude", "Я очень устал,", "audio/lesson1/01_Ich_bin_sehr_mude.mp3");
			phrase3 = new Phrase ("1", "2", "3");
		}
		
		[Test ()]
		public void GetNoPhraseTest()
		{
			var phrasesFromDb = db.GetPhrasesByLesson (3);
			Assert.IsNotNull (phrasesFromDb);
			Assert.AreEqual (0, phrasesFromDb.Count);
		}
		
		[Test ()]
		public void AddOnePhraseTest()
		{
			db.AddPhrase (1, phrase1);
			var phrasesFromDb = db.GetPhrasesByLesson (1);
			Assert.IsNotNull (phrasesFromDb);
			Assert.AreEqual (1, phrasesFromDb.Count);
			var p1 = phrasesFromDb [0];
			Assert.IsTrue (phrase1.Equals(p1));
		}
		
		[Test ()]
		public void AddTwoPhrasesTest()
		{
			db.AddPhrase (1, phrase1);
			db.AddPhrase (1, phrase2);
			var phrasesFromDb = db.GetPhrasesByLesson (1);
			Assert.AreEqual (2, phrasesFromDb.Count);
			var p1 = phrasesFromDb [0];
			var p2 = phrasesFromDb [1];
			Assert.IsTrue (phrase1.Equals(p1));
			Assert.IsTrue (phrase2.Equals(p2));
		}	
			
		[Test ()]
		public void AddTwoPhrasesToFirstLessonAndOnePhraseToSecondTest()
		{
			db.AddPhrase (1, phrase1);
			db.AddPhrase (1, phrase2);
			db.AddPhrase (2, phrase3);

			var lesson1Phrases = db.GetPhrasesByLesson (1);
			Assert.AreEqual (2, lesson1Phrases.Count);
			var p1 = lesson1Phrases [0];
			var p2 = lesson1Phrases [1];
			Assert.IsTrue (phrase1.Equals(p1));
			Assert.IsTrue (phrase2.Equals(p2));

			var lesson2Phrases = db.GetPhrasesByLesson (2);
			Assert.AreEqual (1, lesson2Phrases.Count);
			p1 = lesson2Phrases [0];
			Assert.IsTrue (phrase3.Equals(p1));
		}
	}
}