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
			OnFinishPlaying(new EventArgs (/*arguments*/));
		}

		#endregion

		protected virtual void OnFinishPlaying(EventArgs e)
		{
			PlayingFinished.Invoke(this, new EventArgs());
		}
	}
}

