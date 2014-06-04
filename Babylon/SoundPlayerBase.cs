using System;

namespace Babylon
{
	public abstract class SoundPlayerBase : SoundPlayer
	{
		#region SoundPlayer implementation

		public abstract void Play (string filename);
		public event EventHandler PlayingFinished;

		public void RaseFinishPlayingEvent()
		{
			if (PlayingFinished != null)
				PlayingFinished.Invoke(this, new EventArgs ());
		}

		#endregion

	}
}