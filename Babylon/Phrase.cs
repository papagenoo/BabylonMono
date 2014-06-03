using System;

namespace Babylon
{
	public class Phrase
	{
		public Phrase(string text, string translation, string audioFileName)
		{
			Text = text;
			Translation = translation;
			AudioFileName = audioFileName;
		}

		public string Text { get; private set; }
		public string Translation { get; private set; }
		public string AudioFileName { get; private set; }
	}
}

