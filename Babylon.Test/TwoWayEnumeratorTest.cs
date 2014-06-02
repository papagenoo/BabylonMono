using System.Collections.Generic;
using NUnit.Framework;
using System;
using Babylon.UI;
using Babylon;

namespace Babylon.Test
{
	[TestFixture ()]
	public class TwoWayEnumeratorTest
	{
		[TestFixtureSetUp ()]
		public void SetUp ()
		{
			Logger.Instance = new LoggerIml ();
		}

		[Test ()]
		public void TestCase ()
		{
			IList<string> list = new System.Collections.Generic.List<string> {
				"First", "Second", "Third"
			};
			var enumerator = list.GetTwoWayEnumerator ();
			Assert.AreEqual (null, enumerator.Current);
			Assert.IsTrue (enumerator.MoveNext ());
			Assert.AreEqual ("First", enumerator.Current);
			Assert.IsTrue (enumerator.MoveNext ());
			Assert.AreEqual ("Second", enumerator.Current);
			Assert.IsTrue (enumerator.MoveNext ());
			Assert.AreEqual ("Third", enumerator.Current);
			Assert.IsFalse (enumerator.MoveNext ());
			Assert.AreEqual (null, enumerator.Current);
			Assert.IsFalse (enumerator.MoveNext ());
			Assert.AreEqual (null, enumerator.Current);
			// обратный ход
			Assert.IsTrue (enumerator.MovePrevious ());
			Assert.AreEqual ("Third", enumerator.Current);
			Assert.IsTrue (enumerator.MovePrevious ());
			Assert.AreEqual ("Second", enumerator.Current);
			Assert.IsTrue (enumerator.MovePrevious ());
			Assert.AreEqual ("First", enumerator.Current);
			Assert.IsFalse (enumerator.MovePrevious ());
			Assert.AreEqual (null, enumerator.Current);
			Assert.IsFalse (enumerator.MovePrevious ());
			Assert.AreEqual (null, enumerator.Current);
			Assert.IsTrue (enumerator.MoveNext ());
			Assert.AreEqual ("First", enumerator.Current);




			/*

			PhrasesCollection phrases = new PhrasesCollection();
			phrases = new PhrasesCollection ();
			phrases.Add (new Phrase("Das Restaurant", "audio/lesson1/00_Das_Restaurant.mp3"));
			phrases.Add (new Phrase("Ich bin sehr mude", "audio/lesson1/01_Ich_bin_sehr_mude.mp3"));
			phrases.Add (new Phrase("und ich habe Hunger", "audio/lesson1/02_und_ich_habe_Hunger.mp3"));
			//phrases.Add (new Phrase("Dort ist ein Restaurant", "audio/lesson1/03_Dort_ist_ein_Restaurant.mp3"));
			//phrases.Add (new Phrase("Es ist schon nicht wahr", "audio/lesson1/04_Es_ist_schon_nicht_wahr.mp3"));
			//phrases.Add (new Phrase("Ja aber...", "audio/lesson1/05_Ja_aber.mp3"));
			//phrases.Add (new Phrase("Haben Sie auch Hunger", "audio/lesson1/06_Haben_Sie_auch_Hunger.mp3"));

			var enumerator1 = phrases.GetTwoWayEnumerator ();
			// прямой ход
			Assert.AreEqual (null, enumerator1.Current);
			Assert.IsTrue (enumerator1.MoveNext ());
			Assert.AreEqual ("Das Restaurant", enumerator1.Current.Text);
			Assert.IsTrue (enumerator1.MoveNext ());
			Assert.AreEqual ("Ich bin sehr mude", enumerator1.Current.Text);
			Assert.IsTrue (enumerator1.MoveNext ());
			Assert.AreEqual ("und ich habe Hunger", enumerator1.Current.Text);
			Assert.IsFalse (enumerator1.MoveNext ());
			Assert.AreEqual (null, enumerator1.Current);
			Assert.IsFalse (enumerator1.MoveNext ());
			Assert.AreEqual (null, enumerator1.Current);
			// обратный ход
			Assert.IsTrue (enumerator1.MovePrevious ());
			Assert.AreEqual ("und ich habe Hunger", enumerator1.Current.Text);
			Assert.IsTrue (enumerator1.MovePrevious ());
			Assert.AreEqual ("Ich bin sehr mude", enumerator1.Current.Text);
			Assert.IsTrue (enumerator1.MovePrevious ());
			Assert.AreEqual ("Das Restaurant", enumerator1.Current.Text);
			Assert.IsFalse (enumerator1.MovePrevious ());
			Assert.AreEqual (null, enumerator1.Current);
			Assert.IsFalse (enumerator1.MovePrevious ());
			Assert.AreEqual (null, enumerator1.Current);
			Assert.IsTrue (enumerator1.MoveNext ());
			Assert.AreEqual ("Das Restaurant", enumerator1.Current.Text);

			//ITwoWayEnumerator<Phrase> enumerator = phrases.GetTwoWayEnumerator ();
			//enumerator.MoveNext ();
			//Assert.AreEqual ("Das Restaurant", enumerator.Current.Text);
			//enumerator.MoveNext ();
			//Assert.AreEqual ("Ich bin sehr mude", enumerator.Current.Text);
			//phrase = phrases.Next;
			//phrase = phrases.Prev;
*/


		}
	}
}

