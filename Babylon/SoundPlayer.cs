using System;

namespace Babylon
{
	public interface SoundPlayer
	{
		void Play (string filename);
		event EventHandler PlayingFinished;
		void RaseFinishPlayingEvent ();
	}
}