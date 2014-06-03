using System;
using NUnit.Framework;

namespace Babylon.Test
{
	public class PhraseTest
	{
		[Test ()]
		public void PhrasesEqualityTest ()
		{
			Phrase p1 = new Phrase ("1", "2", "3");
			Phrase p2 = new Phrase ("1", "2", "3");
			Phrase p3 = new Phrase ("1", "2", "-");
			Phrase p4 = new Phrase ("1", "-", "3");
			Phrase p5 = new Phrase ("-", "2", "3");

			Assert.IsTrue (p1.Equals (p2));
			Assert.IsFalse (p1.Equals (p3));
			Assert.IsFalse (p1.Equals (p4));
			Assert.IsFalse (p1.Equals (p5));
		}
	}
}