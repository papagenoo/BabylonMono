using System.Collections.Generic;
using NUnit.Framework;
using System;
using Babylon.UI;
using Babylon;

namespace Babylon.Test
{
	[TestFixture ()]
	public class LoopedTwoWayEnumeratorTest
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
			var enumerator = list.GetLoopedTwoWayEnumerator ();
			Assert.AreEqual (null, enumerator.Current);
			Assert.IsTrue (enumerator.MoveNext ());
			Assert.AreEqual ("First", enumerator.Current);
			Assert.IsTrue (enumerator.MoveNext ());
			Assert.AreEqual ("Second", enumerator.Current);
			Assert.IsTrue (enumerator.MoveNext ());
			Assert.AreEqual ("Third", enumerator.Current);
			Assert.IsTrue (enumerator.MoveNext ());
			Assert.AreEqual ("First", enumerator.Current);
			Assert.IsTrue (enumerator.MoveNext ());
			Assert.AreEqual ("Second", enumerator.Current);
			// обратный ход
			Assert.IsTrue (enumerator.MovePrevious ());
			Assert.AreEqual ("First", enumerator.Current);
			Assert.IsTrue (enumerator.MovePrevious ());
			Assert.AreEqual ("Third", enumerator.Current);
			Assert.IsTrue (enumerator.MovePrevious ());
			Assert.AreEqual ("Second", enumerator.Current);
			Assert.IsTrue (enumerator.MovePrevious ());
			Assert.AreEqual ("First", enumerator.Current);
			Assert.IsTrue (enumerator.MovePrevious ());
			Assert.AreEqual ("Third", enumerator.Current);
			Assert.IsTrue (enumerator.MoveNext ());
			Assert.AreEqual ("First", enumerator.Current);
		}
	}
}