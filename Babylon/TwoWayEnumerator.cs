using System;
using System.Collections.Generic;

namespace Babylon
{
	public static class TwoWayEnumeratorHelper
	{
		public static ITwoWayEnumerator<T> GetTwoWayEnumerator<T>(this IList<T> source)
		{
			if (source == null)
				throw new ArgumentNullException("source");

			return new TwoWayEnumerator<T>(source);
		}
	}

	public interface ITwoWayEnumerator<T> : IEnumerator<T>
	{
		bool MovePrevious();
	}

	public class TwoWayEnumerator<T> : ITwoWayEnumerator<T>
	{
		protected IList<T> _source;
		protected int _index;

		public TwoWayEnumerator(IList<T> source)
		{
			if (source == null)
				throw new ArgumentNullException("source");

			_source = source;
			_index = -1;
		}

		public virtual bool MovePrevious()
		{
			if (CanDecrement())
				--_index;
			Logger.Write (_index.ToString());
			return IsInBounds();
		}

		public virtual bool MoveNext()
		{
			if (CanIncrement())
				++_index;
			Logger.Write (_index.ToString());
			return IsInBounds();
		}

		public T Current
		{
			get
			{
				if ( ! IsInBounds())
					return default(T);
				return _source[_index];
			}
		}

		public void Reset()
		{
			_index = -1;
		}

		public void Dispose()
		{
			_source = null;
		}

		object System.Collections.IEnumerator.Current
		{
			get { return Current; }
		}

		
		protected virtual bool CanDecrement()
		{
			return _index > -1;
		}

		protected virtual bool CanIncrement()
		{
			return _index < _source.Count;
		}

		protected bool IsInBounds()
		{
			return _index > -1 && _index < _source.Count;
		}
	}
}

