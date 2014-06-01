using System;
using MonoTouch.AVFoundation;
using System.IO;
using MonoTouch.Foundation;

namespace Babylon.iOS
{
	public class SoundPlayerIml : SoundPlayer
	{
		AVAudioPlayer player;

		public void Play (string filename)
		{
			try
			{
				var Soundurl = NSUrl.FromFilename(filename);
				player = AVAudioPlayer.FromUrl(Soundurl);
				var onePlay = player;
				onePlay.CurrentTime = onePlay.Duration*2;
				onePlay.NumberOfLoops = 1;
				onePlay.Volume = 1.0f;
				onePlay.FinishedPlaying += DidFinishPlaying;
				onePlay.PrepareToPlay();
				onePlay.Play();
			}
			catch (Exception e)
			{
				Console.WriteLine("PlaySound: Error: " + e.Message, true);
			}
		}

		void DidFinishPlaying (object sender, AVStatusEventArgs e)
		{
			if (e.Status)
				Console.WriteLine (e.Status);
		}
	}
}

