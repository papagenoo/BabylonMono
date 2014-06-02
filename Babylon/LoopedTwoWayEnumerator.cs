using System;
using System.Collections.Generic;

namespace Babylon
{
	public static class LoopedTwoWayEnumeratorHelper
	{
		public static ILoopedTwoWayEnumerator<T> GetLoopedTwoWayEnumerator<T>(this IList<T> source)
		{
			if (source == null)
				throw new ArgumentNullException("source");

			return new LoopedTwoWayEnumerator<T>(source);
		}
	}

	public interface ILoopedTwoWayEnumerator<T> : ITwoWayEnumerator<T>
	{
	}

	public class LoopedTwoWayEnumerator<T> : TwoWayEnumerator<T>, ILoopedTwoWayEnumerator<T>
	{
		public LoopedTwoWayEnumerator(IList<T> source)
			:base(source)
		{
		}

		public override bool MovePrevious()
		{
			if (CanDecrement ())
				--_index;
			else
				_index = _source.Count - 1;
			Logger.Write (_index.ToString());
			return IsInBounds();
		}

		public override bool MoveNext()
		{
			if (CanIncrement ())
				++_index;
			else
				_index = 0;
			return IsInBounds();
		}

		protected override bool CanIncrement()
		{
			return _index < _source.Count - 1;
		}

		protected override bool CanDecrement()
		{
			return _index > 0;
		}
	}
}

