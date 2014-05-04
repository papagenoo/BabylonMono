using NUnit.Framework;
using System;
using Babylon.UI;

namespace Babylon.Test
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			MyClass c1 = new MyClass ();
			Assert.IsTrue (c1 is MyClass);
			TranslatePresenter translatePresenter = new TranslatePresenter ();
			Assert.IsTrue (translatePresenter is TranslatePresenter);
		}
	}
}

