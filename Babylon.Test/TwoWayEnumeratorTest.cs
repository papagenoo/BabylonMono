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
			IList<string> list = new List<string> {
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
		}
	}
}