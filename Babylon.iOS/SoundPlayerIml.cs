using System;
using MonoTouch.AVFoundation;
using System.IO;
using MonoTouch.Foundation;

namespace Babylon.iOS
{
	public class SoundPlayerIml : SoundPlayerBase
	{
		AVAudioPlayer player;

		public override void Play (string filename)
		{
			try
			{
				/// todo: Устранить загадочную ошибку 
				var Soundurl = NSUrl.FromFilename(filename);
				if (player != null)
					player.Stop();
				player = AVAudioPlayer.FromUrl(Soundurl);
				player.Stop();
				player.CurrentTime = player.Duration * 2;
				player.NumberOfLoops = 1;
				player.Volume = 1.0f;
				player.FinishedPlaying += DidFinishPlaying;
				player.PrepareToPlay();
				player.Play();
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
			RaseFinishPlayingEvent();
		}
	}
}

