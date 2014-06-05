using System;
using Babylon.UI;

namespace Babylon.UI
{
	public interface PhrasesPresenter
	{
		void MoveNext ();
		void MovePrevious ();
		void PlaySoundStart ();
		void PlaySoundStop ();
		void EnterAutoMode ();
		void EnterManualMode ();
		void DelayAndRaseNextEvent ();

		void HandleNextEvent ();
		void HandlePreviousEvent ();
		void HandlePlaySoundStartEvent ();
		void HandlePlaySoundStopEvent ();
		void HandleEnterAutoModeEvent ();
		void HandleEnterManualModeEvent ();
	}
}