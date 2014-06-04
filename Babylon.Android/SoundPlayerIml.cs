using System;
using Android.Media;
using Android.Content.Res;

namespace Babylon.Android
{
	public class SoundPlayerIml : SoundPlayerBase
	{
		MediaPlayer player;
		AssetManager Assets;

		public SoundPlayerIml (AssetManager assets)
		{
			Assets = assets;
		}

		public override void Play (string filename)
		{
			AssetFileDescriptor afd = Assets.OpenFd(filename);
			player = new MediaPlayer();
			player.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
			player.Completion += DidFinishPlaying;			
			player.Prepare();
			player.Start();	
		}
		
		void DidFinishPlaying (object sender, EventArgs e)
		{
			RaseFinishPlayingEvent ();
		}
	}
}