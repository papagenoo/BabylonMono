using System;
using Babylon.UI;

namespace Babylon.UI
{
	public interface PhrasesPresenter
	{
		void MoveNext ();
		void MovePrevious ();
		void PlaySoundStart ();
		void EnterAutoMode ();
		void ExitAutoMode ();
	}
}